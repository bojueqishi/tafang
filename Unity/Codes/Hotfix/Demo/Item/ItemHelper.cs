namespace ET
{
    [FriendClass(typeof(BagComponent))]
    public static class ItemHelper
    {
        public static async void GetItemFromServer(Scene scene, ItemContainerType containertype)//向服务器获取东西
        {
            scene.GetComponent<SessionComponent>().Session.Call(new C2G_OpItem() { OpType = (int)ItemOp.Add }).Coroutine();
            await ETTask.CompletedTask;
        }
        public static async void ReduceItemFromServer(Scene scene, ItemContainerType containertype)//消耗东西上报服务器
        {
            BagComponent bagcomponent = scene.GetComponent<BagComponent>();
            long id = 0;
            foreach(long k in bagcomponent.ItemDict.Keys)
            {
                id = k;
            }
            scene.GetComponent<SessionComponent>().Session.Call(new C2G_OpItem() { OpType = (int)ItemOp.Reduce,ItemUid = id,ItemNumber = 10 }).Coroutine();
            await ETTask.CompletedTask;
        }




        public static void Clear(Scene scene,ItemContainerType containertype)
        {
            if(containertype == ItemContainerType.Bag)
            {
                scene?.GetComponent<BagComponent>()?.Clear();
            }
        }
        public static void AddItem(Scene zonescene,Item item,ItemContainerType containertype)
        {
            if(containertype == ItemContainerType.Bag)
            {
                zonescene?.GetComponent<BagComponent>()?.AddItem(item);
            }
        }
        public static void ReduceItem(Scene zonescene, Item item, ItemContainerType containertype)
        {
            if (containertype == ItemContainerType.Bag)
            {
                zonescene?.GetComponent<BagComponent>()?.ReduceItem(item);
            }
        }
    }
}
