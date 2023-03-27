using System;
using System.Collections.Generic;

namespace ET
{
    public class BulletAwakeSystem : AwakeSystem<Bullet>
    {
        public override void Awake(Bullet self)
        {
            self.BulletAttacks = new Dictionary<int, int>();
            self.IsTrigger = false;
            self.BulletAttackIntervalTimer = 0;
            self.BulletTimeTimer = 0;
            self.LogicPos = new UnityEngine.Vector3();
        }
    }
    public class BulletDestorySystem : DestroySystem<Bullet>
    {
        public override void Destroy(Bullet self)
        {

        }
    }
    public static class BulletSystem
    {
        public static void OnLogic(this Bullet self,int dt)
        {
            List<Type> types = new List<Type>();
            foreach(Type type in self.Components.Keys)
            {
                types.Add(type);
            }
            for(int i=0;i<self.Components.Count;i++)
            {
                Type type = types[i];
                if (typeof(LogicBullet).IsAssignableFrom(type))
                {
                    var component = self.Components[type];
                    object[] param = new object[] { component, dt };
                    Type system = Type.GetType(type.FullName + "System");
                    system.GetMethod("OnLogic").Invoke(component, param);
                }
            }
        }
    }
}
