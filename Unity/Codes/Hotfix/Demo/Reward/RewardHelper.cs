
using System.Collections.Generic;

namespace ET
{
    public static class RewardHelper
    {
        public static void AddReward(Unit unit,List<int> ItemId,List<int> ItemNumber)
        {
            NumericComponent num = unit.GetComponent<NumericComponent>();
            for(int i=0;i<ItemId.Count;i++)
            {
                int id = ItemId[i];
                int number = ItemNumber[i];
                switch(id)
                {
                    case 1://游戏金币
                        num.Set(NumericType.Gold,num.GetAsInt(NumericType.Gold) + number);
                        break;
                    case 2://游戏钻石
                        break;
                }
            }
        }
    }
}
