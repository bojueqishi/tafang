using ET.EventType;
using System.Collections.Generic;

namespace ET
{
    public class OnLogicBulletEvent : AEventAsync<EventType.LogicBulletPos>
    {
        protected override async ETTask Run(LogicBulletPos args)
        {
            /*List<Bullet> bullets = args.bullets;
            for(int i=0;i<bullets.Count; i++)
            {
                Bullet bullet = bullets[i];
                if (bullet == null) continue;
                if(bullet.GetComponent<BulletNavComponent>() != null)
                {
                    bullet.GetComponent<BulletNavComponent>().OnLogicUpdate(args.FrameDt);
                }
            }
            await ETTask.CompletedTask;*/
        }
    }
}
