using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System;
using UnityEngine;
namespace ET
{
    public enum BulletType
    {
        //暂定单体为1,群伤为2
        None = 0,
        Single = 1,
        FixedRange = 2,
        Laser = 3,
        FixedRangeSeveral = 4
    }
    public class Bullet : Entity,IAwake,IDestroy
    {
        public float BulletAttackRadius;
        public float BulletSpeed;
        public BulletType BulletType;
        public string BulletPrefabName;
        public int BulletZone;
        public Dictionary<int, int> BulletAttacks;
        public float BulletTime;
        public float BulletAttackInterval;
        public bool IsTrigger;
        public float BulletTimeTimer;
        public float BulletAttackIntervalTimer;
        public int BuffId;
        public Vector3 LogicPos;

        private WrapVector3 position = new WrapVector3(); //坐标

        public Vector3 Position
        {
            get => this.position.Value;
            set
            {
                EventType.ChangePosition.Instance.OldPos.Value = this.position.Value;
                this.position.Value = value;

                EventType.ChangePosition.Instance.Bullet = this;
                Game.EventSystem.PublishClass(EventType.ChangePosition.Instance);
            }
        }

        [BsonIgnore]
        public Vector3 Forward
        {
            get => this.Rotation * Vector3.forward;
            set => this.Rotation = Quaternion.LookRotation(value, Vector3.up);
        }

        private WrapQuaternion rotation = new WrapQuaternion();
        public Quaternion Rotation
        {
            get => this.rotation.Value;
            set
            {
                this.rotation.Value = value;
                EventType.ChangeRotation.Instance.Bullet = this;
                Game.EventSystem.PublishClass(EventType.ChangeRotation.Instance);
            }
        }
    }
}
