using System;

namespace ET
{
    public class C2R_LoginRealmHandler : AMRpcHandler<C2R_LoginRealm, R2C_LoginRealm>
    {
        protected override async ETTask Run(Session session, C2R_LoginRealm request, R2C_LoginRealm response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Realm)
            {
                Log.Error("SceneType Error!!!");
                session.Dispose();
                return;
            }

            Scene domainscene = session.DomainScene();
            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            string Token = session.DomainScene().GetComponent<TokenComponent>().Get(request.AccountId);
            if (Token == null || Token != request.RealmTokenKey)
            {
                response.Error = ErrorCode.ERR_TokenError;
                reply();
                session.Disconnect().Coroutine();
                return;
            }
            domainscene.GetComponent<TokenComponent>().Remove(request.AccountId);
            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginRealm, request.AccountId))
                {
                    StartSceneConfig config = RealmGateAddressHelper.GetGate(domainscene.Zone, request.AccountId);

                    G2R_GetLoginGateKey g2R_GetLoginGateKey = (G2R_GetLoginGateKey)await MessageHelper.CallActor(config.InstanceId, new R2G_GetLoginGateKey()
                    {
                        AccountId = request.AccountId
                    });

                    if(g2R_GetLoginGateKey.Error != ErrorCode.ERR_Success)
                    {
                        response.Error = g2R_GetLoginGateKey.Error;
                        reply();
                        return;
                    }
                    
                    response.GateSessionKey = g2R_GetLoginGateKey.GateSessionKey;
                    response.GateAddress = config.OuterIPPort.ToString();
                    reply();
                    session?.Disconnect().Coroutine();
                }
            }
        }
    }
}
