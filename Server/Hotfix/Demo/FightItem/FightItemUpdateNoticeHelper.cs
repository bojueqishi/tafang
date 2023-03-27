namespace ET
{
    [FriendClass(typeof(FightItemComponent))]
    [FriendClass(typeof(FightItem))]
    public static class FightItemUpdateNoticeHelper
    {
        public static void AsyncAddFightItem(Unit unit, FightItem fightitem, G2C_FightItemUpdateOpInfo message)
        {
            message.FightItemInfo = fightitem.ToMessage();
            message.Op = (int)FightItemOp.Add;
            MessageHelper.SendToClient(unit, message);
        }
        public static void AsyncAddFightItemTalent(Unit unit,FightItem fightitem, G2C_FightItemUpdateOpInfo message)
        {
            message.FightItemInfo = fightitem.ToMessage();
            message.Op = (int)FightItemOp.AddTalent;
            MessageHelper.SendToClient(unit, message);
        }
        public static void AsyncAllFightItems(Unit unit)
        {
            G2C_AllFightItemsList message = new G2C_AllFightItemsList();
            FightItemComponent fightitemcomponent = unit.GetComponent<FightItemComponent>();
            foreach (var fightitem in fightitemcomponent.FightItemDict.Values)
            {
                message.FightItemInfoList.Add(fightitem.ToMessage());
            }

            MessageHelper.SendToClient(unit, message);
        }
    }
}
