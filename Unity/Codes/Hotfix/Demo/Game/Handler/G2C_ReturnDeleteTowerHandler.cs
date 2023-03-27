
namespace ET
{
    [MessageHandler]
    public class G2C_ReturnDeleteTowerHandler : AMHandler<G2C_ReturnDeleteTower>
    {
        protected override async void Run(Session session, G2C_ReturnDeleteTower message)
        {
            long towerId = message.TowerId;
            await UnitFactory.DeleteTower(session.ZoneScene().CurrentScene(), towerId);
        }
    }
}
