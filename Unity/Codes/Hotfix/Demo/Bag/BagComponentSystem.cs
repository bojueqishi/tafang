using System.Collections.Generic;

namespace ET
{
    [FriendClass(typeof(BagComponent))]
    [FriendClass(typeof(Item))]
    public static class BagComponentSystem
    {
        public static void Clear(this BagComponent self)
        {
            ForeachHelper.Foreach(self.ItemDict, (long id, Item item) =>
            {
                item?.Dispose();
            });
            self.ItemDict.Clear();
            self.ItemsMap.Clear();
        }
        public static void AddItem(this BagComponent self,Item item)
        {
            bool IsHaveIt = false;
            foreach(Item currentitem in self.ItemDict.Values)
            {
                if(currentitem.Id == item.Id)//存在物品
                {
                    IsHaveIt = true;
                }
            }
            if (IsHaveIt == true) 
            {
                self.ItemDict[item.Id] = item;
            }
            Log.Debug(item.ItemNumber.ToString());
            foreach(List<Item> items in self.ItemsMap.Values)
            {
                for(int i=0;i<items.Count;i++)
                {
                    Item Item = items[i];
                    if(Item.Id == item.Id)
                    {
                        items[i] = item;
                        self.GetChild<Item>(item.Id)?.Dispose(); ;
                        self.AddChild(item);
                        return;
                    }
                }
            }
            self.AddChild(item);
            self.ItemDict.Add(item.Id, item);
            self.ItemsMap.Add(item.Config.ItemType, item);
        }
        public static void ReduceItem(this BagComponent self,Item item)//消耗物品
        {
            self.ItemDict.TryGetValue(item.Id,out Item Item);
            if(Item != null)
            {
                self.ItemDict[item.Id] = item;
            }
            Log.Debug(item.ItemNumber.ToString());
            Item TempItem = null;
            foreach (List<Item> items in self.ItemsMap.Values)//Map
            {
                for(int i=0;i<items.Count;i++)
                {
                    Item currentitem = items[i];
                    if(currentitem.Id == item.Id)
                    {
                        self.GetChild<Item>(item.Id)?.Dispose(); ;
                        self.AddChild(item);
                        TempItem = items[i];
                        items[i] = item;
                        break;
                    }
                }
            }
            if (TempItem.ItemNumber <= 0)
            {
                self.RemoveItem(TempItem);
            }
        }
        public static void RemoveItem(this BagComponent self,Item item)
        {
            if(self.ItemDict.ContainsKey(item.Id))
            {
                self.ItemDict.Remove(item.Id);
            }
            Item TempItem = null;
            foreach(List<Item> items in self.ItemsMap.Values)
            {
                for(int i=0;i<items.Count;i++)
                {
                    Item currentitem = items[i];
                    if (currentitem.Id == item.Id)
                    {
                        TempItem = currentitem;
                    }
                }
            }
            self.ItemsMap.Remove(TempItem.Config.ItemType, TempItem);
        }

    }
}
