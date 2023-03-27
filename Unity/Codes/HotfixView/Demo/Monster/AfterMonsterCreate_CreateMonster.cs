using UnityEngine;

namespace ET
{
    [FriendClass(typeof(GlobalComponent))]
    [FriendClass(typeof(MonsterNavComponent))]
    public class AfterMonsterCreate_CreateMonster: AEventAsync<EventType.AfterUnitCreateMonster>
    {
        protected override async ETTask Run(EventType.AfterUnitCreateMonster args)
        {
            // Unit View层
            // 这里可以改成异步加载，demo就不搞了
            GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset("Unit.unity3d", "Unit");
            GameObject prefab = bundleGameObject.Get<GameObject>(args.Monster.Config.PrefabName);
            GameObject go = UnityEngine.Object.Instantiate(prefab, GlobalComponent.Instance.Unit, true);
            
            args.Monster.AddComponent<GameObjectComponent>().GameObject = go;
            args.Monster.GetComponent<GameObjectComponent>().SpriteRender = go.GetComponent<SpriteRenderer>();
            args.Monster.GetComponent<GameObjectComponent>().SpriteRender.sprite = IconHelper.LoadIconSprite("monster", args.Monster.Config.PrefabName);
            args.Monster.AddComponent<AnimatorComponent>();
            args.Monster.AddComponent<HeadHpViewComponent>();
            args.Monster.GetComponent<HeadHpViewComponent>().Init(1);
            args.Monster.GetComponent<HeadHpViewComponent>().SetMonsterHp();
            MonsterNavComponent nav = args.Monster.AddComponent<MonsterNavComponent>();
            //根据Id添加导航路线
            int NavId = args.Monster.GetComponent<NumericComponent>().GetAsInt(NumericType.MonsterNav);

            nav.NavPos = args.CurrentScene.GetComponent<NavVector>().GetPosByNavId(NavId);
            //设置起始坐标
            nav.transform = go.transform;
            nav.transform.position = nav.NavPos[0];
            nav.LogicPos = nav.NavPos[0];
            args.Monster.Position = nav.NavPos[0];
            /*args.Monster.GetComponent<NumericComponent>().SetNoEvent(NumericType.MonsterPx, (long)(nav.NavPos[0].x * 10000));
            args.Monster.GetComponent<NumericComponent>().SetNoEvent(NumericType.MonsterPy, (long)(nav.NavPos[0].y * 10000));
            await ETTask.CompletedTask;*/
        }
    }
}