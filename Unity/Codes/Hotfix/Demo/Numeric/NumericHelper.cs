using System;

namespace ET
{
    public static class NumericHelper
    {
        public static async ETTask<int> TestUpdateNumeric(Scene zonescene)
        {
            M2C_TestUnitNumeric m2C_TestUnitNumeric = null;
            try
            {
                m2C_TestUnitNumeric = (M2C_TestUnitNumeric) await zonescene.GetComponent<SessionComponent>().Session.Call(new C2M_TestUnitNumeric(){ });

            }
            catch(Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if(m2C_TestUnitNumeric.Error != ErrorCode.ERR_Success)
            {
                Log.Error(m2C_TestUnitNumeric.Error.ToString());
                return m2C_TestUnitNumeric.Error;
            }

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> RequestAddAttributePoint(Scene zonescene,int numberic)
        {
            M2C_AddAttributePoint m2C_AddAttributePoint = null;
            try
            {
                m2C_AddAttributePoint = (M2C_AddAttributePoint) await zonescene.GetComponent<SessionComponent>().Session.Call(new C2M_AddAttributePoint() { NumericType = numberic });
            }
            catch(Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if(m2C_AddAttributePoint.Error != ErrorCode.ERR_Success)
            {
                Log.Error(m2C_AddAttributePoint.Error.ToString());
                return m2C_AddAttributePoint.Error;
            }
            

            return ErrorCode.ERR_Success;
        }
    }
}
