namespace ET
{
    [MessageHandler]
    public class M2c_NoticeUnitNumericHandler : AMHandler<M2C_NoticeUnitNumeric>
    {
        protected override async void Run(Session session, M2C_NoticeUnitNumeric message)
        {
            session.ZoneScene().CurrentScene()?.GetComponent<UnitComponent>()?
                .Get(message.unitId)?.GetComponent<NumericComponent>()?.Set(message.NumericType, message.NewValue);
            await ETTask.CompletedTask;
        }
    }
}
