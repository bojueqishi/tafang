using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ET
{
    [ChildType(typeof(FightItem))]
    [ComponentOf(typeof(Unit))]
    public class FightItemComponent : Entity, IAwake, IDestroy, IDeserialize, ITransfer, IUnitCache
    {
        [BsonIgnore]
        public Dictionary<long, FightItem> FightItemDict = new Dictionary<long, FightItem>();
        [BsonIgnore]
        public MultiMap<int, FightItem> FightItemsMap = new MultiMap<int, FightItem>();
        [BsonIgnore]
        public G2C_FightItemUpdateOpInfo message = new G2C_FightItemUpdateOpInfo();
    }
}
