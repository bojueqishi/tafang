namespace ET
{
    public static class FightItemHelper
    {
        public static bool AddFightItemByConfigId(Unit unit, int ConfigId)
        {
            FightItemComponent fightitemcomponent = unit.GetComponent<FightItemComponent>();
            if (fightitemcomponent == null)
            {
                return false;
            }
            if (!fightitemcomponent.IsCanAddFightItemByConfigId(ConfigId))
            {
                return false;
            }
            return fightitemcomponent.AddFightItemByConfigId(ConfigId,true);
        }
        public static bool AddFightItemTalentByConfigId(Unit unit, long Uid, int TalentConfigId)
        {
            FightItemComponent fightitemcomponent = unit.GetComponent<FightItemComponent>();
            if (fightitemcomponent == null)
            {
                return false;
            }
            if (!fightitemcomponent.IsCanAddFightItemTalentByConfigId(TalentConfigId))
            {
                return false;
            }
            return fightitemcomponent.AddFightItemTalent(Uid, TalentConfigId);
        }
    }
}
