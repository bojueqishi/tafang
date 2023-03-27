using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class TowerAwakeSystem : AwakeSystem<Tower, int>
    {
        public override void Awake(Tower self, int configId)
        {
            self.ConfigId = configId;
            self.AttackTargetList = new List<Monster>();
            self.state = TowerState.NormalAttack;
            self.AttackNumber = 1;
        }
    }
    [FriendClass(typeof(GameComponent))]
    [FriendClass(typeof(Tower))]
    [FriendClass(typeof(Monster))]
    public static class TowerSystem
    {
        public static async void OnLogicUpdate(this Tower self, int dt)
        {
            self.OnLogicGetAttackMonsterList();//获取所有攻击怪物列表
            self.OnLogic(dt);
            self.AttackTargetList.Clear();//重置怪物列表
            await ETTask.CompletedTask;
        }
        public static void OnLogic(this Tower self, int dt)
        {
            foreach (Type type in self.Components.Keys)
            {
                if (typeof(LogicSkill).IsAssignableFrom(type))
                {
                    var component = self.Components[type];
                    object[] param = new object[] { component, dt };
                    Type system = Type.GetType(type.FullName + "System");
                    system.GetMethod("OnLogic").Invoke(component, param);
                }
            }
        }
        public static async void OnLogicGetAttackMonsterList(this Tower self)
        {
            List<Monster> list = self.ZoneScene().CurrentScene().GetComponent<GameComponent>().AllEnemy;
            foreach (Monster monster in list)
            {
                NumericComponent monsternumeric = monster.GetComponent<NumericComponent>();
                float MonsterPx = monster.Position.x;
                float MonsterPy = monster.Position.y;
                int MonsterZone = monsternumeric.GetAsInt(NumericType.MonsterZone);

                NumericComponent towernumeric = self.GetComponent<NumericComponent>();
                float TowerPx = self.Position.x;
                float TowerPy = self.Position.y;
                float TowerRange = towernumeric.GetAsFloat(NumericType.TowerAttackRange);
                float TowerZone = towernumeric.GetAsInt(NumericType.TowerZone);
                if (TowerZone != MonsterZone) continue;
                float dis = Vector2.Distance(new Vector2(MonsterPx, MonsterPy), new Vector2(TowerPx, TowerPy));
                if (dis <= TowerRange)
                {
                    self.AddMonster(monster);
                    monster.DeathEvent = monster.DeathEvent + self.RemoveMonster;
                }
                else
                {
                    self.RemoveMonster(monster);
                }
            }
            await ETTask.CompletedTask;
        }
        public static void AddMonster(this Tower self, Monster monster)
        {
            if (self.AttackTargetList.Contains(monster))
            {
                return;
            }
            self.AttackTargetList.Add(monster);
        }
        public static void RemoveMonster(this Tower self, Monster monster)
        {
            if (self.AttackTargetList.Contains(monster))
            {
                self.AttackTargetList.Remove(monster);
            }
        }
        public static void SetTowerState(this Tower self, TowerState state)
        {
            self.state = state;
        }
        public static TowerState GetTowerState(this Tower self)
        {
            return self.state;
        }
    }
}
