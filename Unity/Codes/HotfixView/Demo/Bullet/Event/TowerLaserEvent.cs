using ET.EventType;
using UnityEngine;

namespace ET
{
    [FriendClass(typeof(TowerChargeComponent))]
    public class TowerLaserEvent : AEventAsync<EventType.TowerLaser>
    {
        protected override async ETTask Run(TowerLaser a)
        {
            LineRenderer line = a.tower.GetComponent<GameObjectComponent>().GameObject.transform.Find("Laser").GetComponent<LineRenderer>();
            if (a.index == 1)//显示
            {
                line.gameObject.SetActive(true);
                line.positionCount = a.monster.Count + 1;
                NumericComponent towernum = a.tower.GetComponent<NumericComponent>();
                float AttackPointX = a.tower.GetComponent<TowerChargeComponent>().AttackPoint.position.x;
                float AttackPointY = a.tower.GetComponent<TowerChargeComponent>().AttackPoint.position.y;
                float towerposx = towernum.GetAsFloat(NumericType.TowerPx);
                float towerposy = towernum.GetAsFloat(NumericType.TowerPy);
                line.SetPosition(0, new Vector3(AttackPointX, AttackPointY, -1));
                for (int i=0;i<a.monster.Count; i++)
                {
                    Monster m = a.monster[i];
                    NumericComponent monsternum = m.GetComponent<NumericComponent>();
                    float monsterposx = monsternum.GetAsFloat(NumericType.MonsterPx);
                    float monsterposy = monsternum.GetAsFloat(NumericType.MonsterPy);
                    line.SetPosition(i+1, new Vector3(monsterposx, monsterposy, -1));
                }
            }
            if(a.index == 2)//隐藏
            {
                line.gameObject.SetActive(false);
            }
            await ETTask.CompletedTask;
        }
    }
}
