namespace ET
{
    public class Item : Entity,IAwake<int>,IDestroy
    {
        public int ConfigId = 0;
        public int ItemNumber = 0;
        public ItemConfig Config => ItemConfigCategory.Instance.Get(ConfigId);
    }
}
