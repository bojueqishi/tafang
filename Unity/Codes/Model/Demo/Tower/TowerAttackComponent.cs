using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Tower))]
    public class TowerAttackComponent : Entity,IAwake,IUpdate,IDestroy
    {
        public List<Monster> AttackTargetList;
        public NumericComponent num;
        public TowerState state;
        public int AttackNumber;
    }
}
