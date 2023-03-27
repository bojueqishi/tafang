namespace ET
{
    public class C2G_OpFightItemHandler : AMActorLocationHandler<Unit, C2G_OpFightItem>
    {
        protected override async ETTask Run(Unit unit, C2G_OpFightItem message)
        {
            switch (message.OpType)
            {
                case (int)FightItemOp.Add:
                    if (!FightItemHelper.AddFightItemByConfigId(unit, 3001))//传进来的物品configid和物品的数量 目前只有道具
                    {
                        Log.Error("no");
                    }
                    break;
                case (int)FightItemOp.AddTalent:
                    if (!FightItemHelper.AddFightItemTalentByConfigId(unit, message.FightItemUid, message.TalentConfigId))
                    {
                        Log.Error("no");
                    }
                    break;
            }
            await ETTask.CompletedTask;
        }
    }
}
