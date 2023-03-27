using UnityEngine;

namespace ET
{
    public enum MonsterState
    {
        None = 0,
        Run = 1,
    }
    [ComponentOf(typeof(Monster))]
    public class MonsterNavComponent:Entity,IAwake,IUpdate,IDestroy
    {
        public Vector3[] NavPos = new Vector3[] {};
        public NumericComponent num;
        public Transform transform;
        public Vector3 LogicPos;
        public int CurrentPos;
        public float Speed;
        public bool IsDead;
        public MonsterState state;
    }
}
