namespace ET
{
    [MessageHandler]
    public class G2C_ReturnWinGameHandler : AMHandler<G2C_ReturnWinGame>
    {
        protected override async void Run(Session session, G2C_ReturnWinGame message)
        {
            long WinUnitId = message.WinUnitId;
            Unit unit = UnitHelper.GetMyUnitFromCurrentScene(session.ZoneScene().CurrentScene());
            
            session.ZoneScene().CurrentScene().GetComponent<GameComponent>()?.Dispose();
            NumericComponent numeric = unit.GetComponent<NumericComponent>();
            int MyPosition = numeric.GetAsInt(NumericType.Position);

            if(WinUnitId == unit.Id)//胜利
            {
                //刷新胜利UI和下发奖励
                RewardHelper.AddReward(UnitHelper.GetMyUnitFromCurrentScene(session.ZoneScene().CurrentScene()),message.WinItemId,message.WinItemNumber);
                await Game.EventSystem.PublishAsync(new EventType.ShowGameResult() { zonescene = session.ZoneScene(), Result = true,ItemId = message.WinItemId,ItemNumber = message.WinItemNumber });
            }
            else
            {
                //刷新失败UI和下发奖励
                RewardHelper.AddReward(UnitHelper.GetMyUnitFromCurrentScene(session.ZoneScene().CurrentScene()), message.FailItemId, message.FailItemNumber);
                await Game.EventSystem.PublishAsync(new EventType.ShowGameResult() { zonescene = session.ZoneScene(), Result = false,ItemId = message.FailItemId,ItemNumber = message.FailItemNumber});
            }
        }
    }
}
