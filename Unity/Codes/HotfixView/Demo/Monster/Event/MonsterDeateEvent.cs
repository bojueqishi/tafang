using UnityEngine;

namespace ET
{
    [FriendClass(typeof(MonsterNavComponent))]
    [FriendClass(typeof(HeadHpViewComponent))]
    [FriendClass(typeof(Monster))]
    public class MonsterDeateEvent : AEventAsync<EventType.MonsterDeath>
    {
        protected override async ETTask Run(EventType.MonsterDeath args)
        {
            NumericComponent numeric = args.Monster.GetComponent<NumericComponent>();
            int hp = numeric.GetAsInt(NumericType.MonsterHp);

            if (hp > 0) return;
            if(args.IsAdd && args.Monster.GetComponent<NumericComponent>().GetAsInt(NumericType.MonsterZone)==UnitHelper.GetMyUnitFromCurrentScene(args.currentscene).GetComponent<NumericComponent>().GetAsInt(NumericType.Position))//添加金币
            {
                int DropMoney = numeric.GetAsInt(NumericType.MonsterReturnMoney);
                Unit unit = UnitHelper.GetMyUnitFromCurrentScene(args.currentscene);
                NumericComponent unitnumeric = unit.GetComponent<NumericComponent>();
                unitnumeric.Set(NumericType.GameMoney, unitnumeric.GetAsInt(NumericType.GameMoney) + DropMoney);
            }
            AnimatorComponent animator = args.Monster.GetComponent<AnimatorComponent>();

            args.Monster.GetComponent<MonsterNavComponent>().IsDead = true;
            args.Monster.GetComponent<HeadHpViewComponent>().HpBarGroup.SetActive(false);
            if(args.Monster.DeathEvent != null) args.Monster.DeathEvent(args.Monster);
            args.currentscene.GetComponent<GameComponent>().RemoveMonster(args.Monster);
            await TimerComponent.Instance.WaitAsync(1000);

            args.Monster?.Dispose();
        }
    }
}