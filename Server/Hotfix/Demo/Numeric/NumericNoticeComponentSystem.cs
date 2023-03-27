using ET.EventType;

namespace ET
{
    [FriendClass(typeof(NumericNoticeComponent))]
    public static class NumericNoticeComponentSystem 
    {
        public static void NoticeImmediately(this NumericNoticeComponent self,NumbericChange args)
        {
            Unit unit = self.GetParent<Unit>();
            self.M2C_NoticeUnitNumericMessage.unitId = unit.Id;
            self.M2C_NoticeUnitNumericMessage.NumericType = args.NumericType;
            self.M2C_NoticeUnitNumericMessage.NewValue = args.New;
            MessageHelper.SendToClient(unit, self.M2C_NoticeUnitNumericMessage);
        }
    }
    
}
