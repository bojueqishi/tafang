using ET.EventType;

namespace ET
{
    public class ViewGameUIEvent : AEventAsync<EventType.ViewGameUI>
    {
        protected override async ETTask Run(ViewGameUI args)
        {
            args.CurrentScene.AddComponent<NavVector>();
            args.CurrentScene.AddComponent<FlyDamageValueViewComponent>();
            if (args.ZoneScene.GetComponent<UIComponent>().IsWindowVisible(WindowID.WindowID_Login))
            {
                args.ZoneScene.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Login);
            }
            if (args.ZoneScene.GetComponent<UIComponent>().IsWindowVisible(WindowID.WindowID_MainHome))
            {
                args.ZoneScene.GetComponent<UIComponent>().HideWindow(WindowID.WindowID_MainHome);
            }
            args.ZoneScene.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_GameUI);
            if(args.MatchMode == 1)
            {
                args.ZoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgGameUI>().SingleModeHide();
            }
            Unit unit = UnitHelper.GetMyUnitFromCurrentScene(args.CurrentScene);
            NumericComponent numeric = unit.GetComponent<NumericComponent>();
            //args.ZoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgGameUI>().ShowWindow();
            if (numeric.GetAsInt(NumericType.IsStartGame) == 1)//加载游戏数据
            {
                args.ZoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgGameUI>().DisReadyAndShowWindow();
            }
            else//还未进入游戏
            {
                if(numeric.GetAsInt(NumericType.IsReadyGame) == 1)//如果已经准备
                {
                    args.ZoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgGameUI>().GetReady();
                }
            }
            
            await ETTask.CompletedTask;
        }
    }
}
