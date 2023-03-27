using ET.EventType;
using System.Collections.Generic;

namespace ET
{
    public class GameUpdateWaveInfoEvent : AEventAsync<EventType.GameUpdateWaveInfo>
    {
        protected override async ETTask Run(GameUpdateWaveInfo args)
        {
            List<int> ms = args.CurrentWaveAllMonsterConfigId;
            Dictionary<int ,int> monsterIdNumberDic = new Dictionary<int ,int>();
            for(int i=0;i<ms.Count;i++)
            {
                int id = ms[i];
                if(!monsterIdNumberDic.ContainsKey(id))//不包含Id 就增加Key Value
                {
                    monsterIdNumberDic.Add(id, 1);
                }
                else//包含id  就增加Value
                {
                    int temp = monsterIdNumberDic[id];
                    temp++;
                    monsterIdNumberDic[id] = temp;
                }
            }
            args.zonescene.GetComponent<UIComponent>().GetDlgLogic<DlgGameUI>().UpdateGameWaveInfo(args.CurrentWaveNumber,monsterIdNumberDic);
            await ETTask.CompletedTask;
        }
    }
}
