using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    [FriendClass(typeof(GameRoomComponent))]
    public class C2G_GetReadyGameHandler : AMActorLocationRpcHandler<Unit, C2G_GetReadyGame, G2C_GetReadyGame>
    {
        protected override async ETTask Run(Unit unit, C2G_GetReadyGame request, G2C_GetReadyGame response, Action reply)
        {
            
            NumericComponent n = unit.GetComponent<NumericComponent>();
            int roomindex = n.GetAsInt(NumericType.RoomIndex);
            Scene scene = unit.DomainScene();
            n.Set(NumericType.IsReadyGame, 1);
            await n.AddOrUpdateUnitCache(UnitHelper.GetUnitServerId(unit));
            List<Unit> units = scene.GetComponent<GameRoomComponent>().Get(roomindex);
            bool AllUnitsReady = true;
            for(int i=0;i<units.Count;i++)
            {
                if (units[i] == null) return;
                if (units[i].GetComponent<NumericComponent>().GetAsInt(NumericType.IsReadyGame) == 0)
                {
                    AllUnitsReady = false;
                }
            }
            if(AllUnitsReady)
            {
                for (int i=0;i<units.Count;i++)
                {
                    //向客户端发起开始游戏
                    NumericComponent num = units[i].GetComponent<NumericComponent>();
                    num.Set(NumericType.GameMoney, 1000);
                    num.Set(NumericType.IsStartGame, 1);
                    num.Set(NumericType.Frameid, 0);
                    await num.AddOrUpdateUnitCache(UnitHelper.GetUnitServerId(units[i]));
                    G2C_StartGame g2C_StartGame = new G2C_StartGame();
                    MessageHelper.SendToClient(units[i], g2C_StartGame);
                }
                scene.GetComponent<GameRoomComponent>().roomstate[roomindex] = 2;
                scene.GetComponent<GameRoomComponent>().StartGame(roomindex);

            }
            reply();
            await ETTask.CompletedTask;
        }
    }
    
}
