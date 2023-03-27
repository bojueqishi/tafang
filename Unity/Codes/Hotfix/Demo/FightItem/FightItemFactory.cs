namespace ET
{
    public static class FightItemFactory
    {
        public static FightItem Create(Entity self, int ConfigId)
        {
            FightItem fightitem = self.AddChild<FightItem, int>(ConfigId);
            return fightitem;
        }
        public static FightItem Create(Entity self, FightItemInfo fightiteminfo)
        {
            FightItem fightitem = self.AddChild<FightItem, int>(fightiteminfo.FightItemConfigId);
            fightitem?.FromMessage(fightiteminfo);
            return fightitem;
        }
    }
}
