namespace ET
{
    public class ItemAwakeSystem : AwakeSystem<Item,int>
    {
        public override void Awake(Item self,int ConfigId)
        {
            self.ConfigId = ConfigId;
        }
    }
    public class ItemDestroySystem : DestroySystem<Item>
    {
        public override void Destroy(Item self)
        {
            self.ConfigId = 0;
        }
    }
    [FriendClass(typeof(Item))]
    public static class ItemSystem
    {
        public static ItemInfo ToMessage(this Item self)
        {
            ItemInfo iteminfo = new ItemInfo();
            iteminfo.ItemUid = self.Id;
            iteminfo.ItemConfigId = self.ConfigId;
            iteminfo.ItemNumber = self.ItemNumber;
            return iteminfo;
        }
    }
}
