namespace ET
{
    public class FightItemAwakeSystem : AwakeSystem<FightItem, int>
    {
        public override void Awake(FightItem self, int ConfigId)
        {
            self.ConfigId = ConfigId;
        }
    }
    public class FightItemDestroySystem : DestroySystem<FightItem>
    {
        public override void Destroy(FightItem self)
        {
            self.ConfigId = 0;
            self.AddedTalent.Clear();
        }
    }
    [FriendClass(typeof(FightItem))]
    public static class FightItemSystem
    {
        public static void FromMessage(this FightItem self, FightItemInfo fightiteminfo)
        {
            self.Id = fightiteminfo.FightItemUid;
            self.ConfigId = fightiteminfo.FightItemConfigId;
            self.AddedTalent = fightiteminfo.AddedTalent;
        }
    }
}
