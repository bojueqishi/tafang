using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace ET
{
    public class RangeDamageBullettAwakeSystem : AwakeSystem<RangeDamageBullet>
    {
        public override void Awake(RangeDamageBullet self)
        {
            self.IsReadyDamage = false;
        }
    }
    public class RangeDamageBullettUpdateSystem : UpdateSystem<RangeDamageBullet>
    {
        public override void Update(RangeDamageBullet self)
        {
            self.ToTarget();
        }
    }

    [FriendClass(typeof(RangeDamageBullet))]
    [FriendClass(typeof(Monster))]
    [FriendClass(typeof(GameComponent))]
    [FriendClass(typeof(Bullet))]
    public static class RangeDamageBulletSystem
    {
        public static async ETTask OnLogic(this RangeDamageBullet self, int dt)
        {
            Vector3 dst = self.DirPos;
            Vector3 src = self.GetParent<Bullet>().Position;
            Vector3 dir = dst - src;//向目标点方向向量
            float len = dir.magnitude;//获取向量长度
            float time = len / self.Speed;//获取到目标点 总的时间
            float dt_ms = dt / (float)1000.0f;//一帧的时间66
            if (time <= dt_ms)//造成伤害
            {
                List<Monster> damagemonster = new List<Monster>();
                List<Monster> monsters = self.ZoneScene().CurrentScene().GetComponent<GameComponent>().AllEnemy;
                if (monsters == null) return;
                float radius = self.DamageRange;
                for (int i = 0; i < monsters.Count; i++)
                {
                    Monster currentmonster = monsters[i];   
                    if (currentmonster == null || currentmonster.IsDead) continue;
                    if (Vector3.Distance(self.DirPos, currentmonster.Position) <= ((float)radius/1000.0f))
                    {
                        damagemonster.Add(currentmonster);
                    }
                }
                if(self.IsReadyDamage == false)
                {
                    DamageHelper.BulletRangeAttackMonster(self.ZoneScene().CurrentScene(), self.GetParent<Bullet>(), damagemonster, self.PhysicsDamage, self.MagicDamage, self.IsAP,self.Multiplier).Coroutine();
                    self.GetParent<Bullet>().LogicPos = self.GetParent<Bullet>().Position;//迭代完位置后 用帧位置来记录当前位置 用于下一次帧同步
                    Game.EventSystem.PublishAsync(new EventType.BulletBeforeDestroyAnimator() { entity = self.GetParent<Bullet>(),AnimatorName = "Effect" }).Coroutine();
                    Game.EventSystem.PublishAsync(new EventType.BulletDestroy() { currentscene = self.ZoneScene().CurrentScene(), Bullet = self.GetParent<Bullet>(), IsDelay = true, DelayAnimatorName = "Effect" }).Coroutine();
                    self.IsReadyDamage = true;
                }

                return;
            }
            else
            {
                self.GetParent<Bullet>().LogicPos = self.GetParent<Bullet>().LogicPos + dir.normalized * dt_ms * self.Speed;//迭代完位置后 用帧位置来记录当前位置 用于下一次帧同步
                self.GetParent<Bullet>().Position = self.GetParent<Bullet>().LogicPos;

                await ETTask.CompletedTask;
            }
        }
        public static async void ToTarget(this RangeDamageBullet self)
        {
            //if (self == null) return;
            if (self?.ZoneScene()?.CurrentScene()?.GetComponent<GameComponent>()?.SingleGameModeState == false) return;
            if (self.DirPos == null)
            {
                await Game.EventSystem.PublishAsync(new EventType.BulletDestroy() { currentscene = self.ZoneScene().CurrentScene(), Bullet = self.GetParent<Bullet>() });
                return;
            }
            Vector3 v = self.DirPos - self.GetParent<Bullet>().Position;//子弹位移方向
            self.GetParent<Bullet>().Position = self.GetParent<Bullet>().Position + v.normalized * Time.deltaTime * self.Speed;
            if (v.x != 0)//朝向
            {
                self.GetParent<Bullet>().Rotation = Quaternion.Euler(0, 0, Mathf.Atan(v.y / v.x) * Mathf.Rad2Deg);
            }
        }
    }
}

