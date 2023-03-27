using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class FightItemConfigCategory : ProtoObject, IMerge
    {
        public static FightItemConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, FightItemConfig> dict = new Dictionary<int, FightItemConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<FightItemConfig> list = new List<FightItemConfig>();
		
        public FightItemConfigCategory()
        {
            Instance = this;
        }
        
        public void Merge(object o)
        {
            FightItemConfigCategory s = o as FightItemConfigCategory;
            this.list.AddRange(s.list);
        }
		
        public override void EndInit()
        {
            foreach (FightItemConfig config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public FightItemConfig Get(int id)
        {
            this.dict.TryGetValue(id, out FightItemConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (FightItemConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, FightItemConfig> GetAll()
        {
            return this.dict;
        }

        public FightItemConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class FightItemConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		[ProtoMember(1)]
		public int Id { get; set; }
		/// <summary>战斗单元名称</summary>
		[ProtoMember(2)]
		public string FightItemName { get; set; }
		/// <summary>战斗单元类型</summary>
		[ProtoMember(3)]
		public int FightItemType { get; set; }
		/// <summary>战斗单元天赋点</summary>
		[ProtoMember(4)]
		public string TalentCode { get; set; }
		/// <summary>资源</summary>
		[ProtoMember(5)]
		public string ResourceCode { get; set; }
		/// <summary>解锁条件</summary>
		[ProtoMember(6)]
		public string UnlockCondition { get; set; }

	}
}
