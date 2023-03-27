using UnityEngine;

namespace ET
{
    [FriendClass(typeof(GlobalComponent))]
    [FriendClass(typeof(Bullet))]
    [FriendClass(typeof(BulletNavComponent))]
    [FriendClass(typeof(MonsterNavComponent))]
    public class AfterBulletCreate_CreateBullet : AEventAsync<EventType.AfterUnitCreateBullet>
    {
        protected override async ETTask Run(EventType.AfterUnitCreateBullet args)
        {
            // Unit View层
            // 这里可以改成异步加载，demo就不搞了
            GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset("Unit.unity3d", "Unit");
            GameObject prefab = bundleGameObject.Get<GameObject>(args.Bullet.BulletPrefabName);
            GameObject go = UnityEngine.Object.Instantiate(prefab, GlobalComponent.Instance.Unit, true);

            args.Bullet.AddComponent<GameObjectComponent>().GameObject = go;
            args.Bullet.GetComponent<GameObjectComponent>().SpriteRender = go.GetComponent<SpriteRenderer>();
            args.Bullet.AddComponent<AnimatorComponent>();

            NumericComponent numericcomponent = args.Tower.GetComponent<NumericComponent>();//塔的初始位置
            float px = args.Tower.Position.x;
            float py = args.Tower.Position.y;

            args.Bullet.Position = go.transform.position;
            args.Bullet.LogicPos = go.transform.position;

            args.Bullet.Position = new Vector3(px, py, 0);//子弹初始位置同步塔的位置
            args.Bullet.LogicPos = new Vector3(px, py, 0);
            Log.Debug(args.Bullet.Position.ToString());
        }

    }
}