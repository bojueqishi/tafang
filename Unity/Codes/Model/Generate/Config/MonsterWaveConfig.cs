using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class MonsterWaveConfigCategory : ProtoObject, IMerge
    {
        public static MonsterWaveConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, MonsterWaveConfig> dict = new Dictionary<int, MonsterWaveConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<MonsterWaveConfig> list = new List<MonsterWaveConfig>();
		
        public MonsterWaveConfigCategory()
        {
            Instance = this;
        }
        
        public void Merge(object o)
        {
            MonsterWaveConfigCategory s = o as MonsterWaveConfigCategory;
            this.list.AddRange(s.list);
        }
		
        public override void EndInit()
        {
            foreach (MonsterWaveConfig config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public MonsterWaveConfig Get(int id)
        {
            this.dict.TryGetValue(id, out MonsterWaveConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (MonsterWaveConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, MonsterWaveConfig> GetAll()
        {
            return this.dict;
        }

        public MonsterWaveConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class MonsterWaveConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		[ProtoMember(1)]
		public int Id { get; set; }
		/// <summary>波次配置关键字</summary>
		[ProtoMember(2)]
		public string WaveCode { get; set; }
		/// <summary>组别</summary>
		[ProtoMember(3)]
		public int Group { get; set; }
		/// <summary>序号</summary>
		[ProtoMember(4)]
		public int Timing { get; set; }
		/// <summary>每波次怪的编号</summary>
		[ProtoMember(5)]
		public int MonsterId { get; set; }
		/// <summary>每波次的数量</summary>
		[ProtoMember(6)]
		public int MonsterNumber { get; set; }
		/// <summary>怪与怪的间隔</summary>
		[ProtoMember(7)]
		public int MonsterInterval { get; set; }

	}
}
