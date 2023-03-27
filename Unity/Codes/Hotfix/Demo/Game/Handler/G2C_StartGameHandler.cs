namespace ET
{
    [MessageHandler]
    [FriendClass(typeof(GameComponent))]
    public class G2C_StartGameHandler : AMHandler<G2C_StartGame>
    {
        protected override void Run(Session session, G2C_StartGame message)//断线后重新连接  重新加入服务器房间之后  服务器也要发送一条开始游戏
        {
            GameComponent gamecomponent = session.ZoneScene().CurrentScene().GetComponent<GameComponent>();
            Game.EventSystem.PublishAsync(new EventType.DisReadyAndShowWindow() {scene = session.ZoneScene() }).Coroutine();
            gamecomponent.ListToDictionary();
            gamecomponent.DictionaryToTimerMonster();
        }
    }
}
