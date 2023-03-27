using System.Collections.Generic;

namespace ET
{
    public class BagComponentAwakeSystem : AwakeSystem<BagComponent>
    {
        public override void Awake(BagComponent self)
        {
            
        }
    }
    public class BagComponentDestroySystem : DestroySystem<BagComponent>
    {
        public override void Destroy(BagComponent self)
        {
            foreach(var item in self.ItemDict.Values)
            {
                item?.Dispose();
            }
            self.ItemDict.Clear();
            self.ItemsMap.Clear();
        }
    }
    public class BagComponentDeserializeSystem : DeserializeSystem<BagComponent>
    {
        public override void Deserialize(BagComponent self)
        {
            foreach(Entity entity in self.Children.Values)
            {
                self.AddContainer(entity as Item);
            }
        }
    }
    [FriendClass(typeof(BagComponent))]
    [FriendClass(typeof(Item))]
    public static class BagComponentSystem
    {
        public static bool AddContainer(this BagComponent self,Item item)
        {
            if(self.ItemDict.ContainsKey(item.Id))
            {
                return false;
            }
            self.ItemDict.Add(item.Id, item);
            self.ItemsMap.Add(item.Config.ItemType, item);
            return true;
        }
        public static bool IsCanAddItemByConfigId(this BagComponent self, int ConfigId)
        {
            if(!ItemConfigCategory.Instance.Contain(ConfigId))
            {
                return false;
            }
            return true;
        }
        public static bool AddItemByConfigId(this BagComponent self,int ConfigId, int count = 1)
        {
            if(!ItemConfigCategory.Instance.Contain(ConfigId))
            {

                return false;
            }
            if (count <= 0)
            {
                return false;
            }
            bool IsHaveItem = false;
            foreach(Item item in self.ItemDict.Values)
            {
                if(item.ConfigId == ConfigId)//有物品
                {
                    IsHaveItem = true;
                    item.ItemNumber = item.ItemNumber + count;
                    Log.Error(item.ItemNumber.ToString());
                    ItemUpdateNoticeHelper.AsyncAddItem(self.GetParent<Unit>(), item, self.message);
                }
            }
            if(IsHaveItem == false)//没物品
            {
                Item newItem = ItemFactory.Create(self, ConfigId,count);
                if (!self.AddItem(newItem))
                {
                    newItem?.Dispose();
                    return false;
                }
            }
            return true;
        }
        public static bool AddItem(this BagComponent self,Item item)
        {
            if(item == null || item.IsDisposed) 
            {
                return false;
            }
            if(!self.AddContainer(item))
            {
                return false;
            }
            if(item.Parent != self)
            {
                self.AddChild(item);
            }
            ItemUpdateNoticeHelper.AsyncAddItem(self.GetParent<Unit>(), item, self.message);
            return true;
        }
        public static void RemoveItem(this BagComponent self,long id)//移除物品
        {
            if(self.ItemDict.ContainsKey(id))
            {
                self.ItemDict.Remove(id);
            }
            foreach(List<Item> items in self.ItemsMap.Values)
            {
                for(int i=0;i<items.Count;i++)
                {
                    Item item = items[i];
                    if(item.Id == id)
                    {
                        self.ItemsMap.Remove(item.Config.ItemType,item);
                    }
                }
            }
        }
        public static bool ReduceItemByConfigId(this BagComponent self, long id,int count)//消耗物品
        {
            self.ItemDict.TryGetValue(id, out Item Item);
            if (!ItemConfigCategory.Instance.Contain(Item.ConfigId))
            {
                return false;
            }
            if (count <= 0)
            {
                return false;
            }
            Item.ItemNumber = Item.ItemNumber - count;
            Log.Error(Item.ItemNumber.ToString());
            if(Item.ItemNumber <= 0) 
            {
                self.RemoveItem(Item.Id);
            }
            ItemUpdateNoticeHelper.AsyncRemoveItem(self.GetParent<Unit>(), Item, self.message);
            return true;
        }
    }
}
