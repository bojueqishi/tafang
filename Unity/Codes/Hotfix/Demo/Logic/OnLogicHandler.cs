namespace ET
{
    [MessageHandler]
    public class OnLogicHandler : AMHandler<LogicFrame>
    {
        protected override async void Run(Session session, LogicFrame message)
        {
            Scene scene = session.DomainScene();
            GameComponent gameComponent = scene.CurrentScene().GetComponent<GameComponent>();
            if(gameComponent != null)
            {
                gameComponent.OnLogicUpdate(message).Coroutine();
            }
            await ETTask.CompletedTask;
        }
    }
}
