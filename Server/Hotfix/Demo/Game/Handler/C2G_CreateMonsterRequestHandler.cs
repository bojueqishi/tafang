using System;
using System.Collections.Generic;

namespace ET
{
    public class C2G_CreateMonsterRequestHandler : AMActorLocationRpcHandler<Unit, C2G_CreateMonsterRequest, G2C_CreateMonsterResponse>
    {
        protected override async ETTask Run(Unit unit, C2G_CreateMonsterRequest request, G2C_CreateMonsterResponse response, Action reply)
        {
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.CreateMonster, unit.Id))
            {
                int roomIndex = request.RoomIndex;

                Scene scene = unit.DomainScene();
                GameRoomComponent roomComponent = scene.GetComponent<GameRoomComponent>();
                List<Unit> units = roomComponent.Get(roomIndex);
                G2C_ReturnCreateMonsterMessage g2C_ReturnCreateMonsterMessage = new G2C_ReturnCreateMonsterMessage()
                {
                    MonsterId = request.MonsterId,
                    Position = request.Position
                };
                for (int i = 0; i < units.Count; i++)
                {
                    MessageHelper.SendToClient(units[i], g2C_ReturnCreateMonsterMessage);
                }
                reply();
                await ETTask.CompletedTask;
            }
           
        }
    }
}
