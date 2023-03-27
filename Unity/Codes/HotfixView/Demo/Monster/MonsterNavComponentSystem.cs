using System;
using UnityEngine;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ET
{
    
    public class MonsterNavComponentAwakeSystem : AwakeSystem<MonsterNavComponent>
    {
        public override void Awake(MonsterNavComponent self)
        {
            self.Awake();
            self.state = MonsterState.Run;
        }
    }
    public class MonsterNavComponentUpdateSystem : UpdateSystem<MonsterNavComponent>
    {
        public override void Update(MonsterNavComponent self)
        {
            self.Move();
        }
    }
    public class MonsterNavComponentDestroySystem : DestroySystem<MonsterNavComponent>
    {
        public override void Destroy(MonsterNavComponent self)
        {
            self.CurrentPos = 0;
            self.transform = null;
            self.Speed = 0;
        }
    }
    [FriendClass(typeof(MonsterNavComponent))]
    [FriendClass(typeof(GameComponent))]
    public static class MonsterNavComponentSystem 
    {
        public static void Awake(this MonsterNavComponent self)
        {
            self.num = self.Parent.GetComponent<NumericComponent>();
            self.CurrentPos = 0;
            self.LogicPos = new Vector3();
            self.Speed = self.num.GetAsFloat(NumericType.MonsterSpeed);
            self.IsDead = false;
        }
        public static async void Move(this MonsterNavComponent self)
        {
            if (self == null) return;
            if (self?.ZoneScene()?.CurrentScene()?.GetComponent<GameComponent>()?.SingleGameModeState == false) return;
            if (self.transform == null) return;
            if (self.IsDead) return;
            if (self.state != MonsterState.Run) return;
            self.JudgeDir();
            if (Vector3.Distance(self.transform.position, self.NavPos[self.NavPos.Length - 1]) < 0.01f)
            {
                int monsterzone = self.GetParent<Monster>().GetComponent<NumericComponent>().GetAsInt(NumericType.MonsterZone);
                Base baseitem = self.ZoneScene().CurrentScene().GetComponent<GameComponent>().GetBaseByZone(monsterzone);
                DamageHelper.MonsterSingleAttackBase(self.ZoneScene().CurrentScene(), self.GetParent<Monster>(), baseitem).Coroutine();
            }
            if (self.CurrentPos<self.NavPos.Length)
            {
                if (Vector3.Distance(self.NavPos[self.CurrentPos], self.transform.position) > 0.01f)
                {
                    self.transform.Translate((self.NavPos[self.CurrentPos] - self.transform.position).normalized * Time.deltaTime * self.num.GetAsFloat(NumericType.MonsterSpeed));
                    self.GetParent<Monster>().Position = self.transform.position;
                    self.num.SetNoEvent(NumericType.MonsterPx, (int)(self.transform.position.x * 10000));
                    self.num.SetNoEvent(NumericType.MonsterPy, (int)(self.transform.position.y * 10000));
                }
                else
                {
                    self.CurrentPos++;
                }
            }
            else
            {
                return;
            }
        }
        public static async void JudgeDir(this MonsterNavComponent self)
        {
            if ((self.NavPos[self.CurrentPos] - self.transform.position).x < 0)
            {
                self.GetParent<Monster>().GetComponent<GameObjectComponent>().GameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                self.GetParent<Monster>().GetComponent<GameObjectComponent>().GameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        } 
        public static async void OnLogicJudgeState(this MonsterNavComponent self,int dt_ms)//若攻击还需帧迭代  若攻击（攻击时间大于攻击间隔并且状态不在攻击时）
        {
            //判断行为并转换动画  //如果周围有怪（则判断攻击时间是否大于间隔时间  则转化为攻击  不然则为Idle  攻击后自动转化为Idle）
            self.state = MonsterState.Run;
            AnimatorHelper.Play(self.GetParent<Monster>(), "Run").Coroutine();
            await ETTask.CompletedTask;
        }
        public static async void OnLogicMoveUpdate(this MonsterNavComponent self,int dt_ms)
        {
            if (self.state != MonsterState.Run) return;
            self.transform.position = self.LogicPos;
            Vector3 src = self.transform.position;
            Vector3 dst = self.NavPos[self.CurrentPos];
            Vector3 dir = dst - src;
            float len = dir.magnitude;
            if(len <= 0)//已经到目标点了
            {
                self.CurrentPos++;
                self.OnLogicMoveUpdate(dt_ms);
                return;
            }

            bool isArrived = false;
            float time = len / self.num.GetAsFloat(NumericType.MonsterSpeed);//到当前目的地需要用的时间 30
            float dt = dt_ms / (float)1000;//一帧的时间 66
            int det = (int)((dt - time) * 1000);//36

            if(time < dt)//time < dt  说明走过了   time >= dt 说明还没到
            {
                dt = time;
                isArrived = true;
            }

            self.transform.position = self.transform.position + dir.normalized * dt * self.num.GetAsFloat(NumericType.MonsterSpeed);
            self.LogicPos = self.transform.position;
            self.num.SetNoEvent(NumericType.MonsterPx, (int)(self.transform.position.x * 10000));
            self.num.SetNoEvent(NumericType.MonsterPy, (int)(self.transform.position.y * 10000));

            if(isArrived)
            {
                self.CurrentPos++;
                if(self.CurrentPos >= self.NavPos.Length)//超出了总路程范围 就造成伤害
                {
                    int monsterzone = self.GetParent<Monster>().GetComponent<NumericComponent>().GetAsInt(NumericType.MonsterZone);
                    Base baseitem = self.ZoneScene().CurrentScene().GetComponent<GameComponent>().GetBaseByZone(monsterzone);
                    DamageHelper.MonsterSingleAttackBase(self.ZoneScene().CurrentScene(), self.GetParent<Monster>(), baseitem).Coroutine();
                }
                else//否则把剩下的路程迭代完
                {
                    self.OnLogicMoveUpdate(det);
                }
            }
        }
    }
}
