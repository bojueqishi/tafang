namespace ET
{
    [NumericWatcher(NumericType.GameMoney)]
    public class NumericWatcher_GameMoneyRefresh : INumericWatcher
    {
        public void Run(EventType.NumbericChange args)
        {
            args.Parent.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgGameUI>()?.GameMoneyRefresh();
        }
    }
}
