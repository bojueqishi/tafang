using System;
using System.Collections.Generic;

namespace ET
{
    [FriendClass(typeof(GameComponent))]
    public static class SceneChangeHelper
    {
        // 场景切换协程
        public static async ETTask SceneChangeTo(Scene zoneScene, string sceneName, long sceneInstanceId,int MapId,int MatchMode)
        {
            //zoneScene.RemoveComponent<AIComponent>();
            CurrentScenesComponent currentScenesComponent = zoneScene.GetComponent<CurrentScenesComponent>();
            currentScenesComponent.Scene?.Dispose(); // 删除之前的CurrentScene，创建新的
            Scene currentScene = SceneFactory.CreateCurrentScene(sceneInstanceId, zoneScene.Zone, sceneName, currentScenesComponent);
            UnitComponent unitComponent = currentScene.AddComponent<UnitComponent>();

            
            // 可以订阅这个事件中创建Loading界面
            Game.EventSystem.Publish(new EventType.SceneChangeStart() { ZoneScene = zoneScene });

            // 等待CreateMyUnit的消息
            WaitType.Wait_CreateMyUnit waitCreateMyUnit = await zoneScene.GetComponent<ObjectWait>().Wait<WaitType.Wait_CreateMyUnit>();
            M2C_CreateMyUnit m2CCreateMyUnit = waitCreateMyUnit.Message;
            Unit unit = UnitFactory.Create(currentScene, m2CCreateMyUnit.Unit);
            unitComponent.Add(unit);

            //zoneScene.RemoveComponent<AIComponent>();
            Game.EventSystem.PublishAsync(new EventType.SceneChangeFinish() { ZoneScene = zoneScene, CurrentScene = currentScene }).Coroutine();

            if (sceneName == "Map1")
            {
                // 通知 等待场景切换的协程
                zoneScene.GetComponent<ObjectWait>().Notify(new WaitType.Wait_SceneChangeFinish());
                await Game.EventSystem.PublishAsync(new EventType.DisGameUI() { ZoneScene = zoneScene, CurrentScene = currentScene });
            }
            if(sceneName == "Game")
            {
                GameComponent gamecomponent = currentScene.AddComponent<GameComponent>();
                currentScene.AddComponent<MonsterComponent>();
                currentScene.AddComponent<TowerComponent>();
                currentScene.AddComponent<BulletComponent>();
                currentScene.AddComponent<BaseComponent>();
                LevelConfig levelConfig = LevelConfigCategory.Instance.Get(MapId);
                gamecomponent.MonsterWaveInterval = levelConfig.MonsterWaveInterval;
                gamecomponent.MapId = MapId;
                MapConfig mapconfig = MapConfigCategory.Instance.Get(levelConfig.MapId);
                gamecomponent.MonsterNavIdOne = mapconfig.NavIdOne;
                gamecomponent.MonsterNavIdTwo = mapconfig.NavIdTwo;
                gamecomponent.MaxVisualX = mapconfig.MaxVisualX;
                gamecomponent.MaxVisualY = mapconfig.MaxVisualY;
#if UNITY_2017_1_OR_NEWER
                gamecomponent.waves = MonsterWaveConfigCategory.Instance.GetAllConfigByWaveCode(levelConfig.WaveCode);
#endif
                await Game.EventSystem.PublishAsync(new EventType.ViewGameUI() { ZoneScene = zoneScene, CurrentScene = currentScene,MatchMode = MatchMode });
                await Game.EventSystem.PublishAsync(new EventType.ShowMapUI() { currentscene = currentScene, MapName = mapconfig.MapName});
                try
                {
                    int errorcode = await GameHelper.AddRoomIndex(zoneScene);
                    if(errorcode != ErrorCode.ERR_Success)
                    {
                        return;
                    }
                }
                catch(Exception e)
                {
                    Log.Error(e.ToString());
                    return;
                }

            }
        }
    }
}