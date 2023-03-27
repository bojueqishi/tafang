namespace ET
{
    public class AccountSessionsComponentDestorySystem : DestroySystem<AccountSessionsComponent>
    {
        public override void Destroy(AccountSessionsComponent self)
        {
            self.AccountSessionDictionary.Clear();    
        }
    }
    [FriendClass(typeof(AccountSessionsComponent))]
    public static class AccountSessionsComponentSystem
    {
        public static long Get(this AccountSessionsComponent self,long accountId)
        {
            if(!self.AccountSessionDictionary.TryGetValue(accountId,out long InstanceId))
            {
                return 0;
            }
            return InstanceId;
        }
        public static void Add(this AccountSessionsComponent self,long accountId,long sessionInstanceId)
        {
            if(self.AccountSessionDictionary.ContainsKey(accountId))
            {
                self.AccountSessionDictionary[accountId] = sessionInstanceId;
                return;
            }
            else
            {
                self.AccountSessionDictionary.Add(accountId, sessionInstanceId);
            }
        }
        public static void Remove(this AccountSessionsComponent self,long accountId)
        {
            if(self.AccountSessionDictionary.ContainsKey(accountId))
            {
                self.AccountSessionDictionary.Remove(accountId);
            }
        }
    }
}
