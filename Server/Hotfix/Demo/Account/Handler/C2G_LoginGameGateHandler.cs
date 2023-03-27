using System;

namespace ET
{
    [FriendClass(typeof(SessionPlayerComponent))]
    [FriendClass(typeof(SessionStateComponent))]
    public class C2G_LoginGameGateHandler : AMRpcHandler<C2G_LoginGameGate, G2C_LoginGameGate>
    {
        protected override async ETTask Run(Session session, C2G_LoginGameGate request, G2C_LoginGameGate response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Gate)
            {
                Log.Error("SceneType Error");
                session.Dispose();
                return;
            }

            session.RemoveComponent<SessionAcceptTimeoutComponent>();

            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                reply();
                return;
            }

            Scene scene = session.DomainScene();
            string tokenkey = scene.GetComponent<GateSessionKeyComponent>().Get(request.AccountId);
            if (tokenkey == null || !tokenkey.Equals(request.Key))
            {
                response.Error = ErrorCode.ERR_ConnectGateKeyError;
                response.Message = "Gate Key验证失败";
                reply();
                session?.Disconnect().Coroutine();
                return;
            }

            scene.GetComponent<GateSessionKeyComponent>().Remove(request.AccountId);

            long InstanceId = session.InstanceId;
            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate,request.AccountId.GetHashCode()))
                {
                    if(InstanceId != session.InstanceId)
                    {
                        return;
                    }
                }
                //通知登陆中心服  记录本次账号ID和登陆的服务器
                StartSceneConfig config = StartSceneConfigCategory.Instance.LoginCenterConfig;
                L2G_AddLoginRecord l2G_AddLoginRecord = (L2G_AddLoginRecord)await MessageHelper.CallActor(config.InstanceId, new G2L_AddLoginRecord()
                {
                    AccountId = request.AccountId,
                    ServerId = scene.Zone
                });
                if(l2G_AddLoginRecord.Error != ErrorCode.ERR_Success)
                {
                    response.Error = l2G_AddLoginRecord.Error;
                    reply();
                    session?.Disconnect().Coroutine();
                    return;
                }

                SessionStateComponent SessionStateComponent = session.GetComponent<SessionStateComponent>();
                if(SessionStateComponent == null)
                {
                    SessionStateComponent = session.AddComponent<SessionStateComponent>();
                }
                SessionStateComponent.SessionState = SessionState.Normal;

                Player player = scene.GetComponent<PlayerComponent>().Get(request.AccountId);

                if(player == null)
                {
                    //添加一个GatePlayer

                    player = scene.GetComponent<PlayerComponent>().AddChildWithId<Player, long,long>(request.AccountId, request.AccountId,request.ServerId);
                    player.PlayerState = PlayerState.Gate;
                    scene.GetComponent<PlayerComponent>().Add(player);
                    session.AddComponent<MailBoxComponent, MailboxType>(MailboxType.GateSession);
                }
                else
                {
                    player.RemoveComponent<PlayerOfflineOutTimeComponent>();
                }
                session.AddComponent<SessionPlayerComponent>().PlayerId = player.Id;
                session.GetComponent<SessionPlayerComponent>().PlayerInstanceId = player.InstanceId;
                session.GetComponent<SessionPlayerComponent>().AccountId = request.AccountId;
                player.ClientSession = session;
            }
            reply();
        }
    }
}
