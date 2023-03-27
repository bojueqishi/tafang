using System.Collections.Generic;

namespace ET
{
    [FriendClass(typeof(GameRoomComponent))]
    public class UpLoadFrameIdHandler : AMActorLocationHandler<Unit, UpLoadFrameId>
    {
        protected override async ETTask Run(Unit unit, UpLoadFrameId message)
        {
            Scene scene = unit.DomainScene();
            int roomid = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.RoomIndex);
            GameRoomComponent roomComponent = scene.GetComponent<GameRoomComponent>();
            long logiccomponentid = roomComponent.logics[roomid];
            LogicComponent logiccomponent = roomComponent.GetChild<LogicComponent>(logiccomponentid);
            logiccomponent.AsyncPlayerFrameId(unit, message.frameid);
            await ETTask.CompletedTask;
        }
    }
}
