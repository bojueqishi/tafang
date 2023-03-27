using ET.EventType;

namespace ET
{
    public class BulletBeforeDestroyAnimatorEvent : AEventAsync<EventType.BulletBeforeDestroyAnimator>
    {
        protected override async ETTask Run(BulletBeforeDestroyAnimator args)
        {
            AnimatorHelper.Play(args.entity, args.AnimatorName).Coroutine();
            await ETTask.CompletedTask;
        }
    }
}
