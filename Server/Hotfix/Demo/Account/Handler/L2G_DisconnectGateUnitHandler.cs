using System;

namespace ET
{
    [ActorMessageHandler]
    [FriendClass(typeof(SessionPlayerComponent))]
    public class L2G_DisconnectGateUnitHandler : AMActorRpcHandler<Scene, L2G_DisconnectGateUnit, G2L_DisconnectGateUnit>
    {
        protected override async ETTask Run(Scene scene, L2G_DisconnectGateUnit request, G2L_DisconnectGateUnit response, Action reply)
        {
            long accountId = request.AccountId;
            using(await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate,accountId.GetHashCode()))
            {
                PlayerComponent playerComponent = scene.GetComponent<PlayerComponent>();
                Player player = playerComponent.Get(accountId);
                if(player == null)
                {
                    reply();
                    return;
                }

                scene.GetComponent<GateSessionKeyComponent>().Remove(accountId);
                Session session = player.ClientSession;
                if(session!= null&&!session.IsDisposed)
                {
                    if(session.GetComponent<SessionPlayerComponent>()!=null)
                    {
                        session.GetComponent<SessionPlayerComponent>().isLoginAgain = true;
                    }
                    session.Send(new A2C_Disconnect(){ Error = ErrorCode.ERR_OtherAccountlogin });
                    session?.Disconnect().Coroutine();
                }
                player.AddComponent<PlayerOfflineOutTimeComponent>();
            }

            await ETTask.CompletedTask;
        }
    }
}
