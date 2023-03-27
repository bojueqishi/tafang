using UnityEngine;

namespace ET
{
    [ComponentOf]
    public class BulletNavComponent : Entity,IAwake,IUpdate,IDestroy
    {
        public Transform BulletTransform;
        public Rigidbody2D RB2D;
        public MonsterNavComponent TargetNavTransfrom;
        public Vector3 FixedTransformPos;
        public Vector3 LogicPos;
        public bool NextisTrigger;
        public bool isTrigger;
        public bool IsAlreadyTrigger;
    }
}
