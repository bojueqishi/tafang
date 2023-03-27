using MongoDB.Driver.Core.Servers;

namespace ET
{
    public class ServerInfoManagerComponentAwakeSystem : AwakeSystem<ServerInfoManagerComponent>
    {
        public override void Awake(ServerInfoManagerComponent self)
        {
            self.Awake().Coroutine();
        }
    }
    public class ServerInfoManagerComponentDestroySystem : DestroySystem<ServerInfoManagerComponent>
    {
        public override void Destroy(ServerInfoManagerComponent self)
        {
            foreach(var serverInfo in self.ServerInfoList)
            {
                serverInfo?.Dispose();
            }
            self.ServerInfoList.Clear();
        }
    }
    public class ServerInfoManagerComponentLoadSystem : LoadSystem<ServerInfoManagerComponent>
    {
        public override void Load(ServerInfoManagerComponent self)
        {
            self.Awake().Coroutine();
        }
    }
    [FriendClass(typeof(ServerInfoManagerComponent))]
    [FriendClass(typeof(ServerInfo))]
    public static class ServerInfoManagerComponentSystem
    {
        public static async ETTask Awake(this ServerInfoManagerComponent self)
        {
            var serverInfolist = await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Query<ServerInfo>(d => true);

            if(serverInfolist == null || serverInfolist.Count <= 0)
            {
                Log.Error("serverInfo count is zero");
                self.ServerInfoList.Clear();
                var serverInfoConfigs = ServerInfoConfigCategory.Instance.GetAll();

                foreach(var serverInfo in serverInfoConfigs.Values)
                {
                    ServerInfo newserverInfo = self.AddChildWithId<ServerInfo>(serverInfo.Id);
                    newserverInfo.ServerName = serverInfo.ServerName;
                    newserverInfo.Status = (int)ServerStatus.Normal;
                    self.ServerInfoList.Add(newserverInfo);
                    await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Save(newserverInfo);
                }

                return;
            }

            self.ServerInfoList.Clear();

            foreach(var serverInfo in serverInfolist)
            {
                self.AddChild(serverInfo);
                self.ServerInfoList.Add(serverInfo);
            }

            await ETTask.CompletedTask;
        }
    }
}
