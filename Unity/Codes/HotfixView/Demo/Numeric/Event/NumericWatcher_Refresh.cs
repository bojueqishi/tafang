namespace ET
{
    [NumericWatcher(NumericType.Level)]
    [NumericWatcher(NumericType.Gold)]
    [NumericWatcher(NumericType.Exp)]
    public class NumericWatcher_Refresh : INumericWatcher
    {
        public void Run(EventType.NumbericChange args)
        {
            //args.Parent.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgHelper>()?.Refresh();
        }
    }
}
