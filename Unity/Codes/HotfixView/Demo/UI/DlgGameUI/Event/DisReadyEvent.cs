using ET.EventType;

namespace ET
{
    public class DisReadyEvent : AEventAsync<EventType.DisReadyAndShowWindow>
    {
        protected override async ETTask Run(DisReadyAndShowWindow args)
        {
            args.scene.GetComponent<UIComponent>().GetDlgLogic<DlgGameUI>().DisReadyAndShowWindow();
            await ETTask.CompletedTask;
        }
    }
}
