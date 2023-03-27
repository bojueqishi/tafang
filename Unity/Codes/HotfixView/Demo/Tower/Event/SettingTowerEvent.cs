using ET.EventType;

namespace ET
{
    public class SettingTowerEvent : AEventAsync<EventType.SettingTower>
    {
        protected override async ETTask Run(SettingTower args)
        {
            Scene zonescene = args.zonescene;
            LevelConfig levelconfig = LevelConfigCategory.Instance.Get(args.mapid);
            MapConfig mapconfig = MapConfigCategory.Instance.Get(levelconfig.MapId);
            zonescene.GetComponent<UIComponent>().GetDlgLogic<DlgGameUI>().SettingTower(args.tower,args.TowerId,args.opttype,args.towerX,args.towerY);
            await ETTask.CompletedTask;
        }
    }
}
