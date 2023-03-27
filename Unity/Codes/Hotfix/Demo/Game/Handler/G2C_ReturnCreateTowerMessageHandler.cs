namespace ET
{
    [MessageHandler]
    public class G2C_ReturnCreateTowerMessageHandler : AMHandler<G2C_ReturnCreateTowerMessage>
    {
        protected override async void Run(Session session, G2C_ReturnCreateTowerMessage message)
        {
           //await UnitFactory.CreateTower(session.ZoneScene().CurrentScene(), message.TowerConfigId,message.TowerPX, message.TowerPY,message.Position,message.TowerId);
        }
    }
}
