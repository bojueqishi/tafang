using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using UnityEngine;

namespace ET
{
    public class GameComponentAwakeSystem : AwakeSystem<GameComponent>
    {
        public override void Awake(GameComponent self)
        {
            self.AllEnemy = new List<Monster>();
            self.AllTower = new List<Tower>();
            self.AllBullet = new List<Bullet>();
            self.AllBase = new List<Base>();
            self.waves = new List<MonsterWaveConfig>();
            self.WaveNumber = new List<int>();
            self.wavedic = new Dictionary<int, List<MonsterWaveConfig>>();
            self.MonsterTime = new List<int>();
            self.MonsterId = new List<int>();
            self.NextOpts = new List<OptionEvent>();
            self.CurrentMonsterIndex = 0;
            self.LogicTimer = 0;
            self.MonsterTimer = 0;
            self.WaveInfoTimer = 0;
            self.LastFrameOpt = null;
            self.MoneyTimer = 0;
            self.FrameDt = 66;
            self.Frameid = 0;
            self.SingleGameModeState = true;
        }
    }
    public class GameComponentDestroySystem : DestroySystem<GameComponent>
    {
        public override void Destroy(GameComponent self)
        {
            self.Destroy().Coroutine();
        }
    }
    [FriendClass(typeof(GameComponent))]
    public static class GameComponentSystem 
    {
        public static void ListToDictionary(this GameComponent self)
        {
            for(int i=0;i<self.waves.Count;i++)
            {
                MonsterWaveConfig wave = self.waves[i];
                if(self.wavedic.TryGetValue(wave.Group,out List<MonsterWaveConfig> list))
                {
                    list.Add(wave);
                }
                else
                {
                    List<MonsterWaveConfig> lists = new List<MonsterWaveConfig>();
                    lists.Add(wave);
                    self.wavedic.Add(wave.Group, lists);
                }
            }
        }
        public static void DictionaryToTimerMonster(this GameComponent self)
        {
            int CurrentTime = 0;
            int AllMonsterInterval = (int)self.MonsterWaveInterval;
            int maxTime = 0;
            for (int i = 1; i <= self.wavedic.Count; i++)//遍历游戏总波次的字典 2
            {
                CurrentTime = CurrentTime + AllMonsterInterval;
                //每一波的开始 用CurrentTime记录波次
                self.WaveNumber.Add(CurrentTime);
                List<MonsterWaveConfig> waves = self.wavedic[i];
                for (int j = 0; j < waves.Count; j++)//同一波的不同类型 龙,弓箭手 
                {
                    int TempTime = CurrentTime;
                    MonsterWaveConfig config = waves[j];
                    int Timing = config.Timing;
                    TempTime = TempTime + Timing;
                    for(int k = 0;k<config.MonsterNumber;k++)//不同类型的每个怪
                    {
                        self.MonsterTime.Add(TempTime);
                        self.MonsterId.Add(config.MonsterId);
                        if(k!=config.MonsterNumber-1)
                        {
                            TempTime = TempTime + config.MonsterInterval;
                        }
                    }
                    if (maxTime < TempTime) maxTime = TempTime;
                }
                CurrentTime = maxTime;
            }
            //排序
            for(int i=0;i<self.MonsterTime.Count;i++)
            {
                for(int j=0;j<self.MonsterTime.Count - 1;j++)
                {
                    if (self.MonsterTime[j] > self.MonsterTime[j+1])
                    {
                        int temp = self.MonsterTime[j];
                        self.MonsterTime[j] = self.MonsterTime[j+1];
                        self.MonsterTime[j + 1] = temp;
                        temp = self.MonsterId[j];
                        self.MonsterId[j] = self.MonsterId[j + 1];
                        self.MonsterId[j + 1] = temp;
                    }
                }
            }
            self.InitGame().Coroutine();
        }
        public static async ETTask InitGame(this GameComponent self)
        {
            self.GameEnding = true;
            self.Base1 = await UnitFactory.CreateBase(self.ZoneScene().CurrentScene(), 1, self.MonsterNavIdOne);
            self.Base2 = await UnitFactory.CreateBase(self.ZoneScene().CurrentScene(), 2, self.MonsterNavIdTwo);
            await ETTask.CompletedTask;
        }
        public static void RemoveTower(this GameComponent self,Tower tower)
        {
            if(self.AllTower.Contains(tower))
            {
                self.AllTower.Remove(tower);
            }
        }
        public static void RemoveBullet(this GameComponent self,Bullet bullet)
        {
            if (self == null) return;
            if(self.AllBullet.Contains(bullet))
            {
                self.AllBullet.Remove(bullet);
            }
        }
        public static void RemoveMonster(this GameComponent self,Monster monster)
        {
            if(self.AllEnemy.Contains(monster))
            {
                self.AllEnemy.Remove(monster);
            }
        }
        public static Base GetBaseByZone(this GameComponent self,int zone)
        {
            if (zone == 1) return self.Base1;
            if (zone == 2) return self.Base2;
            return null;
        }
        public static async ETTask WinGame(this GameComponent self,int winposition)
        {
            try
            {
                int errorcode = await GameHelper.RequestWin(self.ZoneScene(),winposition);
                if (errorcode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorcode.ToString());
                    return;
                }
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return;
            }
        }
        public static async ETTask Destroy(this GameComponent self)
        {
            foreach (Monster monster in self.AllEnemy)
            {
                monster?.Dispose();
            }
            foreach (Tower tower in self.AllTower)
            {
                tower?.Dispose();
            }
            foreach (Base baseitem in self.AllBase)
            {
                baseitem?.Dispose();
            }
            self.AllEnemy.Clear();
            self.AllTower.Clear();
            self.AllBase.Clear();
            self.MonsterNavIdOne = 0;
            self.MonsterNavIdTwo = 0;
            await ETTask.CompletedTask;
        }
        public static async void OnLogicCreateMonster(this GameComponent self,int dt)//帧同步出怪
        {
            self.MonsterTimer = self.MonsterTimer + dt;
            if(self.CurrentMonsterIndex <= self.MonsterTime.Count - 1)
            {
                if (self.MonsterTimer >= self.MonsterTime[self.CurrentMonsterIndex])
                {
                    //出怪
                    if (self.GameEnding == false || self?.ZoneScene() == null) return;
                    await UnitFactory.CreateMonster(self.ZoneScene()?.CurrentScene(), self.MonsterId[self.CurrentMonsterIndex], IdGenerater.Instance.GenerateId(), self.MonsterNavIdOne, 1);
                    if (self.GameEnding == false || self?.ZoneScene() == null) return;
                    await UnitFactory.CreateMonster(self.ZoneScene()?.CurrentScene(), self.MonsterId[self.CurrentMonsterIndex], IdGenerater.Instance.GenerateId(), self.MonsterNavIdTwo, 2);
                    if (self.GameEnding == false || self?.ZoneScene() == null) return;

                    //end
                    self.CurrentMonsterIndex++;
                    self.OnLogicCreateMonster(0);
                }
            }    
        }
        public static async ETTask OnLogicUpdate(this GameComponent self,LogicFrame frame)
        {
            
            Unit unit = UnitHelper.GetMyUnitFromCurrentScene(self.ZoneScene().CurrentScene());
            NumericComponent num = unit.GetComponent<NumericComponent>();
            int currentframeid = num.GetAsInt(NumericType.Frameid);

            if(frame.frameid < currentframeid)
            {
                return;
            }
            for (int i=0;i<frame.unsync_frames.Count;i++)
            {
                if(currentframeid > frame.unsync_frames[i].frameid)
                {
                    continue;
                }
                else if (frame.unsync_frames[i].frameid >= frame.frameid)
                {
                    break;
                }
                if(self.SingleGameModeState == false)
                {
                    self.OnHandlerLogicGameStateEvent(frame);
                    break;
                }
                self.OnHandlerLogicEvent(frame.unsync_frames[i]);
            }
            num.Set(NumericType.Frameid, frame.frameid);//同步到当前帧Id
            self.Frameid = frame.frameid;
            /*if (frame.unsync_frames.Count > 0)
            {
                self.LastFrameOpt = frame.unsync_frames[frame.unsync_frames.Count - 1];
                self.OnHandlerLogicEvent(self.LastFrameOpt);
            }
            else
            {
                self.LastFrameOpt = null;
            }*/
            await ETTask.CompletedTask;
        }
        public static void OnHandlerLogicGameStateEvent(this GameComponent self, LogicFrame frame)
        {
            for (int i = 0; i < frame.unsync_frames.Count; i++)
            {
                FrameOpts frameopt = frame.unsync_frames[i];
                for(int j=0;j<frameopt.opts.Count;j++)
                {
                    OptionEvent optevent = frameopt.opts[j];
                    if (optevent.optType == (int)OptType.ContinueSingleGameMode)
                    {
                        self.SingleGameModeState = true;
                    }
                }
            }
        }
        public static void OnHandlerLogicEvent(this GameComponent self,FrameOpts frameopt)
        {
            if (self.GameEnding == false) return;
            //更新波次信息
            self.OnLogicUpdateWaveInfoToView(self.FrameDt);
            //怪的buff伤害
            self.OnLogicBuff(self.FrameDt);
            //子弹走路和伤害
            self.OnLogicBullet(self.FrameDt);
            //怪走路
            Game.EventSystem.PublishAsync(new EventType.LogicMonsterPos() { monsters = self.AllEnemy, FrameDt = self.FrameDt }).Coroutine();
            //塔发射子弹和充能
            self.OnLogicTower(self.FrameDt);
            //玩家操作
            for(int i = 0; i < frameopt.opts.Count;i++)
            {
                self.OnHandlerPlayerControl(frameopt.opts[i]);
            }
            //怪生成
            self.OnLogicCreateMonster(self.FrameDt);
            //处理金币
            self.OnLogicMoney(self.FrameDt);
            //判断是否上传frameid
            self.OnLogicUpLoadFrameId();
        }
        public static async void OnLogicUpdateWaveInfoToView(this GameComponent self, int dt)
        {
            self.WaveInfoTimer = self.WaveInfoTimer + dt;
            if (self.CurrentWaveNumber < self.WaveNumber.Count)
            {
                if (self.WaveInfoTimer >= self.WaveNumber[self.CurrentWaveNumber])//直接发布self.CurrentWaveNumber
                {
                    self.CurrentWaveNumber++;
                    List<int> CurrentWaveAllMonsterConfigId = self.GetCurrentWaveAllMonster();//获取当前波次所有怪物
                    Game.EventSystem.PublishAsync(new EventType.GameUpdateWaveInfo() { zonescene = self.ZoneScene(),CurrentWaveNumber = self.CurrentWaveNumber,CurrentWaveAllMonsterConfigId = CurrentWaveAllMonsterConfigId}).Coroutine();
                }
                if(self.WaveInfoTimer >= self.WaveNumber[self.CurrentWaveNumber] - self.MonsterWaveInterval && self.WaveInfoTimer < self.WaveNumber[self.CurrentWaveNumber])
                {
                    int Time = self.WaveNumber[self.CurrentWaveNumber] - self.WaveInfoTimer;
                    Game.EventSystem.PublishAsync(new EventType.GameUpdateTimeLeftInfo() { zonescene = self.ZoneScene(),Time = Time}).Coroutine();
                }
            }
            await ETTask.CompletedTask;
        }
        public static List<int> GetCurrentWaveAllMonster(this GameComponent self)//获取当前波次所有怪物
        {
            List<int> MonsterConfigId = new List<int>();
            int FormerTime = self.WaveNumber[self.CurrentWaveNumber - 1];
            int NextTime = self.WaveNumber[self.CurrentWaveNumber];
            for(int i=0;i<self.MonsterTime.Count;i++)
            {
                int currentmonstertime = self.MonsterTime[i];
                if(FormerTime<=currentmonstertime && currentmonstertime<=NextTime)
                {
                    MonsterConfigId.Add(self.MonsterId[i]);
                }
            }
            return MonsterConfigId;
        }
        public static async void OnHandlerPlayerControl(this GameComponent self,OptionEvent option)
        {
            int opttype = option.optType;

            NumericComponent num = UnitHelper.GetMyUnitFromCurrentScene(self.ZoneScene().CurrentScene()).GetComponent<NumericComponent>();
            int position = num.GetAsInt(NumericType.Position);
            int gamemoney = num.GetAsInt(NumericType.GameMoney);
            if(opttype == (int)OptType.PauseSingleGameMode)
            {
                self.SingleGameModeState = false;
            }
            if(opttype == (int)OptType.ContinueSingleGameMode)
            {
                self.SingleGameModeState = true;
            }
            if(opttype == (int)OptType.CreateTower)//造塔
            {
                Tower tower = await UnitFactory.CreateTower(self.ZoneScene().CurrentScene(), option.TowerConfigId, option.TowerX, option.TowerY, option.position, option.TowerId,option.SkillIds);
                if (option.position == position)//是自己买的
                {
                    TowerConfig towerconfig = TowerConfigCategory.Instance.Get(option.TowerConfigId);//造塔钱
                    int NeedMoney = towerconfig.Price;
                    num.Set(NumericType.GameMoney, gamemoney - NeedMoney);
                    Game.EventSystem.PublishAsync(new EventType.SettingTower()
                    {
                        zonescene = self.ZoneScene(),
                        tower = tower,
                        TowerId = option.TowerId,
                        mapid = num.GetAsInt(NumericType.MapId),
                        opttype = opttype,
                        towerX = option.TowerX,
                        towerY = option.TowerY,
                    }).Coroutine();
                }
            }

            if (opttype == (int)OptType.UpTower)//升级塔  这里的TowerConfigId是新的塔的Id
            {
                await UnitFactory.DeleteTower(self.ZoneScene().CurrentScene(), option.TowerId);
                Tower tower = await UnitFactory.CreateTower(self.ZoneScene().CurrentScene(), option.TowerConfigId, option.TowerX, option.TowerY, option.position, option.NewTowerId,option.SkillIds);
                if (option.position == position)//是自己买的
                {
                    TowerConfig towerconfig = TowerConfigCategory.Instance.Get(option.TowerConfigId);//造塔钱
                    int NeedMoney = towerconfig.Price;
                    num.Set(NumericType.GameMoney, gamemoney - NeedMoney);
                    Game.EventSystem.PublishAsync(new EventType.SettingTower()
                    {
                        zonescene = self.ZoneScene(),
                        tower = tower,
                        TowerId = option.NewTowerId,
                        mapid = num.GetAsInt(NumericType.MapId),
                        opttype = opttype,
                        towerX = option.TowerX,
                        towerY = option.TowerY,
                    }).Coroutine();
                } 
            }
            if (opttype == (int)OptType.DeleteTower)//卖塔 //钱不一样
            {
                await UnitFactory.DeleteTower(self.ZoneScene().CurrentScene(), option.TowerId);
                if (option.position == position)//是自己买的
                {
                    int level = (option.TowerConfigId - 1) % 3 + 1;
                    int allreturnmoney = 0;
                    for(int i=option.TowerConfigId - level + 1;i<=option.TowerConfigId;i++)
                    {
                        TowerConfig towerconfig = TowerConfigCategory.Instance.Get(i);//造塔钱
                        allreturnmoney = allreturnmoney + (int)((towerconfig.Price * 7)/10);
                        Log.Debug(((int)((towerconfig.Price * 7) / 10)).ToString());
                    }
                    Log.Debug(allreturnmoney.ToString());
                    
                    num.Set(NumericType.GameMoney, gamemoney + allreturnmoney);
                    Game.EventSystem.PublishAsync(new EventType.SettingTower()
                    {
                        zonescene = self.ZoneScene(),
                        mapid = num.GetAsInt(NumericType.MapId),
                        opttype = opttype,
                        towerX = option.TowerX,
                        towerY = option.TowerY,
                    }).Coroutine();
                } 
            }
            if (opttype == (int)OptType.CreateMonster)//买怪
            {
                if(option.position == position)//是自己买的
                {
                    MonsterConfig monsterconfig = MonsterConfigCategory.Instance.Get(option.MonsterConfigId);
                    int needmoney = monsterconfig.NeedMoney;
                    num.Set(NumericType.GameMoney, gamemoney - needmoney);
                }
                if(option.position == 1)
                {
                    await UnitFactory.CreateMonster(self.ZoneScene().CurrentScene(), option.MonsterConfigId,IdGenerater.Instance.GenerateId(), self.MonsterNavIdTwo, 2);
                }
                if(option.position == 2)
                {
                    await UnitFactory.CreateMonster(self.ZoneScene().CurrentScene(), option.MonsterConfigId,IdGenerater.Instance.GenerateId(), self.MonsterNavIdOne, 1);
                }
            }
        }
        public static async void OnLogicBuff(this GameComponent self,int dt)
        {
            List<Monster> monsters = self.AllEnemy;
            for(int i=0;i<monsters.Count;i++)
            {
                Monster m = monsters[i];
                m.OnLogicBuff(dt);
            }
            await ETTask.CompletedTask;
        }
        public static async void OnLogicMoney(this GameComponent self,int dt)
        {
            self.MoneyTimer = self.MoneyTimer + dt;
            if (self.MoneyTimer >= 5000)
            {
                self.MoneyTimer = self.MoneyTimer - 5000;
                Unit unit = UnitHelper.GetMyUnitFromCurrentScene(self.ZoneScene().CurrentScene());
                NumericComponent num = unit.GetComponent<NumericComponent>();
                num.Set(NumericType.GameMoney, num.GetAsInt(NumericType.GameMoney) + 1);
            }
            await ETTask.CompletedTask;
        }
        public static async void OnLogicTower(this GameComponent self,int dt)
        {
            List<Tower> towers = self.AllTower;
            for(int i=0;i<towers.Count;i++)
            {
                Tower tower = towers[i];
                tower.OnLogicUpdate(dt);
            }
            await ETTask.CompletedTask;
        }
        public static async void OnLogicBullet(this GameComponent self,int dt)
        {
            List<Bullet> bullets = self.AllBullet;
            for(int i=0;i<bullets.Count;i++)
            {
                Bullet bullet = bullets[i];
                bullet.OnLogic(dt);
            }
            await ETTask.CompletedTask;
        }
        public static async void OnLogicUpLoadFrameId(this GameComponent self)
        {
            if(self.Frameid % 2 == 0 )//10帧上传一次FrameId
            {
                UpLoadFrameId ulfid = new UpLoadFrameId() { frameid = self.Frameid };
                self.ZoneScene().GetComponent<SessionComponent>().Session.Send(ulfid);
            }
            await ETTask.CompletedTask;
        }
    }
}
