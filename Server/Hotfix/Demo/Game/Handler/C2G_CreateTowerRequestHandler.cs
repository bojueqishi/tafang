using System;
using System.Collections.Generic;

namespace ET
{
    public class C2G_CreateTowerRequestHandler : AMActorLocationRpcHandler<Unit, C2G_CreateTowerRequest, G2C_CreateTowerResponse>
    {
        protected override async ETTask Run(Unit unit, C2G_CreateTowerRequest request, G2C_CreateTowerResponse response, Action reply)
        {
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.CreateTower, unit.Id))
            {
                int roomIndex = request.RoomIndex;
                Scene scene = unit.DomainScene();
                NumericComponent num = unit.GetComponent<NumericComponent>();
                int position = num.GetAsInt(NumericType.Position);
                GameRoomComponent roomComponent = scene.GetComponent<GameRoomComponent>();
                List<Unit> units = roomComponent.Get(roomIndex);
                G2C_ReturnCreateTowerMessage g2C_ReturnCreateTowerMessage = new G2C_ReturnCreateTowerMessage()
                {
                    TowerConfigId = request.TowerConfigId,
                    TowerId = request.TowerId,
                    TowerPX = request.TowerPX,
                    TowerPY = request.TowerPY,
                    Position = position
                };
                for (int i = 0; i < units.Count; i++)
                {
                    MessageHelper.SendToClient(units[i], g2C_ReturnCreateTowerMessage);
                }
                reply();
                await ETTask.CompletedTask;
            }
        }
    }
}
