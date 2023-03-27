namespace ET
{
    public class C2G_OpItemHandler : AMActorLocationHandler<Unit, C2G_OpItem>
    {
        protected override async ETTask Run(Unit unit, C2G_OpItem message)
        {
            switch (message.OpType)
            {
                case (int)ItemOp.Add:
                    if (!BagHelper.AddItemByConfigId(unit, 2, 100))//传进来的物品configid和物品的数量 目前只有道具
                    {
                        Log.Error("no");
                    }
                    break;
                case (int)ItemOp.Reduce:
                    if (!BagHelper.ReduceItemByConfigId(unit, message.ItemUid, message.ItemNumber))
                    {
                        Log.Error("no");
                    }
                    break;
            }
            await ETTask.CompletedTask;
        }
    }
}
