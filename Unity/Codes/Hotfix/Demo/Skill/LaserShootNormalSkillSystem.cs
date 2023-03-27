using System.Collections.Generic;

namespace ET
{
    public class LaserShootNormalSkillAwakeSystem : AwakeSystem<LaserShootNormalSkill>
    {
        public override void Awake(LaserShootNormalSkill self)
        {
            NumericComponent num = self.GetParent<Tower>().GetComponent<NumericComponent>();
            self.AttackInterval = num.GetAsInt(NumericType.TowerAttackInterval);
            self.AttackIntervalTimer = 0;
            self.param = SkillHelper.GetSkillString(SkillConfigCategory.Instance.Get(1015).Params);
        }
    }
    [FriendClass(typeof(LaserShootNormalSkill))]
    [FriendClass(typeof(Tower))]
    public static class LaserShootNormalSkillSystem
    {
        public static void OnLogic(this LaserShootNormalSkill self, int dt)
        {
            self.AttackIntervalTimer = self.AttackIntervalTimer + dt;
            int AttackNumber = self.GetParent<Tower>().AttackNumber;
            List<Monster> AttackTargetList = self.GetParent<Tower>().AttackTargetList;
            self.Attack(AttackNumber, AttackTargetList);
        }
        public static async void Attack(this LaserShootNormalSkill self,int AttackNumber,List<Monster> AttackTargetList)
        {
            if (AttackTargetList.Count <= 0)//攻击列表没怪
            {
                Game.EventSystem.PublishAsync(new EventType.ChangeUnitAnimatorState() { currentscene = self.ZoneScene().CurrentScene(), entity = self.GetParent<Tower>(), AnimatorName = "Idle" }).Coroutine();
                Game.EventSystem.PublishAsync(new EventType.TowerLaser() { currentscene = self.ZoneScene().CurrentScene(), tower = self.GetParent<Tower>(), monster = null, index = 2 }).Coroutine();
                return;
            }
            else
            {
                if (self.AttackIntervalTimer >= self.AttackInterval)//激光直接攻击
                {
                    List<Monster> attackmonsterlist = new List<Monster>();
                    if(AttackNumber >= AttackTargetList.Count)//攻击数量大于等于总数则全攻击
                    {
                        attackmonsterlist = AttackTargetList;
                    }
                    else//攻击数量小于总数则部分攻击
                    {
                        for(int i=0;i<AttackNumber;i++)
                        {
                            attackmonsterlist.Add(AttackTargetList[i]);
                        }
                    }
                    Game.EventSystem.PublishAsync(new EventType.ChangeUnitAnimatorState() { currentscene = self.ZoneScene().CurrentScene(), entity = self.GetParent<Tower>(), AnimatorName = "Run" }).Coroutine();
                    Game.EventSystem.PublishAsync(new EventType.TowerLaser() { currentscene = self.ZoneScene().CurrentScene(), tower = self.GetParent<Tower>(), monster = attackmonsterlist, index = 1 }).Coroutine();
                    for(int i=0;i<attackmonsterlist.Count;i++)
                    {
                        NumericComponent Towernum = self.GetParent<Tower>().GetComponent<NumericComponent>();
                        DamageHelper.TowerSingleAttackMonster(self.ZoneScene().CurrentScene(),
                            self.GetParent<Tower>(),
                            attackmonsterlist[i],
                            Towernum.GetAsInt(NumericType.TowerPhysicsAttack),
                            Towernum.GetAsInt(NumericType.TowerMagicAttack),
                            self.param["isap"] == 1?true:false,
                            self.param["multiplier"] / 100.0f).Coroutine();
                    }
                    self.AttackIntervalTimer = 0;//初始化攻击时间
                }
            }
            await ETTask.CompletedTask;
            
        }
    }
}
