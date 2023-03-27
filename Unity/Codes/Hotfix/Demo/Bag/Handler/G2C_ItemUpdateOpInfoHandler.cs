namespace ET
{
    [MessageHandler]
    public class G2C_ItemUpdateOpInfoHandler : AMHandler<G2C_ItemUpdateOpInfo>
    {
        protected override void Run(Session session, G2C_ItemUpdateOpInfo message)
        {
            if (message.Op == (int)ItemOp.Add)
            {
                Item item = ItemFactory.Create(session.ZoneScene(), message.ItemInfo);
                ItemHelper.AddItem(session.ZoneScene(), item, (ItemContainerType)message.ContainerType);
            }
            if (message.Op == (int)ItemOp.Reduce)
            {
                Item item = ItemFactory.Create(session.ZoneScene(), message.ItemInfo);
                ItemHelper.ReduceItem(session.ZoneScene(), item, (ItemContainerType)message.ContainerType);
            }
        }
    }
}
