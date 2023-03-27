namespace ET
{
    [NumericWatcher(NumericType.IsInMatch)]
    public class NumericWatcher_ChangeMatchStatus : INumericWatcher
    {
        public void Run(EventType.NumbericChange args)
        {
            if(args.New == 0)//退出匹配 改变UI
            {

            }
            if(args.New == 1)//进入匹配 改变UI
            {
                
            }
        }
    }
}
