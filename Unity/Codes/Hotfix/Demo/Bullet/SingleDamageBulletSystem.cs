using System.Security.Cryptography;
using UnityEngine;

namespace ET
{
    public class SingleDamageBulletUpdateSystem : UpdateSystem<SingleDamageBullet>
    {
        public override void Update(SingleDamageBullet self)
        {
            self.ToTarget();
        }
    }

    [FriendClass(typeof(SingleDamageBullet))]
    [FriendClass(typeof(Monster))]
    [FriendClass(typeof(Bullet))]
    public static class SingleDamageBulletSystem
    {
        public static async ETTask OnLogic(this SingleDamageBullet self,int dt)
        {
            if (self.Monster == null)//怪中途死了返回
            {
                await Game.EventSystem.PublishAsync(new EventType.BulletDestroy() { currentscene = self.ZoneScene().CurrentScene(), Bullet = self.GetParent<Bullet>() });
            }
            Vector3 dst = self.Monster.Position;
            Vector3 src = self.GetParent<Bullet>().Position;
            Vector3 dir = dst - src;//向目标点方向向量
            float len = dir.magnitude;//获取向量长度
            float time = len / self.Speed;//获取到目标点 总的时间
            float dt_ms = dt / (float)1000.0f;//一帧的时间66
            if (time <= dt_ms)//造成伤害
            {
                DamageHelper.BulletSingleAttackMonster(self.ZoneScene().CurrentScene(), self.GetParent<Bullet>(), self.Monster,self.PhysicsDamage,self.MagicDamage,self.IsAP,self.Multiplier).Coroutine();
                self.GetParent<Bullet>().LogicPos = self.GetParent<Bullet>().Position;//迭代完位置后 用帧位置来记录当前位置 用于下一次帧同步
                Game.EventSystem.PublishAsync(new EventType.BulletDestroy() { currentscene = self.ZoneScene().CurrentScene(), Bullet = self.GetParent<Bullet>(), IsDelay = false }).Coroutine();
                return;
            }
            else
            {
                self.GetParent<Bullet>().LogicPos = self.GetParent<Bullet>().LogicPos + dir.normalized * dt_ms * self.Speed;
                self.GetParent<Bullet>().Position = self.GetParent<Bullet>().LogicPos;//迭代完位置后 用帧位置来记录当前位置 用于下一次帧同步

                await ETTask.CompletedTask;
            }
        }
        public static async void ToTarget(this SingleDamageBullet self)
        {
            //if (self == null) return;
            if (self?.ZoneScene()?.CurrentScene()?.GetComponent<GameComponent>()?.SingleGameModeState == false) return;
            if (self.Monster == null || self.Monster.IsDead == true)//怪若死了 直接返回
            {
                await Game.EventSystem.PublishAsync(new EventType.BulletDestroy() { currentscene = self.ZoneScene().CurrentScene(), Bullet = self.GetParent<Bullet>() });
                return;
            }
            Vector3 v = self.Monster.Position - self.GetParent<Bullet>().Position;//子弹位移方向
            self.GetParent<Bullet>().Position = self.GetParent<Bullet>().Position + v.normalized * Time.deltaTime * self.Speed;
            if (v.x != 0)//朝向
            {
                self.GetParent<Bullet>().Rotation = Quaternion.Euler(0, 0, Mathf.Atan(v.y / v.x) * Mathf.Rad2Deg);
            }
        }
    }
}

