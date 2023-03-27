using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using UnityEngine;

namespace ET
{
    public class Monster : Entity, IAwake<int>
    {
        public int ConfigId; //配置表id

        [BsonIgnore]
        public MonsterConfig Config => MonsterConfigCategory.Instance.Get(this.ConfigId);

        private WrapVector3 position = new WrapVector3(); //坐标

        public Vector3 Position
        {
            get => this.position.Value;
            set
            {
                EventType.ChangePosition.Instance.OldPos.Value = this.position.Value;
                this.position.Value = value;

                EventType.ChangePosition.Instance.Monster = this;
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
                EventType.ChangeRotation.Instance.Monster = this;
                Game.EventSystem.PublishClass(EventType.ChangeRotation.Instance);
            }
        }
        public Action<Monster> DeathEvent;
        public bool IsDead;
    }
}