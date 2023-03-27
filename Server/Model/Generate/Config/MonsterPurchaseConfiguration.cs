using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class MonsterPurchaseConfigurationCategory : ProtoObject, IMerge
    {
        public static MonsterPurchaseConfigurationCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, MonsterPurchaseConfiguration> dict = new Dictionary<int, MonsterPurchaseConfiguration>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<MonsterPurchaseConfiguration> list = new List<MonsterPurchaseConfiguration>();
		
        public MonsterPurchaseConfigurationCategory()
        {
            Instance = this;
        }
        
        public void Merge(object o)
        {
            MonsterPurchaseConfigurationCategory s = o as MonsterPurchaseConfigurationCategory;
            this.list.AddRange(s.list);
        }
		
        public override void EndInit()
        {
            foreach (MonsterPurchaseConfiguration config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public MonsterPurchaseConfiguration Get(int id)
        {
            this.dict.TryGetValue(id, out MonsterPurchaseConfiguration item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (MonsterPurchaseConfiguration)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, MonsterPurchaseConfiguration> GetAll()
        {
            return this.dict;
        }

        public MonsterPurchaseConfiguration GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class MonsterPurchaseConfiguration: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		[ProtoMember(1)]
		public int Id { get; set; }
		/// <summary>怪物的美术资源</summary>
		[ProtoMember(2)]
		public string PrefabName { get; set; }
		/// <summary>血量</summary>
		[ProtoMember(3)]
		public int Hp { get; set; }
		/// <summary>移速</summary>
		[ProtoMember(4)]
		public int Speed { get; set; }
		/// <summary>花费金币</summary>
		[ProtoMember(5)]
		public int SpendCoins { get; set; }
		/// <summary>物理防御</summary>
		[ProtoMember(6)]
		public int PhysicalDefense { get; set; }
		/// <summary>法术防御</summary>
		[ProtoMember(7)]
		public int SpellDefense { get; set; }

	}
}
