using System;
using System.Collections.Generic;

namespace ET
{
    [FriendClass(typeof(GameRoomComponent))]
    public class C2G_AddGameRoomHandler : AMActorLocationRpcHandler<Unit, C2G_AddGameRoom, G2C_AddGameRoom>
    {
        protected override async ETTask Run(Unit unit, C2G_AddGameRoom request, G2C_AddGameRoom response, Action reply)
        {
            NumericComponent component = unit.GetComponent<NumericComponent>();
            int roomIndex = component.GetAsInt(NumericType.RoomIndex);

            Scene scene = unit.DomainScene();
            GameRoomComponent gameroomcomponent = scene.GetComponent<GameRoomComponent>();

            if (gameroomcomponent.roomstate[roomIndex] == 2)//房间存在已经开始

            {
                List<Unit> units = gameroomcomponent.Get(roomIndex);
                NumericComponent num = unit.GetComponent<NumericComponent>();
                num.Set(NumericType.GameMoney, 1000);
                num.Set(NumericType.IsStartGame, 1);
                num.Set(NumericType.Frameid, 0);
                units.Add(unit);
                gameroomcomponent.Add(roomIndex, units);
                G2C_StartGame g2C_StartGame = new G2C_StartGame();
                MessageHelper.SendToClient(unit, g2C_StartGame);
                reply();
            }
            else if (gameroomcomponent.roomstate[roomIndex] == 1)//房间存在还未开始
            {
                List<Unit> units = gameroomcomponent.Get(roomIndex);
                units.Add(unit);
                gameroomcomponent.Add(roomIndex, units);
                reply();
            }
            else if (gameroomcomponent.roomstate[roomIndex] == 0)//游戏已经结束 下发给玩家游戏结束的消息
            {
                NumericComponent numeric = unit.GetComponent<NumericComponent>();
                int MapId = numeric.GetAsInt(NumericType.MapId);
                numeric.Set(NumericType.RoomIndex, 0);
                numeric.Set(NumericType.IsReadyGame, 0);
                numeric.Set(NumericType.IsStartGame, 0);
                numeric.Set(NumericType.IsInMatch, 0);
                numeric.Set(NumericType.Position, 0);
                numeric.Set(NumericType.GameMoney, 0);
                numeric.Set(NumericType.TowerId1, 0);
                numeric.Set(NumericType.TowerId2, 0);
                numeric.Set(NumericType.TowerId3, 0);
                numeric.Set(NumericType.TowerId4, 0);
                numeric.Set(NumericType.TowerId5, 0);
                numeric.Set(NumericType.TowerId6, 0);
                numeric.Set(NumericType.TowerId7, 0);
                numeric.Set(NumericType.TowerId8, 0);
                numeric.Set(NumericType.MapId, 0);
                numeric.Set(NumericType.MatchMode, 0);
                reply();
                await numeric.AddOrUpdateUnitCache(UnitHelper.GetUnitServerId(unit));      
                StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(unit.DomainZone(), "Map1");
                await TransferHelper.Transfer(unit, startSceneConfig.InstanceId, startSceneConfig.Name, MapId,0);
            }
        }
    }
}
