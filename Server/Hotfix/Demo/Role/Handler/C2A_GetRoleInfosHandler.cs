using MongoDB.Driver.Core.Servers;
using System;

namespace ET
{
    [FriendClass(typeof(RoleInfo))]
    public class C2A_GetRoleInfosHandler : AMRpcHandler<C2A_GetRoleInfos, A2C_GetRoleInfos>
    {
        protected override async ETTask Run(Session session, C2A_GetRoleInfos request, A2C_GetRoleInfos response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Account)
            {
                Log.Error("SceneType Error!!!");
                session.Dispose();
                return;
            }

            if(session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            string Token = session.DomainScene().GetComponent<TokenComponent>().Get(request.AccountId);
            if (Token == null || Token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                reply();
                session.Disconnect().Coroutine();
                return;
            }
            using(session.AddComponent<SessionLockingComponent>())
            {
                using(await CoroutineLockComponent.Instance.Wait(CoroutineLockType.CreateRole,request.AccountId))
                {
                    var roleInfoList = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Query<RoleInfo>(d => d.AccountId == request.AccountId && d.ServerId == request.ServerId && d.State == (int)RoleInfoState.Normal);

                    if(roleInfoList.Count == 0 || roleInfoList == null)
                    {
                        reply();
                        return;
                    }

                    foreach (var roleInfo in roleInfoList)
                    {
                        response.RoleInfo.Add(roleInfo.ToMessage());
                        roleInfo?.Dispose();
                    }
                    reply();

                }
            }
        }
    }
}
