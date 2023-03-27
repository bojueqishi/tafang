using ET.EventType;
namespace ET
{
    public class NumericChangeEvent_NoticeClient : AEventClass<EventType.NumbericChange>
    {
        protected override async void Run(object args)
        {
            EventType.NumbericChange arg = args as EventType.NumbericChange;
            if (!(arg.Parent is Unit unit))
            {
                return;
            }

            unit.GetComponent<NumericNoticeComponent>()?.NoticeImmediately(arg);
            await ETTask.CompletedTask;
        }
    }
}
