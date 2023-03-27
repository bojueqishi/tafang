using UnityEngine;
namespace ET
{
    [ComponentOf(typeof(Bullet))]
    public class MulRangeDamageBullet : Entity,IAwake,IUpdate,IDestroy,LogicBullet
    {
        public float Speed;
        public float DamageRange;
        public string Prefabname;
        public int PhysicsDamage;
        public int MagicDamage;
        public Vector3 DirPos;
        public int AllTime;
        public int AllTimer;
        public int SingleDamageInterval;
        public int SingleDamageIntervalTimer;
        public bool IsTrigger;
        public bool IsAP;
        public float Multiplier;
    }
}
