using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class C2G_CancelReadyGameHandler : AMActorLocationRpcHandler<Unit, C2G_CancelReadyGame, G2C_CancelReadyGame>
    {
        protected override async ETTask Run(Unit unit, C2G_CancelReadyGame request, G2C_CancelReadyGame response, Action reply)
        {
            NumericComponent n = unit.GetComponent<NumericComponent>();
            n.Set(NumericType.IsReadyGame, 0);
            reply();
            await ETTask.CompletedTask;
        }
    }

}
