namespace ET
{
    [MessageHandler]
    [FriendClass(typeof(GameComponent))]
    public class G2C_ReturnCreateMonsterMessageHandler : AMHandler<G2C_ReturnCreateMonsterMessage>
    {
        protected override async void Run(Session session, G2C_ReturnCreateMonsterMessage message)
        {
            int position = message.Position;
            int monsterId = message.MonsterId;
            GameComponent gamecomponent = session.ZoneScene().CurrentScene().GetComponent<GameComponent>();
            int MonsterNavId = 0;
            if (position == 1)
            {
                MonsterNavId = gamecomponent.MonsterNavIdTwo;
                await UnitFactory.CreateMonster(session.ZoneScene().CurrentScene(), monsterId,IdGenerater.Instance.GenerateId(), MonsterNavId,2);
            }
            if (position == 2)
            {
                MonsterNavId = gamecomponent.MonsterNavIdOne;
                await UnitFactory.CreateMonster(session.ZoneScene().CurrentScene(), monsterId,IdGenerater.Instance.GenerateId(), MonsterNavId, 1);
            }
            
        }
    }
}
