using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class TowerConfigCategory : ProtoObject, IMerge
    {
        public static TowerConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, TowerConfig> dict = new Dictionary<int, TowerConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<TowerConfig> list = new List<TowerConfig>();
		
        public TowerConfigCategory()
        {
            Instance = this;
        }
        
        public void Merge(object o)
        {
            TowerConfigCategory s = o as TowerConfigCategory;
            this.list.AddRange(s.list);
        }
		
        public override void EndInit()
        {
            foreach (TowerConfig config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public TowerConfig Get(int id)
        {
            this.dict.TryGetValue(id, out TowerConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (TowerConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, TowerConfig> GetAll()
        {
            return this.dict;
        }

        public TowerConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class TowerConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		[ProtoMember(1)]
		public int Id { get; set; }
		/// <summary>名字</summary>
		[ProtoMember(2)]
		public string Name { get; set; }
		/// <summary>预设物名称</summary>
		[ProtoMember(3)]
		public string PrefabName { get; set; }
		/// <summary>攻击(1物理,2魔法)</summary>
		[ProtoMember(4)]
		public int[] Attack { get; set; }
		/// <summary>攻击速度</summary>
		[ProtoMember(5)]
		public int AttackInterval { get; set; }
		/// <summary>造价</summary>
		[ProtoMember(6)]
		public int Price { get; set; }
		/// <summary>范围</summary>
		[ProtoMember(7)]
		public int Range { get; set; }
		/// <summary>普攻技能Id</summary>
		[ProtoMember(8)]
		public int NoramlSkill { get; set; }
		/// <summary>美术资源</summary>
		[ProtoMember(9)]
		public string ResourceCode { get; set; }

	}
}
