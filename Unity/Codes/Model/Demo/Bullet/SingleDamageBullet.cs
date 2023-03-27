using UnityEngine;

namespace ET
{
    [ComponentOf(typeof(Bullet))]
    public class SingleDamageBullet : Entity,IAwake,IUpdate,IDestroy,LogicBullet
    {
        public float Speed;
        public int PhysicsDamage;
        public int MagicDamage;
        public Monster Monster;
        public bool IsAP;
        public float Multiplier;
    }
}
