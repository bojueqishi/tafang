using System;
using System.Xml.Linq;


namespace ET
{

    [FriendClass(typeof(AccountInfoComponent))]
    [FriendClass(typeof(ServerInfosComponent))]
    [FriendClass(typeof(RoleInfosComponent))]
    [FriendClass(typeof(RoleInfo))]
    public static class LoginHelper
    {
        public static async ETTask<int> Login(Scene zoneScene, string address, string account, string password)
        {
            A2C_LoginAccount a2CLoginAccount = null;
            Session accountsession = null;
            try
            {
                accountsession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address));
                password = MD5Helper.StringMD5(password);
                a2CLoginAccount = (A2C_LoginAccount) await accountsession.Call(new C2A_LoginAccount() { AccountName = account, Password = password });
            }
            catch(Exception e)
            {
                accountsession?.Dispose();
                return ErrorCode.ERR_NetWorkError;
            }
            if(a2CLoginAccount.Error != ErrorCode.ERR_Success)
            {
                accountsession?.Dispose();
                return a2CLoginAccount.Error;
            }

            zoneScene.AddComponent<SessionComponent>().Session = accountsession;
            zoneScene.GetComponent<SessionComponent>().Session.AddComponent<PingComponent>();
            
            zoneScene.GetComponent<AccountInfoComponent>().Token = a2CLoginAccount.Token;
            zoneScene.GetComponent<AccountInfoComponent>().AccountId = a2CLoginAccount.AccountId;

            return ErrorCode.ERR_Success;
        } 
        public static async ETTask<int> GetServerInfos(Scene zoneScene)
        {
            A2C_GetServerInfos a2C_GetServerInfos = null;
            try
            {
                a2C_GetServerInfos = (A2C_GetServerInfos)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_GetServerInfos() 
                { 
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId, 
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token
                });
            }
            catch(Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if(a2C_GetServerInfos.Error != ErrorCode.ERR_Success)
            {
                return a2C_GetServerInfos.Error;
            }

            foreach(var serverproto in a2C_GetServerInfos.ServerInfoList)
            {
                ServerInfo serverinfo = zoneScene.GetComponent<ServerInfosComponent>().AddChild<ServerInfo>();
                serverinfo.FromMessage(serverproto);
                zoneScene.GetComponent<ServerInfosComponent>().Add(serverinfo);
            }

            return ErrorCode.ERR_Success;
        }
        public static async ETTask<int> CreateRole(Scene zoneScene,string name)
        {
            A2C_CreateRole a2C_CreateRole = null;
            try
            {
                a2C_CreateRole = (A2C_CreateRole)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_CreteRole()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    Name = name,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurrentServerId, 
                });
            }
            catch(Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if(a2C_CreateRole.Error != ErrorCode.ERR_Success)
            {
                Log.Error(a2C_CreateRole.Error.ToString());
                return a2C_CreateRole.Error;
            }

            RoleInfo newroleInfo = zoneScene.GetComponent<RoleInfosComponent>().AddChild<RoleInfo>();
            newroleInfo.FromMessage(a2C_CreateRole.RoleInfo);
            zoneScene.GetComponent<RoleInfosComponent>().RoleInfos.Add(newroleInfo);

            return ErrorCode.ERR_Success;
        }
        public static async ETTask<int> GetRoleInofs(Scene zoneScene)
        {
            A2C_GetRoleInfos a2C_GetRoleInfos = null;
            try
            {
                a2C_GetRoleInfos = (A2C_GetRoleInfos)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_GetRoleInfos()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurrentServerId,
                });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if (a2C_GetRoleInfos.Error != ErrorCode.ERR_Success)
            {
                Log.Error(a2C_GetRoleInfos.Error.ToString());
                return a2C_GetRoleInfos.Error;
            }

            zoneScene.GetComponent<RoleInfosComponent>().RoleInfos.Clear();
            if(a2C_GetRoleInfos.RoleInfo != null && a2C_GetRoleInfos.RoleInfo.Count > 0)
            {
                foreach (var roleInfo in a2C_GetRoleInfos.RoleInfo)
                {
                    RoleInfo roleinfo = zoneScene.GetComponent<RoleInfosComponent>().AddChild<RoleInfo>();
                    roleinfo.FromMessage(roleInfo);
                    zoneScene.GetComponent<RoleInfosComponent>().RoleInfos.Add(roleinfo);
                }
            }
            
            return ErrorCode.ERR_Success;
        }
        public static async ETTask<int> DeleteRole(Scene zoneScene)
        {
            A2C_DeleteRole a2C_DeleteRole = null;
            try
            {
                a2C_DeleteRole = (A2C_DeleteRole)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_DeleteRole()
                {
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    RoleName = zoneScene.GetComponent<RoleInfosComponent>().RoleInfos[zoneScene.GetComponent<RoleInfosComponent>().CurrentRoleId-1].Name,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurrentServerId
                }) ;
            }
            catch(Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError; 
            }

            if(a2C_DeleteRole.Error != ErrorCode.ERR_Success)
            {
                Log.Error(a2C_DeleteRole.Error.ToString());
                return a2C_DeleteRole.Error;
            }

            int index = zoneScene.GetComponent<RoleInfosComponent>().RoleInfos.FindIndex((info) => { return info.Id == a2C_DeleteRole.DeleteRoleInfoId;  });
            zoneScene.GetComponent<RoleInfosComponent>().RoleInfos.RemoveAt(index);
            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }
        public static async ETTask<int> GetRealmKey(Scene zoneScene)
        {
            A2C_GetRealmKey a2C_GetRealmKey = null;
            try
            {
                a2C_GetRealmKey = (A2C_GetRealmKey)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_GetRealmKey()
                {
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    ServerId = zoneScene.DomainZone()
                });
            }
            catch(Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if(a2C_GetRealmKey.Error != ErrorCode.ERR_Success)
            {
                Log.Error(a2C_GetRealmKey.Error.ToString());
                return a2C_GetRealmKey.Error;
            }
            zoneScene.GetComponent<AccountInfoComponent>().RealmKey = a2C_GetRealmKey.RealmKey;
            zoneScene.GetComponent<AccountInfoComponent>().RealmAddress = a2C_GetRealmKey.RealmAddress;
            zoneScene.GetComponent<SessionComponent>().Session.Dispose();
            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }
        public static async ETTask<int> EnterGame(Scene zoneScene)
        {
            string realmAddress = zoneScene.GetComponent<AccountInfoComponent>().RealmAddress;
            //连接Realm
            R2C_LoginRealm r2C_LoginRealm = null;
            Session session = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(realmAddress));
            try
            {
                r2C_LoginRealm = (R2C_LoginRealm)await session.Call(new C2R_LoginRealm()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    RealmTokenKey = zoneScene.GetComponent<AccountInfoComponent>().RealmKey
                });
            }
            catch(Exception e)
            {
                Log.Error(e.ToString());
                session?.Dispose();
                return ErrorCode.ERR_NetWorkError;
            }
            session?.Dispose();

            if(r2C_LoginRealm.Error != ErrorCode.ERR_Success)
            {
                return r2C_LoginRealm.Error;
            }

            Session gatesession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(r2C_LoginRealm.GateAddress));
            gatesession.AddComponent<PingComponent>();
            zoneScene.GetComponent<SessionComponent>().Session = gatesession;
            //连接Gate
            G2C_LoginGameGate g2C_LoginGameGate = null;
            try
            {
                g2C_LoginGameGate = (G2C_LoginGameGate)await gatesession.Call(new C2G_LoginGameGate()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    RoleId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Key = r2C_LoginRealm.GateSessionKey,
                    ServerId = zoneScene.DomainZone()
                });
            }
            catch(Exception e)
            {
                Log.Error(e.ToString());
                zoneScene.GetComponent<SessionComponent>().Session.Dispose();
                return ErrorCode.ERR_NetWorkError;
            }
            if(g2C_LoginGameGate.Error != ErrorCode.ERR_Success)
            {
                zoneScene.GetComponent<SessionComponent>().Session.Dispose();
                return g2C_LoginGameGate.Error;
            }
            //角色请求进入游戏逻辑服
            G2C_EnterGame g2C_EnterGame = null;
            try
            {
                g2C_EnterGame = (G2C_EnterGame)await gatesession.Call(new C2G_EnterGame() { });
            }
            catch(Exception e)
            {
                Log.Error(e.ToString());
                zoneScene.GetComponent<SessionComponent>().Session.Dispose();
                return ErrorCode.ERR_NetWorkError;
            }
            if(g2C_EnterGame.Error != ErrorCode.ERR_Success)
            {
                Log.Error(g2C_EnterGame.Error.ToString());
                return g2C_EnterGame.Error;
            }
            zoneScene.GetComponent<PlayerComponent>().MyId = g2C_EnterGame.MyId;
            await zoneScene.GetComponent<ObjectWait>().Wait<WaitType.Wait_SceneChangeFinish>();   
            return ErrorCode.ERR_Success;
        }
    }
}