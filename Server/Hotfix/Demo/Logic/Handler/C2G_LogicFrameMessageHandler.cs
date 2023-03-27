namespace ET
{
    [ActorMessageHandler]
    [FriendClass(typeof(GameRoomComponent))]
    public class C2G_LogicFrameMessageHandler : AMActorLocationHandler<Unit, NextFrameOpts>
    {
        protected override async ETTask Run(Unit unit, NextFrameOpts message)
        {
            Scene scene = unit.DomainScene();
            int roomid = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.RoomIndex);
            GameRoomComponent roomComponent = scene.GetComponent<GameRoomComponent>();
            long logiccomponentid = roomComponent.logics[roomid];
            LogicComponent logiccomponent = roomComponent.GetChild<LogicComponent>(logiccomponentid);
            logiccomponent.AddNextFrameOpt(unit, message);
            await ETTask.CompletedTask;
        }
    }
}
