using ET.EventType;
using UnityEngine;

namespace ET
{
    [FriendClass(typeof(MapComponent))]
    [FriendClass(typeof(GameComponent))]
    [FriendClass(typeof(DlgGameUI))]
    public class ShowMapUIEvent : AEventAsync<EventType.ShowMapUI>
    {
        protected override async ETTask Run(ShowMapUI args)
        {
            GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset("Unit.unity3d", "Unit");
            GameObject prefab = bundleGameObject.Get<GameObject>(args.MapName);
            GameObject go = UnityEngine.Object.Instantiate(prefab, GlobalComponent.Instance.Unit, true);
            go.transform.position = new Vector3(0, 0, 0);
            MapComponent mapcomponent = args.currentscene.AddComponent<MapComponent>();
            mapcomponent.MapObject = go;

            GameObject TowerBgPrefab = prefab = bundleGameObject.Get<GameObject>("TowerBg");
            int mapid = args.currentscene.GetComponent<GameComponent>().MapId;
            MapConfig mapconfig = MapConfigCategory.Instance.Get(mapid);
            int[] PosX = mapconfig.PosX;
            int[] PosY = mapconfig.PosY;
            for (int i=0;i<args.currentscene.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgGameUI>().CurrentTowers.Count;i++)
            {
                GameObject TowerBgObj = UnityEngine.Object.Instantiate(prefab, GlobalComponent.Instance.Unit, true);
                mapcomponent.TowerBgs.Add(TowerBgObj);
                TowerBgObj.transform.position = new Vector3((float)PosX[i]/100.0f, (float)PosY[i]/100.0f-0.2f, 0);
            }
            

            await ETTask.CompletedTask;
        }
    }
}
