using System;
using System.Collections.Generic;

namespace ET
{
    public class C2G_DeleteTowerHandler : AMActorLocationRpcHandler<Unit, C2G_DeleteTower, G2C_DeleteTower>
    {
        protected override async ETTask Run(Unit unit, C2G_DeleteTower request, G2C_DeleteTower response, Action reply)
        {
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.DeleteTower, unit.Id))
            {
                NumericComponent num = unit.GetComponent<NumericComponent>();
                int roomIndex = num.GetAsInt(NumericType.RoomIndex);
                Scene scene = unit.DomainScene();
                GameRoomComponent roomComponent = scene.GetComponent<GameRoomComponent>();
                List<Unit> units = roomComponent.Get(roomIndex);
                G2C_ReturnDeleteTower g2C_ReturnDeleteTower = new G2C_ReturnDeleteTower() { TowerId = request.TowerId };
                for (int i = 0; i < units.Count; i++)
                {
                    Unit currentunit = units[i];
                    MessageHelper.SendToClient(currentunit, g2C_ReturnDeleteTower);
                }
                reply();
                await ETTask.CompletedTask;
            }   
        }
    }
}
