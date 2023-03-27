namespace ET
{
    [FriendClass(typeof(Player))]
    public static class PlayerSystem
    {
        [ObjectSystem]
        public class PlayerAwakeSystem : AwakeSystem<Player, string>
        {
            public override void Awake(Player self, string a)
            {
               
            }
        }
        [ObjectSystem]
        public class PlayerAwake2System : AwakeSystem<Player, long, long>
        {
            public override void Awake(Player self, long AccountId, long serverid)
            {
                self.AccountId = AccountId;
                self.ServerId = serverid;
            }
        }
    }
}