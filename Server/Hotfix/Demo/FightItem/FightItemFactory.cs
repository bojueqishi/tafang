namespace ET
{
    [FriendClass(typeof(FightItem))]
    public static class FightItemFactory
    {
        public static FightItem Create(Entity parent, int ConfigId)
        {
            if (!FightItemConfigCategory.Instance.Contain(ConfigId))
            {
                return null;
            }
            FightItem fightitem = parent.AddChild<FightItem, int>(ConfigId);
            return fightitem;
        }
    }
}
