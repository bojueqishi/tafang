using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Tower))]
    public class ArrowShootNormalSkill : Entity,IAwake,IDestroy,LogicSkill
    {
        public int AttackInterval;
        public int AttackIntervalTimer;
        public string PrefabName;
        public int FlySpeed;
        public int RemainAttackNumber;
        public int RemainAttackLogic;
        public Dictionary<string, int> param;
    }
}
