using System;
using System.Collections.Generic;

namespace ET
{
    public class C2G_WinGameHandler : AMActorLocationRpcHandler<Unit, C2G_WinGame, G2C_WinGame>
    {
        protected override async ETTask Run(Unit unit, C2G_WinGame request, G2C_WinGame response, Action reply)
        {
            int roomIndex = request.RoomIndex;
            int position = request.Position;
            Scene scene = unit.DomainScene();
            if(scene.GetComponent<GameRoomComponent>().GetRoomState(roomIndex) != 0)
            {
                scene.GetComponent<GameRoomComponent>().SetRoomState(roomIndex, 0);
                List<Unit> units = scene.GetComponent<GameRoomComponent>().Get(roomIndex);
                long WinUnitId = 0;
                for (int i = 0; i < units.Count; i++)
                {
                    Unit currentunit = units[i];
                    if (currentunit.GetComponent<NumericComponent>().GetAsInt(NumericType.Position) == position)
                    {
                        WinUnitId = currentunit.Id;
                    }
                }
                //奖励

                //获胜奖励
                List<int> WinItemId = new List<int>();
                WinItemId.Add(1);
                List<int> WinItemNumber = new List<int>();
                WinItemNumber.Add(200);
                //失败奖励
                List<int> FailItemId = new List<int>();
                FailItemId.Add(1);
                List<int> FailItemNumber = new List<int>();
                FailItemNumber.Add(100);

                G2C_ReturnWinGame g2C_ReturnWinGame = new G2C_ReturnWinGame()
                {
                    WinUnitId = WinUnitId,
                    WinItemId = WinItemId,
                    WinItemNumber = WinItemNumber,
                    FailItemId = FailItemId,
                    FailItemNumber = FailItemNumber
                };
                for (int i = 0; i < units.Count; i++)
                {
                    Unit currentunit = units[i];
                    NumericComponent num = currentunit.GetComponent<NumericComponent>();
                    num.Set(NumericType.RoomIndex, 0);
                    num.Set(NumericType.IsReadyGame, 0);
                    num.Set(NumericType.IsStartGame, 0);
                    num.Set(NumericType.IsInMatch, 0);
                    num.Set(NumericType.Position, 0);
                    num.Set(NumericType.GameMoney, 0);
                    num.Set(NumericType.MatchMode, 0);
                    //下发奖励
                    if (WinUnitId == currentunit.Id)
                    {
                        RewardHelper.AddReward(currentunit, WinItemId, WinItemNumber);
                    }
                    else
                    {
                        RewardHelper.AddReward(currentunit, FailItemId, FailItemNumber);
                    }
                    MessageHelper.SendToClient(currentunit, g2C_ReturnWinGame);
                    await num.AddOrUpdateUnitCache(UnitHelper.GetUnitServerId(currentunit));
                }
                scene.GetComponent<GameRoomComponent>().ClearRoomUnit(roomIndex);
                reply();
                return;
            }
            reply();
            await ETTask.CompletedTask;
        }
    }
}
