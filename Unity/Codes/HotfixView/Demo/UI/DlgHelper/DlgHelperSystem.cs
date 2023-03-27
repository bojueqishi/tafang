using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgHelperSystem
	{
		public static void RegisterUIEvent(this DlgHelper self)
		{
			self.View.EButton_UpButton.AddListenerAsync(() => { return self.OnClickUp(); });
			/*self.View.ES_shuzhi1.RegisterEvent(NumericType.Power);
            self.View.ES_shuzhi2.RegisterEvent(NumericType.PhysicalStrength);
            self.View.ES_shuzhi3.RegisterEvent(NumericType.Agile);
            self.View.ES_shuzhi4.RegisterEvent(NumericType.Spirit);*/
			self.View.EButton_matchButton.AddListenerAsync(() => { return self.EnterMatch(); });
        }

		public static void ShowWindow(this DlgHelper self, Entity contextData = null)
		{
			self.Refresh().Coroutine();
		}
		public static async ETTask EnterMatch(this DlgHelper self)
		{
            try
            {
                int errorcode = await MatchHelper.EnterMatchList(self.ZoneScene());
                if (errorcode != ErrorCode.ERR_Success)
                {
                    return;
                }
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());

            }
        }
		public static async ETTask OnClickUp(this DlgHelper self)
		{
			try
			{
				int errorcode = await NumericHelper.TestUpdateNumeric(self.ZoneScene());
				if(errorcode != ErrorCode.ERR_Success)
				{
					return;
				}
			}
			catch(Exception e)
			{
				Log.Error(e.ToString());
				
			}
			Log.Debug(UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene()).GetComponent<NumericComponent>().GetAsInt(NumericType.Gold).ToString());
		}
		public static async ETTask Refresh(this DlgHelper self)
		{
			/*Unit unit = UnitHelper.GetMyUnitFromCurrentScene(self.ZoneScene().CurrentScene());
			NumericComponent component = unit.GetComponent<NumericComponent>();

            self.View.ELabel_expText.SetText("Exp:" + component.GetAsInt(NumericType.Exp).ToString());
            self.View.ELabel_goldText.SetText("Gold:" + component.GetAsLong(NumericType.Gold).ToString());
            self.View.ELabel_levelText.SetText("Exp:" + component.GetAsInt(NumericType.Level).ToString());
			self.View.ELabel_dsText.SetText("点数:" + component.GetAsInt(NumericType.AttributePoint).ToString());
			self.View.ES_shuzhi1.Refresh(NumericType.Power);
            self.View.ES_shuzhi2.Refresh(NumericType.PhysicalStrength);
            self.View.ES_shuzhi3.Refresh(NumericType.Agile);
            self.View.ES_shuzhi4.Refresh(NumericType.Spirit);
			Log.Debug(component.GetAsInt(NumericType.DamageValue).ToString());*/
        }
		 

	}
}
