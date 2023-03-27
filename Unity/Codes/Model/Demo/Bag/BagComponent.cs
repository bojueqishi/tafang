using System.Collections.Generic;

namespace ET
{
    [ChildType(typeof(Item))]
    [ComponentOf(typeof(Scene))]
    public class BagComponent:Entity,IAwake,IDestroy
    {
        public Dictionary<long, Item> ItemDict = new Dictionary<long, Item>();
        public MultiMap<int,Item> ItemsMap = new MultiMap<int,Item>();
    }
}
