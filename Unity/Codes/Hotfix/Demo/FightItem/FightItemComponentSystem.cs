using System.Collections.Generic;

namespace ET
{
    [FriendClass(typeof(FightItemComponent))]
    [FriendClass(typeof(FightItem))]
    public static class FightItemComponentSystem
    {
        public static void Clear(this FightItemComponent self)
        {
            ForeachHelper.Foreach(self.FightItemDict, (long id, FightItem fightitem) =>
            {
                fightitem?.Dispose();
            });
            self.FightItemDict.Clear();
            self.FightItemsMap.Clear();
        }
        public static void AddFightItem(this FightItemComponent self, FightItem fightitem)//添加战斗单元
        {
            if(self.FightItemDict.ContainsKey(fightitem.Id))//存在id直接返回否则添加
            {
                return;
            }
            self.AddChild(fightitem);
            self.FightItemDict.Add(fightitem.Id, fightitem);
            self.FightItemsMap.Add(fightitem.Config.FightItemType, fightitem);
        }
        public static void AddFightItemTalent(this FightItemComponent self,FightItem fightitem)//点天赋
        {
            if(!self.FightItemDict.ContainsKey(fightitem.Id))
            {
                return;//不存在id
            }
            self.FightItemDict[fightitem.Id] = fightitem;
            foreach(List<FightItem> fightitems in self.FightItemsMap.Values)
            {
                for(int i=0;i<fightitems.Count;i++)
                {
                    FightItem currentfightitem = fightitems[i];
                    if (currentfightitem.Id == fightitem.Id)
                    {
                        self.GetChild<FightItem>(fightitem.Id).Dispose();
                        self.AddChild(fightitem);
                        fightitems[i] = fightitem;
                        break;
                    }
                }
            }
        }
        public static List<int> GetSkillIdByFightItem(this FightItemComponent self,int configid)
        {
            List<int> skillids = new List<int>();
            foreach(FightItem item in self.FightItemDict.Values)
            {
                if(configid - item.ConfigId <= 2)
                {
                    skillids = item.AddedTalent;
                }
            }
            return skillids;
        }
    }
}
