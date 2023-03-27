using ET.EventType;

namespace ET
{
    public class DisGameUIEvent : AEventAsync<EventType.DisGameUI>
    {
        protected override async ETTask Run(DisGameUI args)
        {
            if (args.ZoneScene.GetComponent<UIComponent>().IsWindowVisible(WindowID.WindowID_Login))
            {
                args.ZoneScene.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Login);
            }
            args.ZoneScene.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_MainHome);
            GlobalComponent.Instance.MainCamera.transform.position = new UnityEngine.Vector3(0, 0, -35.2f);
            args.ZoneScene.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_GameUI);
            await ETTask.CompletedTask;
        }
    }
}
