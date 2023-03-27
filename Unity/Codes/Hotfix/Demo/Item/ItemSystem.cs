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
            self.ItemNumber = 0;
        }
    }
    [FriendClass(typeof(Item))]
    public static class ItemSystem
    {
        public static void FromMessage(this Item self,ItemInfo iteminfo)
        {
            self.Id = iteminfo.ItemUid;
            self.ConfigId = iteminfo.ItemConfigId;
            self.ItemNumber = iteminfo.ItemNumber;
        }
    }
}
