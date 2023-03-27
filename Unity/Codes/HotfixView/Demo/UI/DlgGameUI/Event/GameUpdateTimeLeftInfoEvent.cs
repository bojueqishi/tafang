using ET.EventType;

namespace ET
{
    public class GameUpdateTimeLeftInfoEvent : AEventAsync<EventType.GameUpdateTimeLeftInfo>
    {
        protected override async ETTask Run(GameUpdateTimeLeftInfo args)
        {
            args.zonescene.GetComponent<UIComponent>().GetDlgLogic<DlgGameUI>().UpdateSetGameTimeLeft(args.Time);
            await ETTask.CompletedTask;
        }
    }
}
