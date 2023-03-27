using ET.EventType;

namespace ET
{
    public class TowerChargeBarEvent : AEventAsync<EventType.TowerChargeBar>
    {
        protected override async ETTask Run(TowerChargeBar a)
        {
            TowerChargeComponent towerChargeComponent = a.tower.GetComponent<TowerChargeComponent>();
            if (a.SizeX > 1) a.SizeX = 1;
            towerChargeComponent.SetChargeBar(a.SizeX);
            await ETTask.CompletedTask;
        }
    }
}
