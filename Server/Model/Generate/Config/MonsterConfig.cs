using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class MonsterConfigCategory : ProtoObject, IMerge
    {
        public static MonsterConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, MonsterConfig> dict = new Dictionary<int, MonsterConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<MonsterConfig> list = new List<MonsterConfig>();
		
        public MonsterConfigCategory()
        {
            Instance = this;
        }
        
        public void Merge(object o)
        {
            MonsterConfigCategory s = o as MonsterConfigCategory;
            this.list.AddRange(s.list);
        }
		
        public override void EndInit()
        {
            foreach (MonsterConfig config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public MonsterConfig Get(int id)
        {
            this.dict.TryGetValue(id, out MonsterConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (MonsterConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, MonsterConfig> GetAll()
        {
            return this.dict;
        }

        public MonsterConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class MonsterConfig: ProtoObject, IConfig
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
		/// <summary>掉落金币</summary>
		[ProtoMember(5)]
		public int DropMoney { get; set; }
		/// <summary>防御(物理,魔法)</summary>
		[ProtoMember(6)]
		public int[] Defense { get; set; }
		/// <summary>攻击力</summary>
		[ProtoMember(7)]
		public int MonsterAttack { get; set; }
		/// <summary>购买所需金币</summary>
		[ProtoMember(8)]
		public int NeedMoney { get; set; }

	}
}
