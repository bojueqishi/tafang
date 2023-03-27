using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ET
{
    [ChildType(typeof(Item))]
    [ComponentOf(typeof(Unit))]
    public class BagComponent : Entity, IAwake, IDestroy,IDeserialize,ITransfer,IUnitCache
    {
        [BsonIgnore]
        public Dictionary<long, Item> ItemDict = new Dictionary<long, Item>();
        [BsonIgnore]
        public MultiMap<int, Item> ItemsMap = new MultiMap<int, Item>();
        [BsonIgnore]
        public G2C_ItemUpdateOpInfo message = new G2C_ItemUpdateOpInfo() { ContainerType = (int)ItemContainerType.Bag};
    }
}
