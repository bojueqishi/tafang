namespace ET
{
    public static class BagHelper
    {
        public static bool AddItemByConfigId(Unit unit,int ConfigId,int count)
        {
            BagComponent bagcomponent = unit.GetComponent<BagComponent>();
            if (bagcomponent == null)
            {
                return false;
            }
            if(!bagcomponent.IsCanAddItemByConfigId(ConfigId))
            {
                return false;
            }
            return bagcomponent.AddItemByConfigId(ConfigId,count);
        }
        public static bool ReduceItemByConfigId(Unit unit,long Uid,int count)
        {
            BagComponent bagcomponent = unit.GetComponent<BagComponent>();
            if (bagcomponent == null)
            {
                return false;
            }
            return bagcomponent.ReduceItemByConfigId(Uid, count);
        }
    }
}
