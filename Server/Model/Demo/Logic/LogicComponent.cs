
using System.Collections.Generic;

namespace ET
{

    public enum OptType
    {
        CreateTower = 1,
        UpTower = 2,
        DeleteTower = 3,
        CreateMonster = 4,
        PauseSingleGameMode = 5,
        ContinueSingleGameMode = 6,
    }

    public class LogicComponent : Entity , IAwake<int>,IDestroy
    {
        public int roomid;
        public int frameid;
        public List<FrameOpts> Frames;
        public FrameOpts NextFrameOpt;
        public long TimerId;
        public Unit BeforeUnit;
    }
}