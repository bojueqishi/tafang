namespace ET
{
    [FriendClass(typeof(ServerInfo))]
    public static class ServerInfoSystem 
    {
        public static void FromMessage(this ServerInfo self,ServerInfoProto serverinfo)
        {
            self.Id = serverinfo.Id;
            self.Status = serverinfo.Status;
            self.ServerName = serverinfo.ServerName;
        }

        public static ServerInfoProto ToMessage(this ServerInfo self)
        {
            return new ServerInfoProto() { Id = (int)self.Id, Status = self.Status, ServerName = self.ServerName };
        }
    }
}
