using System;

namespace ET
{
    [FriendClass(typeof(GameRoomComponent))]
    public class M2G_ChangeRoomStateHandler : AMActorRpcHandler<Scene, M2G_ChangeRoomState, G2M_ChangeRoomState>
    {
        protected override async ETTask Run(Scene scene, M2G_ChangeRoomState request, G2M_ChangeRoomState response, Action reply)
        {
            GameRoomComponent gameroomcomponent = scene.GetComponent<GameRoomComponent>();
            gameroomcomponent.roomstate[request.RoomIndex] = request.State;
            reply();
            await ETTask.CompletedTask;
        }
    }
}
