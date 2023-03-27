namespace ET
{
    [MessageHandler]
    public class G2C_FightItemUpdateOpInfoHandler : AMHandler<G2C_FightItemUpdateOpInfo>
    {
        protected override void Run(Session session, G2C_FightItemUpdateOpInfo message)
        {
            if(message.Op == (int)FightItemOp.Add)
            {
                FightItem fightitem = FightItemFactory.Create(session.ZoneScene(), message.FightItemInfo);
                FightItemHelper.AddFightItem(session.ZoneScene(), fightitem);
            }
            if(message.Op == (int)FightItemOp.AddTalent)
            {
                FightItem fightitem = FightItemFactory.Create(session.ZoneScene(), message.FightItemInfo);
                FightItemHelper.AddFightItemTalent(session.ZoneScene(), fightitem);
            }
        }
    }
}
