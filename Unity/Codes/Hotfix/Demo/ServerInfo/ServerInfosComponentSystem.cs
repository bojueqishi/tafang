namespace ET
{
    public class ServerInfosComponentDestorySystem : DestroySystem<ServerInfosComponent>
    {
        public override void Destroy(ServerInfosComponent self)
        {
            foreach(var serverinfo in self.ServerInfoList)
            {
                serverinfo.Dispose();
            }
            self.ServerInfoList.Clear();
        }
    }
    [FriendClass(typeof(ServerInfosComponent))]
    public static class ServerInfosComponentSystem 
    {
        public static void Add(this ServerInfosComponent self,ServerInfo serverInfo)
        {
            self.ServerInfoList.Add(serverInfo);
        }
    }
}
