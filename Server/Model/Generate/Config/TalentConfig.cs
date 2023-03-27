using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class TalentConfigCategory : ProtoObject, IMerge
    {
        public static TalentConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, TalentConfig> dict = new Dictionary<int, TalentConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<TalentConfig> list = new List<TalentConfig>();
		
        public TalentConfigCategory()
        {
            Instance = this;
        }
        
        public void Merge(object o)
        {
            TalentConfigCategory s = o as TalentConfigCategory;
            this.list.AddRange(s.list);
        }
		
        public override void EndInit()
        {
            foreach (TalentConfig config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public TalentConfig Get(int id)
        {
            this.dict.TryGetValue(id, out TalentConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (TalentConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, TalentConfig> GetAll()
        {
            return this.dict;
        }

        public TalentConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class TalentConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		[ProtoMember(1)]
		public int Id { get; set; }
		/// <summary>对应战斗单元表的天赋code</summary>
		[ProtoMember(2)]
		public string Code { get; set; }
		/// <summary>天赋层级</summary>
		[ProtoMember(3)]
		public int Level { get; set; }
		/// <summary>天赋位置（左右）</summary>
		[ProtoMember(4)]
		public int Sn { get; set; }
		/// <summary>对应技能Id</summary>
		[ProtoMember(5)]
		public int SkillId { get; set; }

	}
}
