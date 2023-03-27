using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    [FriendClass(typeof(GlobalComponent))]
    [FriendClass(typeof(MonsterNavComponent))]
    public class AfterBaseCreate_CreateBase : AEventAsync<EventType.AfterUnitCreateBase>
    {
        protected override async ETTask Run(EventType.AfterUnitCreateBase args)
        {
            // Unit View层
            // 这里可以改成异步加载，demo就不搞了
            GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset("Unit.unity3d", "Unit");
            GameObject prefab = bundleGameObject.Get<GameObject>("Base");
            GameObject go = UnityEngine.Object.Instantiate(prefab, GlobalComponent.Instance.Unit, true);

            args.baseitem.AddComponent<GameObjectComponent>().GameObject = go;
            args.baseitem.GetComponent<GameObjectComponent>().SpriteRender = go.GetComponent<SpriteRenderer>();
            args.baseitem.AddComponent<AnimatorComponent>();
            args.baseitem.AddComponent<HeadHpViewComponent>();
            args.baseitem.GetComponent<HeadHpViewComponent>().Init(2);
            args.baseitem.GetComponent<HeadHpViewComponent>().SetBaseHp();
            NumericComponent num = args.baseitem.GetComponent<NumericComponent>();
            int BasePos = num.GetAsInt(NumericType.BasePos);

            Vector3[] v3s = args.currentscene.GetComponent<NavVector>().GetPosByNavId(BasePos);
            int count = v3s.Length;
            Vector3 pos = v3s[count - 1];
            //设置起始坐标
            go.transform.position = pos;
            num.SetNoEvent(NumericType.BasePosX,(long)(go.transform.position.x * 10000));
            num.SetNoEvent(NumericType.BasePosY, (long)(go.transform.position.y * 10000));
            await ETTask.CompletedTask;
        }
    }
}