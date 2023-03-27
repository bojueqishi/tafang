namespace ET
{
    public class AccountInfoComponentDestorySystem : DestroySystem<AccountInfoComponent>
    {
        public override void Destroy(AccountInfoComponent self)
        {
            self.Token = string.Empty;
            self.AccountId = 0;
        }
    }
    public class AccountInfoComponentAwakeSystem : AwakeSystem<AccountInfoComponent>
    {
        public override void Awake(AccountInfoComponent self)
        {
           
        }
    }
    public static class AccountInfoComponentSystem
    {
    }
}
