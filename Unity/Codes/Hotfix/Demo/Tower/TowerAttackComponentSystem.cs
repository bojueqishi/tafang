using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class TowerAttackComponentAwakeSystem : AwakeSystem<TowerAttackComponent>
    {
        public override void Awake(TowerAttackComponent self)
        {
            self.AttackTargetList = new List<Monster>();
            self.num = self.GetParent<Tower>().GetComponent<NumericComponent>();
            self.state = TowerState.NormalAttack;
            self.AttackNumber = 1;
        }
    }
    public class TowerAttackComponentDestroyComponent : DestroySystem<TowerAttackComponent>
    {
        public override void Destroy(TowerAttackComponent self)
        {
            self.AttackTargetList.Clear();
        }
    }

    [FriendClass(typeof(GameComponent))]
    [FriendClass(typeof(TowerAttackComponent))]
    [FriendClass(typeof(Monster))]
    public static class TowerAttackComponentSystem
    {
        public static async void OnLogicUpdate(this TowerAttackComponent self,int dt)
        {
            self.OnLogicGetAttackMonsterList();//获取所有攻击怪物列表
            self.OnLogic(dt);
            self.AttackTargetList.Clear();//重置怪物列表
            await ETTask.CompletedTask;
        }
        public static void OnLogic(this TowerAttackComponent self,int dt)
        {
            Tower tower = self.GetParent<Tower>();
            foreach(Type type in tower.Components.Keys)
            {
                if(typeof(LogicSkill).IsAssignableFrom(type))
                {
                    var component = tower.Components[type];
                    object[] param = new object[] { component,dt };
                    Type system = Type.GetType(type.FullName + "System");
                    system.GetMethod("OnLogic").Invoke(component, param);
                }
            }
        }
        public static async void OnLogicGetAttackMonsterList(this TowerAttackComponent self)
        {
            List<Monster> list = self.ZoneScene().CurrentScene().GetComponent<GameComponent>().AllEnemy;
            foreach(Monster monster in list)
            {
                NumericComponent num = monster.GetComponent<NumericComponent>();
                float MonsterPx = monster.Position.x;
                float MonsterPy = monster.Position.y;
                int MonsterZone = num.GetAsInt(NumericType.MonsterZone);

                float TowerPx = self.GetParent<Tower>().Position.x;
                float TowerPy = self.GetParent<Tower>().Position.y;
                float TowerRange = self.num.GetAsFloat(NumericType.TowerAttackRange);
                float TowerZone = self.num.GetAsInt(NumericType.TowerZone);
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
            if(self.AttackTargetList.Count != 0 && self.state != TowerState.SkillAttack)
            {
                self.state = TowerState.NormalAttack;
            }
            await ETTask.CompletedTask;
        }
        public static void AddMonster(this TowerAttackComponent self,Monster monster)
        {
            if(self.AttackTargetList.Contains(monster))
            {
                return;
            }
            self.AttackTargetList.Add(monster);
        }
        public static void RemoveMonster(this TowerAttackComponent self,Monster monster)
        {
            if(self.AttackTargetList.Contains(monster))
            {
                self.AttackTargetList.Remove(monster);
            }
        }
    }
}
