using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class TowerSkillConfigCategory : ProtoObject, IMerge
    {
        public static TowerSkillConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, TowerSkillConfig> dict = new Dictionary<int, TowerSkillConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<TowerSkillConfig> list = new List<TowerSkillConfig>();
		
        public TowerSkillConfigCategory()
        {
            Instance = this;
        }
        
        public void Merge(object o)
        {
            TowerSkillConfigCategory s = o as TowerSkillConfigCategory;
            this.list.AddRange(s.list);
        }
		
        public override void EndInit()
        {
            foreach (TowerSkillConfig config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public TowerSkillConfig Get(int id)
        {
            this.dict.TryGetValue(id, out TowerSkillConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (TowerSkillConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, TowerSkillConfig> GetAll()
        {
            return this.dict;
        }

        public TowerSkillConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class TowerSkillConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		[ProtoMember(1)]
		public int Id { get; set; }
		/// <summary>技能充能时间</summary>
		[ProtoMember(2)]
		public int SkillFrontTime { get; set; }
		/// <summary>技能持续时间</summary>
		[ProtoMember(3)]
		public int SkillContinueTime { get; set; }
		/// <summary>技能描述</summary>
		[ProtoMember(4)]
		public string SkillText { get; set; }

	}
}
