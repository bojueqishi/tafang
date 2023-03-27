using System.Collections.Generic;

namespace ET
{
    public class FightItem : Entity,IAwake<int>,IDestroy
    {
        public int ConfigId = 0;

        public List<int> AddedTalent = new List<int>();//已经加的天赋点
        public FightItemConfig Config => FightItemConfigCategory.Instance.Get(ConfigId);
    }
}
