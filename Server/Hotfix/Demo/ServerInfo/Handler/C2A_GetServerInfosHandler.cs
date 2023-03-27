using System;

namespace ET
{
    [FriendClass(typeof(ServerInfoManagerComponent))]
    public class C2A_GetServerInfosHandler : AMRpcHandler<C2A_GetServerInfos, A2C_GetServerInfos>
    {
        protected override async ETTask Run(Session session, C2A_GetServerInfos request, A2C_GetServerInfos response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Account)
            {
                Log.Error("SceneType Error!!!");
                session.Dispose();
                return;
            }
            string Token = session.DomainScene().GetComponent<TokenComponent>().Get(request.AccountId);
            if (Token == null || Token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                reply();
                session.Disconnect().Coroutine();
            }
            foreach (var serverInfo in session.DomainScene().GetComponent<ServerInfoManagerComponent>().ServerInfoList)
            {
                response.ServerInfoList.Add(serverInfo.ToMessage());
            }
            reply();

            await ETTask.CompletedTask;
        }
    }
}
