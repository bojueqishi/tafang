using System;
using System.Collections.Generic;

namespace ET
{
    [FriendClass(typeof(MatchComponent))]
    [FriendClass(typeof(GameRoomComponent))]
    public class C2M_EnterMatchHandler : AMActorLocationRpcHandler<Unit, C2M_EnterMatch, M2C_EnterMatch>
    {
        protected override async ETTask Run(Unit unit, C2M_EnterMatch request, M2C_EnterMatch response, Action reply)
        {
            NumericComponent component = unit.GetComponent<NumericComponent>();

            if(component.GetAsInt(NumericType.RoomIndex) != 0)
            {
                response.Error = ErrorCode.ERR_RoomIndexError;
                reply();
                return;
            }

            if(component.GetAsInt(NumericType.IsInMatch) != 0)
            {
                response.Error = ErrorCode.ERR_IsInGameError;
                reply();
                return;
            }

            Scene scene = unit.DomainScene();
            MatchComponent matchcomponent = scene.GetComponent<MatchComponent>();

            if(request.MatchMode == 1)//Mode=1单机模式
            {
                matchcomponent.CurrentMatch++;//房间号++
                int MapId = request.MapId;
                NumericComponent n = unit.GetComponent<NumericComponent>();
                n.Set(NumericType.RoomIndex, matchcomponent.CurrentMatch);
                n.Set(NumericType.MapId, MapId);
                n.Set(NumericType.IsInMatch, 0);
                n.Set(NumericType.Position, 1);
                n.Set(NumericType.TowerId1, 3001);
                n.Set(NumericType.TowerId2, 3004);
                n.Set(NumericType.TowerId3, 3007);
                n.Set(NumericType.TowerId4, 3010);
                n.Set(NumericType.TowerId5, 3013);
                n.Set(NumericType.TowerId6, 3016);
                n.Set(NumericType.TowerId7, 3019);
                n.Set(NumericType.TowerId8, 3022);
                n.Set(NumericType.Monster1, 4001);
                n.Set(NumericType.Monster2, 4002);
                n.Set(NumericType.Monster3, 4003);
                n.Set(NumericType.Monster4, 4004);
                n.Set(NumericType.Monster5, 4005);
                n.Set(NumericType.Monster6, 4006);
                n.Set(NumericType.Monster7, 4007);
                n.Set(NumericType.Monster8, 4008);
                n.Set(NumericType.Frameid, 0);
                n.Set(NumericType.MatchMode, 1);
                await n.AddOrUpdateUnitCache(UnitHelper.GetUnitServerId(unit));
                M2G_ChangeRoomState m2G_ChangeRoomState = new M2G_ChangeRoomState() { RoomIndex = matchcomponent.CurrentMatch, State = 1 };
                StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(unit.DomainZone(), "Game");
                await MessageHelper.CallActor(startSceneConfig.InstanceId, m2G_ChangeRoomState);
                await TransferHelper.Transfer(unit, startSceneConfig.InstanceId, startSceneConfig.Name, MapId,request.MatchMode);
            }
            if(request.MatchMode == 2)//Mode=2匹配模式
            {
                component.Set(NumericType.IsInMatch, 1);
                matchcomponent.Add(unit);
                if (matchcomponent.MatchUnits.Count >= 2)//匹配成功  获取Unit
                {
                    List<Unit> units = new List<Unit>();
                    matchcomponent.CurrentMatch++;
                    //抽取MapId
                    int MapId = 1;
                    for (int i = 1; i >= 0; i--)
                    {
                        Unit u = matchcomponent.MatchUnits[i];
                        NumericComponent n = u.GetComponent<NumericComponent>();
                        n.Set(NumericType.RoomIndex, matchcomponent.CurrentMatch);
                        n.Set(NumericType.MapId, MapId);
                        n.Set(NumericType.IsInMatch, 0);
                        n.Set(NumericType.Position, i + 1);
                        n.Set(NumericType.TowerId1, 3001);
                        n.Set(NumericType.TowerId2, 3004);
                        n.Set(NumericType.TowerId3, 3007);
                        n.Set(NumericType.TowerId4, 3010);
                        n.Set(NumericType.TowerId5, 3013);
                        n.Set(NumericType.TowerId6, 3016);
                        n.Set(NumericType.TowerId7, 3019);
                        n.Set(NumericType.TowerId8, 3022);
                        n.Set(NumericType.Monster1, 4001);
                        n.Set(NumericType.Monster2, 4002);
                        n.Set(NumericType.Monster3, 4003);
                        n.Set(NumericType.Monster4, 4004);
                        n.Set(NumericType.Monster5, 4005);
                        n.Set(NumericType.Monster6, 4006);
                        n.Set(NumericType.Monster7, 4007);
                        n.Set(NumericType.Monster8, 4008);
                        n.Set(NumericType.Frameid, 0);
                        n.Set(NumericType.MatchMode, 2);
                        await n.AddOrUpdateUnitCache(UnitHelper.GetUnitServerId(u));
                        units.Add(u);
                        matchcomponent.Remove(u);

                        M2G_ChangeRoomState m2G_ChangeRoomState = new M2G_ChangeRoomState() { RoomIndex = matchcomponent.CurrentMatch, State = 1 };
                        StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(u.DomainZone(), "Game");
                        await MessageHelper.CallActor(startSceneConfig.InstanceId, m2G_ChangeRoomState);
                        await TransferHelper.Transfer(u, startSceneConfig.InstanceId, startSceneConfig.Name, MapId,request.MatchMode);
                    }
                }
            }
            response.MatchMode = request.MatchMode;
            reply();
            await ETTask.CompletedTask;
        }
    }
}
