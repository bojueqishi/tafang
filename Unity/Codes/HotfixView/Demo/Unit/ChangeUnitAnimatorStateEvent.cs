using ET.EventType;

namespace ET
{
    public class ChangeUnitAnimatorStateEvent : AEventAsync<EventType.ChangeUnitAnimatorState>
    {
        protected override async ETTask Run(ChangeUnitAnimatorState args)
        {
            AnimatorHelper.Play(args.entity, args.AnimatorName).Coroutine();
            await ETTask.CompletedTask;
        }
    }
}
