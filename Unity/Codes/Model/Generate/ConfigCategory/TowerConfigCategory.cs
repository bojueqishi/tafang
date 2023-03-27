using ProtoBuf;
using System.Collections.Generic;

namespace ET
{
    public partial class TowerConfigCategory : ProtoObject, IMerge
    {
        public string GetTowerNameByTowerId(int TowerId)
        {
            TowerConfig towerconfig = TowerConfigCategory.Instance.Get(TowerId);
            return towerconfig.Name;
        }
        public int GetTowerNeedMoneyByTowerId(int TowerId)
        {
            TowerConfig towerconfig = TowerConfigCategory.Instance.Get(TowerId);
            return towerconfig.Price;
        }
    }
}
