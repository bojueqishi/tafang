using System;
using System.Collections.Generic;

namespace ET
{
    [FriendClass(typeof(GameRoomComponent))]
    public class G2M_RequestExitGameHandler : AMActorLocationRpcHandler<Unit, G2M_RequestExitGame, M2G_RequestExitGame>
    {
        protected override async ETTask Run(Unit unit, G2M_RequestExitGame request, M2G_RequestExitGame response, Action reply)
        {
            reply();
            await unit.RemoveLocation();
            NumericComponent num = unit.GetComponent<NumericComponent>();
            num.SetNoEvent(NumericType.Frameid, 0);
            if (num.GetAsInt(NumericType.IsInMatch) != 0) num.SetNoEvent(NumericType.IsInMatch, 0);
            MatchComponent matchcomponent = unit.DomainScene().GetComponent<MatchComponent>();
            if(matchcomponent != null)
            {
                matchcomponent.Remove(unit);
            }
            GameRoomComponent gameRoomComponent = unit.DomainScene().GetComponent<GameRoomComponent>(); 
            if(gameRoomComponent != null)
            {   
                gameRoomComponent.RemoveUnit(num.GetAsInt(NumericType.RoomIndex),unit);
                List<Unit> units = gameRoomComponent.Get(num.GetAsInt(NumericType.RoomIndex));
                if(units.Count == 0)
                {
                    gameRoomComponent.roomstate[num.GetAsInt(NumericType.RoomIndex)] = 0;
                }
            }
            //保存数据库
            unit.GetComponent<UnitSaveDBComponent>()?.SaveChange();
            UnitComponent unitcomponent = unit.DomainScene().GetComponent<UnitComponent>();
            unitcomponent.Remove(unit.Id);
            
            await ETTask.CompletedTask;
        }
    }
}
