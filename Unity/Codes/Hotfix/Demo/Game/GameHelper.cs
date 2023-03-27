using ProtoBuf;
using System;
using System.Collections.Generic;

namespace ET
{
    [FriendClass(typeof(GameComponent))]
    public static class GameHelper
    {
        public static async ETTask<int> AddRoomIndex(Scene zonescene)
        {
            G2C_AddGameRoom g2C_AddGameRoom = null;
            try
            {
                g2C_AddGameRoom = (G2C_AddGameRoom)await zonescene.GetComponent<SessionComponent>().Session.Call(new C2G_AddGameRoom() { });
            }
            catch(Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if (g2C_AddGameRoom.Error != ErrorCode.ERR_Success)
            {
                Log.Error(g2C_AddGameRoom.Error.ToString());
                return g2C_AddGameRoom.Error;
            }
            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }
        public static async ETTask<int> GetReadyGame(Scene zonescene)
        {
            G2C_GetReadyGame g2C_GetReadyGame = null;
            try
            {
                g2C_GetReadyGame = (G2C_GetReadyGame)await zonescene.GetComponent<SessionComponent>().Session.Call(new C2G_GetReadyGame() {});
            }
            catch(Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if(g2C_GetReadyGame.Error != ErrorCode.ERR_Success)
            {
                Log.Error(g2C_GetReadyGame.Error.ToString());
                return g2C_GetReadyGame.Error;
            }
            return ErrorCode.ERR_Success;
        }
        public static async ETTask<int> CancelReadyGame(Scene zonescene)
        {
            G2C_CancelReadyGame g2C_CancelReadyGame = null;
            try
            {
                g2C_CancelReadyGame = (G2C_CancelReadyGame)await zonescene.GetComponent<SessionComponent>().Session.Call(new C2G_CancelReadyGame() { });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if (g2C_CancelReadyGame.Error != ErrorCode.ERR_Success)
            {
                Log.Error(g2C_CancelReadyGame.Error.ToString());
                return g2C_CancelReadyGame.Error;
            }
            return ErrorCode.ERR_Success;
        }
        public static async ETTask<int> CreateTower(Scene zonescene,int TowerConfigId,float PX,float PY)
        {
            FightItemComponent fightitemcomponent = zonescene.GetComponent<FightItemComponent>();
            List<int> skillids = fightitemcomponent.GetSkillIdByFightItem(TowerConfigId);
            NextFrameOpts nextframeopts = new NextFrameOpts();
            List<OptionEvent> opts = new List<OptionEvent>();
            NumericComponent num = UnitHelper.GetMyUnitFromCurrentScene(zonescene.CurrentScene()).GetComponent<NumericComponent>();
            int frameid = num.GetAsInt(NumericType.Frameid);
            int gameroomframeid = zonescene.CurrentScene().GetComponent<GameComponent>().Frameid;
            nextframeopts.frameid = gameroomframeid;
            OptionEvent opt = new OptionEvent() { position = num.GetAsInt(NumericType.Position), optType = (int)(OptType.CreateTower), TowerConfigId = TowerConfigId, TowerX = PX, TowerY = PY ,SkillIds = skillids };
            opts.Add(opt);
            nextframeopts.opts = opts;
            zonescene.GetComponent<SessionComponent>().Session.Send(nextframeopts);
            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }
        public static async ETTask<int> UpTower(Scene zonescene, int TowerConfigId, long TowerId,float PX,float PY)
        {
            FightItemComponent fightitemcomponent = zonescene.GetComponent<FightItemComponent>();
            List<int> skillids = fightitemcomponent.GetSkillIdByFightItem(TowerConfigId);
            NextFrameOpts nextframeopts = new NextFrameOpts();
            List<OptionEvent> opts = new List<OptionEvent>();
            NumericComponent num = UnitHelper.GetMyUnitFromCurrentScene(zonescene.CurrentScene()).GetComponent<NumericComponent>();
            int frameid = num.GetAsInt(NumericType.Frameid);
            int gameroomframeid = zonescene.CurrentScene().GetComponent<GameComponent>().Frameid;
            nextframeopts.frameid = gameroomframeid;
            OptionEvent opt = new OptionEvent() { position = num.GetAsInt(NumericType.Position), optType = (int)(OptType.UpTower), TowerId = TowerId,TowerConfigId = TowerConfigId,TowerX = PX,TowerY = PY,SkillIds = skillids };
            opts.Add(opt);
            nextframeopts.opts = opts;
            zonescene.GetComponent<SessionComponent>().Session.Send(nextframeopts);
            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }
        public static async ETTask<int> PauseSingleGameMode(Scene zonescene)
        {
            NextFrameOpts nextframeopts = new NextFrameOpts();
            List<OptionEvent> opts = new List<OptionEvent>();
            NumericComponent num = UnitHelper.GetMyUnitFromCurrentScene(zonescene.CurrentScene()).GetComponent<NumericComponent>();
            int frameid = num.GetAsInt(NumericType.Frameid);
            int gameroomframeid = zonescene.CurrentScene().GetComponent<GameComponent>().Frameid;
            nextframeopts.frameid = gameroomframeid;
            OptionEvent opt = new OptionEvent() { optType = (int)(OptType.PauseSingleGameMode)};
            opts.Add(opt);
            nextframeopts.opts = opts;
            zonescene.GetComponent<SessionComponent>().Session.Send(nextframeopts);
            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }
        public static async ETTask<int> ContinueSingleGameMode(Scene zonescene)
        {
            NextFrameOpts nextframeopts = new NextFrameOpts();
            List<OptionEvent> opts = new List<OptionEvent>();
            NumericComponent num = UnitHelper.GetMyUnitFromCurrentScene(zonescene.CurrentScene()).GetComponent<NumericComponent>();
            int frameid = num.GetAsInt(NumericType.Frameid);
            int gameroomframeid = zonescene.CurrentScene().GetComponent<GameComponent>().Frameid;
            nextframeopts.frameid = gameroomframeid;
            OptionEvent opt = new OptionEvent() { optType = (int)(OptType.ContinueSingleGameMode) };
            opts.Add(opt);
            nextframeopts.opts = opts;
            zonescene.GetComponent<SessionComponent>().Session.Send(nextframeopts);
            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }
        public static async ETTask<int> DeleteTower(Scene zonescene, long TowerId,int TowerConfigId,float PX,float PY)
        {
            NextFrameOpts nextframeopts = new NextFrameOpts();
            List<OptionEvent> opts = new List<OptionEvent>();
            NumericComponent num = UnitHelper.GetMyUnitFromCurrentScene(zonescene.CurrentScene()).GetComponent<NumericComponent>();
            int frameid = num.GetAsInt(NumericType.Frameid);
            int gameroomframeid = zonescene.CurrentScene().GetComponent<GameComponent>().Frameid;
            nextframeopts.frameid = gameroomframeid;
            OptionEvent opt = new OptionEvent() { position = num.GetAsInt(NumericType.Position), optType = (int)(OptType.DeleteTower), TowerId = TowerId,TowerConfigId = TowerConfigId,TowerX = PX,TowerY = PY };
            opts.Add(opt);
            nextframeopts.opts = opts;
            zonescene.GetComponent<SessionComponent>().Session.Send(nextframeopts);
            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }
        public static async ETTask<int> CreateMonster(Scene zonescene, int MonsterConfigId) // roomindex后续删除 position后续删除
        {
            NextFrameOpts nextframeopts = new NextFrameOpts();
            List<OptionEvent> opts = new List<OptionEvent>();
            NumericComponent num = UnitHelper.GetMyUnitFromCurrentScene(zonescene.CurrentScene()).GetComponent<NumericComponent>();
            int frameid = num.GetAsInt(NumericType.Frameid);
            int gameroomframeid = zonescene.CurrentScene().GetComponent<GameComponent>().Frameid;
            nextframeopts.frameid = gameroomframeid;
            Log.Debug(nextframeopts.frameid.ToString());
            OptionEvent opt = new OptionEvent() { position = num.GetAsInt(NumericType.Position), optType = (int)(OptType.CreateMonster), MonsterConfigId = MonsterConfigId };
            opts.Add(opt);
            nextframeopts.opts = opts;
            zonescene.GetComponent<SessionComponent>().Session.Send(nextframeopts);
            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }
        public static async ETTask<int> RequestWin(Scene zonescene,int position)
        {
            Unit unit = UnitHelper.GetMyUnitFromCurrentScene(zonescene.CurrentScene());
            NumericComponent numeric = unit.GetComponent<NumericComponent>();
            int roomIndex = numeric.GetAsInt(NumericType.RoomIndex);
            G2C_WinGame g2C_WinGame = null;
            try
            {
                g2C_WinGame = (G2C_WinGame)await zonescene.GetComponent<SessionComponent>().Session.Call(new C2G_WinGame()
                {
                    RoomIndex = roomIndex,
                    Position = position
                });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }
            if (g2C_WinGame.Error != ErrorCode.ERR_Success)
            {
                Log.Error(g2C_WinGame.Error.ToString());
                return g2C_WinGame.Error;
            }
            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }
        public static async ETTask<int> ExitGameAndEnterMainHome(Scene zonescene)
        {
            Unit unit = UnitHelper.GetMyUnitFromCurrentScene(zonescene.CurrentScene());
            Log.Debug("132");
            G2C_ExitGameAndEnterMainHome g2C_ExitGameAndEnterMainHome = null;
            try
            {
                g2C_ExitGameAndEnterMainHome = (G2C_ExitGameAndEnterMainHome)await zonescene.GetComponent<SessionComponent>().Session.Call(new C2G_ExitGameAndEnterMainHome(){});
                Log.Debug("1342");
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }
            if (g2C_ExitGameAndEnterMainHome.Error != ErrorCode.ERR_Success)
            {
                Log.Error(g2C_ExitGameAndEnterMainHome.Error.ToString());
                return g2C_ExitGameAndEnterMainHome.Error;
            }
            Log.Debug("132455");
            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }
    }
}
