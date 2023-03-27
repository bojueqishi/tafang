namespace ET
{
    [FriendClass(typeof(Item))]
    public static class ItemFactory
    {
        public static Item Create(Entity parent,int ConfigId,int count)
        {
            if(!ItemConfigCategory.Instance.Contain(ConfigId))
            {
                return null;
            }
            Item item = parent.AddChild<Item, int>(ConfigId);
            item.ItemNumber = count;
            return item;
        }
    }
}
