using System;

namespace ET
{
    public class C2M_AddAttributePointHandler : AMActorLocationRpcHandler<Unit, C2M_AddAttributePoint, M2C_AddAttributePoint>
    {
        protected override async ETTask Run(Unit unit, C2M_AddAttributePoint request, M2C_AddAttributePoint response, Action reply)
        {
            /*NumericComponent component = unit.GetComponent<NumericComponent>();
            int type = request.NumericType;
 
            PlayerNumericConfig config = PlayerNumericConfigCategory.Instance.Get(type);
            if(config.isAddPoint == 0)
            {
                response.Error = ErrorCode.ERR_NumericTypeNotAddPoint;
                reply();
                return;
            }

            int AddPointCount = component.GetAsInt(NumericType.AttributePoint);

            if(AddPointCount <= 0)
            {
                response.Error = ErrorCode.ERR_AddPointNotEnough;
                reply();
                return;
            }

            --AddPointCount;
            component.Set(NumericType.AttributePoint, AddPointCount);

            int targetAttributeCount = component.GetAsInt(type) + 1;
            component.Set(type, targetAttributeCount);
            reply();
            await component.AddOrUpdateUnitCache();*/
            reply();
            await ETTask.CompletedTask;
        }
    }
}
