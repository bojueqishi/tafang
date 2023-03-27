namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class NumericNoticeComponent : Entity,IAwake
    {
        public M2C_NoticeUnitNumeric M2C_NoticeUnitNumericMessage = new M2C_NoticeUnitNumeric(); 
    }
}
