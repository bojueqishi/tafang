using UnityEngine;

namespace ET
{
    public class BurningBuffComponentAwakeSystem : AwakeSystem<BurningBuffComponent>
    {
        public override void Awake(BurningBuffComponent self)
        {
            self.BurningBuffContinuedTimer = 0;
            self.BurningBuffEffectTimer = 0;
        }
    }
    public class BurningBuffComponentDestroySystem : DestroySystem<BurningBuffComponent>
    {
        public override void Destroy(BurningBuffComponent self)
        {
            self.BurningBuffContinuedTimer = 0;
            self.BurningBuffEffectTimer = 0;
        }
    }
    [FriendClass(typeof(BurningBuffComponent))]
    public static class BurningBuffComponentSystem
    {
        public static async ETTask SetBuffTime(this BurningBuffComponent self,float ContinuedTime,float EffectTime,int PhysicsDamage,int MagicDamage)
        {
            self.BurningBuffContinuedTime = ContinuedTime;
            self.BurningBuffEffectTime = EffectTime;
            self.BurningBuffContinuedTimer = 0;
            self.PhysicsDamage = PhysicsDamage;
            self.MagicDamage = MagicDamage;
            await ETTask.CompletedTask;
        }
        public static async ETTask OnLogicUpdate(this BurningBuffComponent self,int dt)
        {
#if UNITY_2017_1_OR_NEWER
            self.BurningBuffContinuedTimer = self.BurningBuffContinuedTimer + dt;
            self.BurningBuffEffectTimer = self.BurningBuffEffectTimer + dt;
#endif
            if (self.BurningBuffEffectTimer >= self.BurningBuffEffectTime)
            {
                //造成事件 触发器归0
                self.BurningBuffEffectTimer = self.BurningBuffEffectTimer - self.BurningBuffEffectTime;
                DamageHelper.BuffAttackMonster(self.ZoneScene().CurrentScene(), self.PhysicsDamage, self.MagicDamage, self.GetParent<Monster>()).Coroutine();
            }
            if (self.BurningBuffContinuedTimer >= self.BurningBuffContinuedTime)
            {
                self.GetParent<Monster>().RemoveComponent(self);
            }
            await ETTask.CompletedTask;
        }
    }
}
