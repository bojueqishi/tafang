namespace ET
{
    public static partial class TimerType
    {
        // 框架层0-1000，逻辑层的timer type从1000起
        public const int WaitTimer = 0;
        public const int SessionIdleChecker = 1;
        public const int ActorLocationSenderChecker = 2;
        public const int ActorMessageSenderChecker = 3;
        public const int PlayerOfflineOutTime = 4;
        public const int GameMoneyAdd = 5;
        public const int TowerAttackTimer = 6;
        public const int OnLogicFrame = 7;
        public const int SaveChangeDBDate = 8;
        // 不能超过1000
    }
}