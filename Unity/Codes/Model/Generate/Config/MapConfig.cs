using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class MapConfigCategory : ProtoObject, IMerge
    {
        public static MapConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, MapConfig> dict = new Dictionary<int, MapConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<MapConfig> list = new List<MapConfig>();
		
        public MapConfigCategory()
        {
            Instance = this;
        }
        
        public void Merge(object o)
        {
            MapConfigCategory s = o as MapConfigCategory;
            this.list.AddRange(s.list);
        }
		
        public override void EndInit()
        {
            foreach (MapConfig config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public MapConfig Get(int id)
        {
            this.dict.TryGetValue(id, out MapConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (MapConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, MapConfig> GetAll()
        {
            return this.dict;
        }

        public MapConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class MapConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		[ProtoMember(1)]
		public int Id { get; set; }
		/// <summary>关卡UI地图名字</summary>
		[ProtoMember(2)]
		public string MapName { get; set; }
		/// <summary></summary>
		[ProtoMember(3)]
		public int NavIdOne { get; set; }
		/// <summary></summary>
		[ProtoMember(4)]
		public int NavIdTwo { get; set; }
		/// <summary></summary>
		[ProtoMember(5)]
		public int MaxVisualX { get; set; }
		/// <summary></summary>
		[ProtoMember(6)]
		public int MaxVisualY { get; set; }
		/// <summary>UI地图塔的位置X</summary>
		[ProtoMember(7)]
		public int[] PosX { get; set; }
		/// <summary>UI地图塔的位置Y</summary>
		[ProtoMember(8)]
		public int[] PosY { get; set; }

	}
}
