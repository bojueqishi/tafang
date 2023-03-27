using System;

namespace ET
{
    [FriendClass(typeof(RoleInfo))]
    public class C2A_CreateRoleHandler : AMRpcHandler<C2A_CreteRole, A2C_CreateRole>
    {
        protected override async ETTask Run(Session session, C2A_CreteRole request, A2C_CreateRole response, Action reply)
        {
            if(session.DomainScene().SceneType != SceneType.Account)
            {
                Log.Error("请求Scene错误");
                session.Dispose();
                return;
            }

            if(session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                reply();
                return;
            }

            string token = session.DomainScene().GetComponent<TokenComponent>().Get(request.AccountId);

            if(token == null || token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                reply();
                session?.Disconnect().Coroutine();
                return;
            }

            if(string.IsNullOrEmpty(request.Name))
            {
                response.Error = ErrorCode.ERR_CreateRoleNameError;
                reply();
                return;
            }

            using(session.AddComponent<SessionLockingComponent>())
            {
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.CreateRole, request.AccountId))
                {
                    var roleInfos = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Query<RoleInfo>(d => d.Name == request.Name
                    && d.ServerId == request.ServerId);

                    if (roleInfos != null && roleInfos.Count > 0)
                    {
                        response.Error = ErrorCode.ERR_CreateRoleNameSameError;
                        reply();
                        return;
                    }
                    RoleInfo newroleInfo = session.AddChildWithId<RoleInfo>(IdGenerater.Instance.GenerateUnitId(request.ServerId));
                    newroleInfo.Name = request.Name;
                    newroleInfo.State = (int)RoleInfoState.Normal;
                    newroleInfo.ServerId = request.ServerId;
                    newroleInfo.AccountId = request.AccountId;
                    newroleInfo.CreateTime = TimeHelper.ServerNow();
                    newroleInfo.LastLoginTime = 0;

                    await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Save<RoleInfo>(newroleInfo);
                    response.RoleInfo = newroleInfo.ToMessage();
                    reply();
                    newroleInfo?.Dispose();
                }
            }
        }
    }
}
