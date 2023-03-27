using ET.EventType;

namespace ET
{
    public class LogicMonsterPosEvent : AEventAsync<EventType.LogicMonsterPos>
    {
        protected override async ETTask Run(LogicMonsterPos args)
        {
            for(int i=0;i<args.monsters.Count;i++)
            {
                if (args.monsters[i] != null)
                {
                    args.monsters[i].GetComponent<MonsterNavComponent>().OnLogicMoveUpdate(args.FrameDt);
                    args.monsters[i].GetComponent<MonsterNavComponent>().OnLogicJudgeState(args.FrameDt);
                }
            }
            await ETTask.CompletedTask;
        }
    }
}
