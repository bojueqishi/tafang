namespace ET
{
    [FriendClass(typeof(FightItemComponent))]
    public static class FightItemHelper
    {
        public static void Clear(Scene scene)
        {
            scene?.GetComponent<FightItemComponent>().Clear();  
        }
        public static void AddFightItem(Scene zonescene, FightItem fightitem)
        {
            zonescene?.GetComponent<FightItemComponent>()?.AddFightItem(fightitem);       
        }
        public static void AddFightItemTalent(Scene zonescene,FightItem fightitem)
        {
            zonescene?.GetComponent<FightItemComponent>()?.AddFightItemTalent(fightitem);          
        }
    }
}
