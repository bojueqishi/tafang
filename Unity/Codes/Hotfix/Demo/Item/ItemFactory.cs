namespace ET
{
    public static class ItemFactory
    {
        public static Item Create(Entity self,int ConfigId)
        {
            Item item = self.AddChild<Item, int>(ConfigId);
            return item;
        }
        public static Item Create(Entity self,ItemInfo iteminfo)
        {
            Item item = self.AddChild<Item, int>(iteminfo.ItemConfigId);
            item?.FromMessage(iteminfo);
            return item;
        }
    }
}
