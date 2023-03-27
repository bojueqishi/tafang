namespace ET
{
    [FriendClass(typeof(BagComponent))]
    [FriendClass(typeof(Item))]
    public static class ItemUpdateNoticeHelper
    {
        public static void AsyncAddItem(Unit unit, Item item,G2C_ItemUpdateOpInfo message) 
        {
            message.ItemInfo = item.ToMessage();
            message.Op = (int)ItemOp.Add;
            MessageHelper.SendToClient(unit, message);

        }
        public static void AsyncRemoveItem(Unit unit, Item item, G2C_ItemUpdateOpInfo message)
        {
            message.ItemInfo = item.ToMessage();
            message.Op = (int)ItemOp.Reduce;
            MessageHelper.SendToClient(unit, message);
        }
        public static void AsyncAllBagItems(Unit unit)
        {
            G2C_AllItemsList message = new G2C_AllItemsList() { ContainerType = (int)ItemContainerType.Bag};
            BagComponent bagcomponent = unit.GetComponent<BagComponent>();
            foreach(var item in bagcomponent.ItemDict.Values)
            {
                message.ItemInfoList.Add(item.ToMessage());
            }

            MessageHelper.SendToClient(unit, message);
        }
    }
}
