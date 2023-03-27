using ET.EventType;

namespace ET
{
    public class ShowGameResultEvent : AEventAsync<EventType.ShowGameResult>
    {
        protected override async ETTask Run(ShowGameResult args)
        {
            Scene zonescene = args.zonescene;
            zonescene.GetComponent<UIComponent>().GetDlgLogic<DlgGameUI>().ShowResultUI(args.Result,args.ItemId,args.ItemNumber);
            await ETTask.CompletedTask;
        }
    }
}
