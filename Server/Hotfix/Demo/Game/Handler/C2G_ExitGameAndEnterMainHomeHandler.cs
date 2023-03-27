using System;
using System.Transactions;

namespace ET
{
    public class C2G_ExitGameAndEnterMainHomeHandler : AMActorLocationRpcHandler<Unit, C2G_ExitGameAndEnterMainHome, G2C_ExitGameAndEnterMainHome>
    {
        protected override async ETTask Run(Unit unit, C2G_ExitGameAndEnterMainHome request, G2C_ExitGameAndEnterMainHome response, Action reply)
        {
            NumericComponent numeric = unit.GetComponent<NumericComponent>();
            int MapId = numeric.GetAsInt(NumericType.MapId);
            numeric.Set(NumericType.MapId, 0);
            await numeric.AddOrUpdateUnitCache(UnitHelper.GetUnitServerId(unit));
            reply();    
            StartSceneConfig Map1SceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(unit.DomainZone(), "Map1");
            await TransferHelper.Transfer(unit, Map1SceneConfig.InstanceId, Map1SceneConfig.Name,MapId,0);

        }   
    }
}
