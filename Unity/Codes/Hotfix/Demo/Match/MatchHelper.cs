using System;

namespace ET
{
    public static class MatchHelper
    {
        public static async ETTask<int> EnterMatchList(Scene zonescene)
        {
            M2C_EnterMatch m2C_EnterMatch = null;
            try
            {
                m2C_EnterMatch = (M2C_EnterMatch)await zonescene.GetComponent<SessionComponent>().Session.Call(new C2M_EnterMatch() { MatchMode = 2});
            }
            catch(Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if(m2C_EnterMatch.Error != ErrorCode.ERR_Success)
            {
                Log.Error(m2C_EnterMatch.Error.ToString());
                return m2C_EnterMatch.Error;
            }
            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }
        public static async ETTask<int> EnterSingleMode(Scene zonescene,int MapId)
        {
            M2C_EnterMatch m2C_EnterMatch = null;
            try
            {
                m2C_EnterMatch = (M2C_EnterMatch)await zonescene.GetComponent<SessionComponent>().Session.Call(new C2M_EnterMatch() { MapId = MapId,MatchMode = 1 });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if (m2C_EnterMatch.Error != ErrorCode.ERR_Success)
            {
                Log.Error(m2C_EnterMatch.Error.ToString());
                return m2C_EnterMatch.Error;
            }

            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }
        public static async ETTask<int> CancelMatchList(Scene zonescene)
        {
            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }
    }
}
