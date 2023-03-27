using System;

namespace ET
{
    public class G2L_RemoveLoginRecordHandler : AMActorRpcHandler<Scene, G2L_RemoveLoginRecord, L2G_RemoveLoginRecord>
    {
        protected override async ETTask Run(Scene scene, G2L_RemoveLoginRecord request, L2G_RemoveLoginRecord response, Action reply)
        {
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginCenterLock,request.AccountId.GetHashCode()))
            {
                int zone = scene.GetComponent<LoginInfoRecordComponent>().Get(request.AccountId);
                if(request.ServerId == zone)
                {
                    scene.GetComponent<LoginInfoRecordComponent>().Remove(request.AccountId);
                }
            }
            reply();

            await ETTask.CompletedTask;
        }
    }
}
