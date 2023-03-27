namespace ET
{
    public class SceneChangeFinishEvent_CreateUIHelp : AEventAsync<EventType.SceneChangeFinish>
    {
        protected override async ETTask Run(EventType.SceneChangeFinish args)
        {
            //args.CurrentScene.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Helper);
        }
    }
}
