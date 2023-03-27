using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class BuffConfigCategory : ProtoObject, IMerge
    {
        public static BuffConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, BuffConfig> dict = new Dictionary<int, BuffConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<BuffConfig> list = new List<BuffConfig>();
		
        public BuffConfigCategory()
        {
            Instance = this;
        }
        
        public void Merge(object o)
        {
            BuffConfigCategory s = o as BuffConfigCategory;
            this.list.AddRange(s.list);
        }
		
        public override void EndInit()
        {
            foreach (BuffConfig config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public BuffConfig Get(int id)
        {
            this.dict.TryGetValue(id, out BuffConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (BuffConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, BuffConfig> GetAll()
        {
            return this.dict;
        }

        public BuffConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class BuffConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		[ProtoMember(1)]
		public int Id { get; set; }
		/// <summary>Buff持续时间</summary>
		[ProtoMember(2)]
		public int BuffContinuedTime { get; set; }
		/// <summary>Buff作用间隔</summary>
		[ProtoMember(3)]
		public int BuffEffectInterval { get; set; }
		/// <summary>Buff作用效果</summary>
		[ProtoMember(4)]
		public int[] BuffDamage { get; set; }
		/// <summary>Buff类型</summary>
		[ProtoMember(5)]
		public int BuffType { get; set; }
		/// <summary>Buff描述</summary>
		[ProtoMember(6)]
		public string BuffDescription { get; set; }

	}
}
