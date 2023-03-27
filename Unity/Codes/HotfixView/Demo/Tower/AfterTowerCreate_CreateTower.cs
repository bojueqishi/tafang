using UnityEngine;
using UnityEngine.EventSystems;

namespace ET
{
    [FriendClass(typeof(GlobalComponent))]
    public class AfterTowerCreate_CreateTower : AEventAsync<EventType.AfterUnitCreateTower>
    {
        protected override async ETTask Run(EventType.AfterUnitCreateTower args)
        {
            // Unit View层
            // 这里可以改成异步加载，demo就不搞了
            GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset("Unit.unity3d", "Unit");
            GameObject prefab = bundleGameObject.Get<GameObject>(args.Tower.Config.PrefabName);
            GameObject go = UnityEngine.Object.Instantiate(prefab, GlobalComponent.Instance.Unit, true);
            //视角尺寸变换
            Transform cameratransform = GlobalComponent.Instance.MainCamera;
            float Scale = args.zonescene.GetComponent<UIComponent>().GetDlgLogic<DlgGameUI>().SetVisualScale(0);
            NumericComponent numericcomponent = args.Tower.GetComponent<NumericComponent>();
            float px = args.TowerPx;
            float py = args.TowerPy;
            float NewPx = (px / 10000.0f);
            float NewPy = (py / 10000.0f);
            /*numericcomponent.SetNoEvent(NumericType.TowerPx, (long)(NewPx * 10000));
            numericcomponent.SetNoEvent(NumericType.TowerPy, (long)(NewPy * 10000));*/
            go.transform.position = new Vector3(NewPx , NewPy  , 0);
            args.Tower.Position = new Vector3(NewPx, NewPy, 0);
            args.Tower.AddComponent<GameObjectComponent>().GameObject = go;
            args.Tower.GetComponent<GameObjectComponent>().SpriteRender = go.GetComponent<SpriteRenderer>();
            args.Tower.AddComponent<AnimatorComponent>();
            args.Tower.AddComponent<TowerChargeComponent>();
            await ETTask.CompletedTask;
        }
        
    }
}