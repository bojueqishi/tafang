using System;
using System.Collections.Generic;

namespace ET
{
    public class ArrowShootNormalSkillAwakeSystem : AwakeSystem<ArrowShootNormalSkill>
    {
        public override void Awake(ArrowShootNormalSkill self)
        {
            NumericComponent num = self.GetParent<Tower>().GetComponent<NumericComponent>();
            self.AttackInterval = num.GetAsInt(NumericType.TowerAttackInterval);
            self.AttackIntervalTimer = 0;
            self.PrefabName = "Bullet1";
            self.FlySpeed = 5;
            self.RemainAttackNumber = 0;
            self.RemainAttackLogic = 0;
            self.param = new Dictionary<string, int>();
            self.param = SkillHelper.GetSkillString(SkillConfigCategory.Instance.Get(1001).Params);
        }
    }
    [FriendClass(typeof(ArrowShootNormalSkill))]
    [FriendClass(typeof(Tower))]
    public static class ArrowShootNormalSkillSystem
    {
        public static void OnLogic(this ArrowShootNormalSkill self, int dt)
        {
            self.AttackIntervalTimer = self.AttackIntervalTimer + dt;
            List<Monster> attacktargetlist = self.GetParent<Tower>().AttackTargetList;
            if (self.RemainAttackLogic > 0 && attacktargetlist.Count > 0)//例如两只箭延时攻击分开打
            {
                self.RemainAttackLogic--;
                if (self.RemainAttackLogic == 0)
                {
                    self.Attack(attacktargetlist);
                    self.RemainAttackNumber--;
                    if (self.RemainAttackNumber > 0)
                    {
                        self.RemainAttackLogic = 2;
                    }
                }
            }
            else
            {
                self.RemainAttackLogic = 0;
                self.RemainAttackNumber = 0;
            }
            if (self.AttackIntervalTimer >= self.AttackInterval)
            {
                if(attacktargetlist.Count > 0)
                {
                    if(self.GetParent<Tower>().state == TowerState.NormalAttack)
                    {
                        self.Attack(attacktargetlist);//直接攻击
                        self.RemainAttackNumber = self.GetParent<Tower>().AttackNumber;//获得攻击数量
                        self.RemainAttackNumber--;//攻击数量--
                        if (self.RemainAttackNumber > 0)//若攻击了还大于0 则给延时攻击帧赋值为2 例如攻击两个 攻击了之后number = 1，logic = 2
                        {
                            self.RemainAttackLogic = 2;
                        }
                    }
                    if(self.GetParent<Tower>().state == TowerState.SkillAttack)
                    {
                        SkillHelper.OnSkill(self.GetParent<Tower>());
                    }
                    self.AttackIntervalTimer = 0;//初始化攻击时间
                }
            }
        }
        public static void Attack(this ArrowShootNormalSkill self,List<Monster> attacktargetlist)
        {
            UnitFactory.CreateSingleBullet(self.ZoneScene().CurrentScene(),
                    self.GetParent<Tower>(),
                    attacktargetlist[0],
                    self.PrefabName,
                    self.FlySpeed).Coroutine();
            
        }
    }
}
