using System;
using System.Collections.Generic;

namespace ET
{
    public enum OptType
    {
        CreateTower = 1,
        UpTower = 2,
        DeleteTower = 3,
        CreateMonster = 4 ,
        PauseSingleGameMode = 5,
        ContinueSingleGameMode = 6,
    }
    [ComponentOf(typeof(Scene))]
    public class GameComponent : Entity,IAwake,IDestroy
    {
        public bool GameEnding;
        public int MonsterNavIdOne;
        public int MonsterNavIdTwo;
        public long MonsterWaveInterval;
        public List<MonsterWaveConfig> waves;
        public Dictionary<int, List<MonsterWaveConfig>> wavedic;
        public List<int> WaveNumber;
        public List<Monster> AllEnemy;
        public List<Tower> AllTower;
        public List<Bullet> AllBullet;
        public List<Base> AllBase;
        public int MonsterTimer;
        public int WaveInfoTimer;
        public int CurrentWaveNumber;
        public List<int> MonsterTime;
        public List<int> MonsterId;
        public int CurrentMonsterIndex;
        public Base Base1;
        public Base Base2;
        public int LogicTimer;
        public int FrameDt;
        public int Frameid;
        public FrameOpts LastFrameOpt;
        public int MoneyTimer;
        public List<OptionEvent> NextOpts;
        public int MapId;
        public float MaxVisualX;
        public float MaxVisualY;
        public bool SingleGameModeState;
    }
}
