using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class BulletNavComponentAwakeSystem : AwakeSystem<BulletNavComponent>
    {
        public override void Awake(BulletNavComponent self)
        {
        }
    }
    public class BulletNavComponentUpdateSystem : UpdateSystem<BulletNavComponent>
    {
        public override void Update(BulletNavComponent self)
        {
        }
    }
    public class BulletNavComponentDestroySystem : DestroySystem<BulletNavComponent>
    {
        public override void Destroy(BulletNavComponent self)
        {

        }
    }
    [FriendClass(typeof(BulletNavComponent))]
    [FriendClass(typeof(Bullet))]
    [FriendClass(typeof(MonsterNavComponent))]
    [FriendClass(typeof(GameComponent))]
    public static class BulletNavComponentSystem
    {
       
    }
}
