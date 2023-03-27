namespace ET
{
    [ComponentOf(typeof(Monster))]
    public class BurningBuffComponent : Entity,IAwake,IDestroy
    {
        public float TimerId;
        public float BurningBuffContinuedTime;
        public float BurningBuffEffectTime;
        public float BurningBuffContinuedTimer;
        public float BurningBuffEffectTimer;
        public int PhysicsDamage;
        public int MagicDamage;
    }
}
