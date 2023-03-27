using UnityEngine;

namespace ET
{
    public class BulletDestroyEvent : AEventAsync<EventType.BulletDestroy>
    {
        protected override async ETTask Run(EventType.BulletDestroy args)
        {
            if(args.IsDelay)//延迟
            {
                long delaytime = (long)(AnimatorHelper.GetCurrentClipTime(args.Bullet, args.DelayAnimatorName) * 1000);
                await TimerComponent.Instance.WaitAsync(delaytime);
            }
            GameObject.Destroy(args.Bullet.GetComponent<GameObjectComponent>().GameObject.gameObject);
            args.currentscene.GetComponent<GameComponent>().RemoveBullet(args.Bullet);
            args.Bullet?.Dispose();
            await ETTask.CompletedTask;
        }
    }
}