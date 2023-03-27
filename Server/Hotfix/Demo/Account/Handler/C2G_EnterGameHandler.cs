using MongoDB.Bson.Serialization.Conventions;
using System;
using System.Net.NetworkInformation;

namespace ET
{
    [FriendClass(typeof(SessionStateComponent))]
    [FriendClass(typeof(SessionPlayerComponent))]
    [FriendClass(typeof(GateMapComponent))]
    public class C2G_EnterGameHandler : AMRpcHandler<C2G_EnterGame, G2C_EnterGame>
    {
        protected override async ETTask Run(Session session, C2G_EnterGame request, G2C_EnterGame response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Gate)
            {
                Log.Error("SceneType Error!!!");
                session.Dispose();
                return;
            }

            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                reply();
                return;
            }

            SessionPlayerComponent sessionPlayerComponent = session.GetComponent<SessionPlayerComponent>();
            if (sessionPlayerComponent == null)
            {
                response.Error = ErrorCode.ERR_SessionPlayerError;
                reply();
                return;
            }
            Player player = Game.EventSystem.Get(sessionPlayerComponent.PlayerInstanceId) as Player;
            if (player == null || player.IsDisposed)
            {
                response.Error = ErrorCode.ERR_NonePlayerError;
                reply();
                return;
            }
            long instanceId = session.InstanceId;
            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate,player.AccountId.GetHashCode()))
                {
                    if(instanceId != session.InstanceId || player.IsDisposed)
                    {
                        response.Error = ErrorCode.ERR_PlayerSessionError;
                        reply();
                        return;
                    }
                    if(session.GetComponent<SessionStateComponent>() != null && session.GetComponent<SessionStateComponent>().SessionState == SessionState.Game)
                    {
                        response.Error = ErrorCode.ERR_SessionStateError;
                        reply();
                        return;
                    }

                    if(player.PlayerState == PlayerState.Game)
                    {
                        try
                        {
                            IActorResponse reqEnter = await MessageHelper.CallLocationActor(player.AccountId,new G2M_RequestEnterGameState(){ });
                            if(reqEnter.Error == ErrorCode.ERR_Success)
                            {
                                reply();
                                return;
                            }
                            Log.Error("二次登陆失败");
                            response.Error = ErrorCode.ERR_ReEnterGameError;
                            await DisconnectHelper.KickPlayer(player, true);
                            reply();
                            session?.Disconnect().Coroutine();
                        }
                        catch(Exception e)
                        {
                            Log.Error(e.ToString());
                            response.Error = ErrorCode.ERR_ReEnterGameError;
                            await DisconnectHelper.KickPlayer(player, true);
                            reply();
                            session?.Disconnect().Coroutine();
                            throw;
                        }
                        return;
                    }
                    try
                    {
                        /*GateMapComponent gateMapComponent = player.AddComponent<GateMapComponent>();
                        gateMapComponent.Scene = await SceneFactory.Create(gateMapComponent, "GateMap", SceneType.Map);

                        Unit unit = UnitFactory.Create(gateMapComponent.Scene, player.Id, UnitType.Player);*/
                        (bool isNewPlayer, Unit unit) = await UnitHelper.LoadUnit(player);
                        unit.AddComponent<UnitGateComponent, long>(player.InstanceId);
                        await UnitHelper.InitUnit(unit, isNewPlayer);
                        player.AccountId = unit.Id;
                        response.MyId = unit.Id;
                        reply();

                        NumericComponent numeric = unit.GetComponent<NumericComponent>();
                        if (numeric.GetAsInt(NumericType.RoomIndex) == 0)
                        {
                            if(numeric.GetAsInt(NumericType.MapId) != 0)//游戏结束后没返回大厅 直接退出MapId则不为0 需要归0
                            {
                                numeric.Set(NumericType.MapId,0);
                            }
                            await numeric.AddOrUpdateUnitCache(UnitHelper.GetUnitServerId(unit));
                            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), "Map1");
                            await TransferHelper.Transfer(unit, startSceneConfig.InstanceId, startSceneConfig.Name, numeric.GetAsInt(NumericType.MapId),numeric.GetAsInt(NumericType.MatchMode));
                        }
                        else//房间不为0
                        {
                            //请求断线重连
                            StartSceneConfig GameScene = StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), "Game");
                            await TransferHelper.Transfer(unit, GameScene.InstanceId, GameScene.Name, numeric.GetAsInt(NumericType.MapId),numeric.GetAsInt(NumericType.MatchMode));
                        }
                        

                        SessionStateComponent sessionStateComponent = session.GetComponent<SessionStateComponent>();
                        if(sessionStateComponent == null)
                        {
                            sessionStateComponent = session.AddComponent<SessionStateComponent>();
                        }
                        sessionStateComponent.SessionState = SessionState.Game;
                        player.PlayerState = PlayerState.Game;
                    }
                    catch(Exception e)
                    {
                        Log.Error(e.ToString());
                        response.Error = ErrorCode.ERR_EnterGameError;
                        reply();
                        await DisconnectHelper.KickPlayer(player, true);
                        session.Disconnect().Coroutine();
                    }
                }
            }

            await ETTask.CompletedTask;
        }
    }
}
