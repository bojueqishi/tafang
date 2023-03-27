using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    public class Item : Entity, IAwake<int>, IDestroy,ISerializeToEntity
    {
        public int ConfigId = 0;
        public int ItemNumber = 0;
        [BsonIgnore]
        public ItemConfig Config => ItemConfigCategory.Instance.Get(ConfigId);
    }
}
