using System;

namespace ET
{
    public class C2M_TestUnitNumericHandler : AMActorLocationRpcHandler<Unit, C2M_TestUnitNumeric, M2C_TestUnitNumeric>
    {
        protected override async ETTask Run(Unit unit, C2M_TestUnitNumeric request, M2C_TestUnitNumeric response, Action reply)
        {
            NumericComponent component = unit.GetComponent<NumericComponent>();
 
            //int newGold = component.GetAsInt(NumericType.Gold) + 100;
            long newExp = component.GetAsLong(NumericType.Exp) + 50;
            long newLevel = component.GetAsLong(NumericType.Level) + 1;

            //component.Set(NumericType.Gold, newGold);
            component.Set(NumericType.Exp, newExp);
            component.Set(NumericType.Level, newLevel);

            reply();
            await ETTask.CompletedTask;
        }
    }
}
