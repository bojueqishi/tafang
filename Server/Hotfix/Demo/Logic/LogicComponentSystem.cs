using System.Collections.Generic;
using System.Reflection.Emit;

namespace ET
{
    [Timer(TimerType.OnLogicFrame)]
    [FriendClass(typeof(LogicComponent))]
    public class LogicFrameTimer : ATimer<LogicComponent>
    {
        public override async void Run(LogicComponent self)
        {
            self.Frames.Add(self.NextFrameOpt);
            GameRoomComponent gameroomcomponent = self.DomainScene().GetComponent<GameRoomComponent>();
            List<Unit> units = gameroomcomponent.Get(self.roomid);
            for(int i=0;i<units.Count; i++)
            {
                Unit unit = units[i];
                if (unit != null)
                {
                    self.SendLogic(unit);
                }
            }
            self.frameid = self.frameid + 1;
            self.NextFrameOpt = new FrameOpts() { frameid = self.frameid, opts = new List<OptionEvent>()};
            await ETTask.CompletedTask;
        }
    }
    public class LogicComponentAwakeSystem : AwakeSystem<LogicComponent,int>
    {
        public override void Awake(LogicComponent self,int roomid)
        {
            self.roomid = roomid;
            self.frameid = 1;
            self.Frames = new List<FrameOpts>();
            self.NextFrameOpt = new FrameOpts() { frameid = self.frameid, opts = new List<OptionEvent>()};
            self.TimerId = TimerComponent.Instance.NewRepeatedTimer(66, TimerType.OnLogicFrame, self);
        }
    }
    [FriendClass(typeof(LogicComponent))]
    public static class LogicComponentSystem
    {
        public static void SendLogic(this LogicComponent self,Unit unit)
        {
            List<FrameOpts> nextopts = new List<FrameOpts>();//客户端未同步的帧的集合
            int currentFrameid = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.Frameid);
            for(int i = currentFrameid;i<self.Frames.Count;i++)
            {
                nextopts.Add(self.Frames[i]);  
            }
            LogicFrame logicframe = new LogicFrame() { frameid = self.frameid, unsync_frames = nextopts };
            MessageHelper.SendToClient(unit, logicframe);
        }
        public static async void AsyncPlayerFrameId(this LogicComponent self,Unit unit,int frameid)
        {
            NumericComponent num = unit.GetComponent<NumericComponent>();//最新的客户端的Unit的numericcomponent
            List<Unit> units = self.GetParent<GameRoomComponent>().Get(self.roomid);
            for (int i = 0; i < units.Count; i++)
            {
                if (units[i].Id == unit.Id)
                {
                    self.BeforeUnit = units[i];
                }
            }
            self.BeforeUnit.GetComponent<NumericComponent>().SetNoEvent(NumericType.Frameid, frameid);
            await ETTask.CompletedTask;
        }
        public static async void AddNextFrameOpt(this LogicComponent self,Unit unit,NextFrameOpts nextframeopts)
        {
            using(await CoroutineLockComponent.Instance.Wait(CoroutineLockType.OptionType,unit.Id))
            {
                if (unit == null) return;

                NumericComponent num = unit.GetComponent<NumericComponent>();//最新的客户端的Unit的numericcomponent
                List<Unit> units = self.GetParent<GameRoomComponent>().Get(self.roomid);
                for (int i = 0; i < units.Count; i++)
                {
                    if (units[i].Id == unit.Id)
                    {
                        self.BeforeUnit = units[i];
                    }
                }
                int Playerframeid = self.BeforeUnit.GetComponent<NumericComponent>().GetAsInt(NumericType.Frameid);//原来的房间里面的UnitId的映射
                int optsframeid = nextframeopts.frameid;
                if (Playerframeid < optsframeid - 1)
                {
                    Playerframeid = optsframeid - 1;
                    self.BeforeUnit.GetComponent<NumericComponent>().SetNoEvent(NumericType.Frameid, Playerframeid);
                }
                if (self.frameid - nextframeopts.frameid > 2) return;
                for (int i = 0; i < nextframeopts.opts.Count; i++)
                {
                    OptionEvent optevent = nextframeopts.opts[i];
                    OptionEvent newoptevent = new OptionEvent();
                    int opttype = optevent.optType;
                    newoptevent.position = optevent.position;
                    newoptevent.optType = optevent.optType;
                    if (opttype == (int)OptType.CreateTower)
                    {
                        long TowerId = IdGenerater.Instance.GenerateId();
                        newoptevent.TowerId = TowerId;
                        newoptevent.TowerConfigId = optevent.TowerConfigId;
                        newoptevent.TowerX = optevent.TowerX;
                        newoptevent.TowerY = optevent.TowerY;
                        newoptevent.SkillIds = optevent.SkillIds;
                    }
                    if (opttype == (int)OptType.UpTower)
                    {
                        newoptevent.TowerId = optevent.TowerId;//老的塔的Id
                        newoptevent.TowerConfigId = optevent.TowerConfigId;//新的塔configId
                        long NewTowerId = IdGenerater.Instance.GenerateId();//新的塔的Id
                        newoptevent.NewTowerId = NewTowerId;
                        newoptevent.TowerX = optevent.TowerX;
                        newoptevent.TowerY = optevent.TowerY;
                        newoptevent.SkillIds = optevent.SkillIds;
                    }
                    if (opttype == (int)OptType.DeleteTower)
                    {
                        newoptevent.TowerId = optevent.TowerId;
                        newoptevent.TowerConfigId = optevent.TowerConfigId;
                        newoptevent.TowerX = optevent.TowerX;
                        newoptevent.TowerY = optevent.TowerY;
                    }
                    if (opttype == (int)OptType.CreateMonster)
                    {
                        newoptevent.MonsterConfigId = optevent.MonsterConfigId;
                    }
                    self.NextFrameOpt.opts.Add(newoptevent);
                }
            }
        }
    }
   
}
