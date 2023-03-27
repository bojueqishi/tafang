
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class ES_shuzhiAwakeSystem : AwakeSystem<ES_shuzhi,Transform> 
	{
		public override void Awake(ES_shuzhi self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ES_shuzhiDestroySystem : DestroySystem<ES_shuzhi> 
	{
		public override void Destroy(ES_shuzhi self)
		{
			self.DestroyWidget();
		}
	}
	public static class ES_shuzhiViewSystem
	{
		public static void Refresh(this ES_shuzhi self,int numbericType)
		{
			self.ELabel_shuzhiText.text = UnitHelper.GetMyUnitFromCurrentScene(self.ZoneScene().CurrentScene()).GetComponent<NumericComponent>().GetAsLong(numbericType).ToString();
		}
		public static void RegisterEvent(this ES_shuzhi self,int numbericType)
		{
			self.EButton_addButton.AddListenerAsync(() => { return self.RequestAddAttribute(numbericType); });
		}

		public static async ETTask RequestAddAttribute(this ES_shuzhi self,int numbericType)
		{
			try
			{
				int errorcode = await NumericHelper.RequestAddAttributePoint(self.ZoneScene(), numbericType);
				if(errorcode != ErrorCode.ERR_Success)
				{
					return;
				}
				//self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgHelper>()?.Refresh();
			}
			catch(Exception e)
			{
				Log.Error(e.ToString());
			}

			await ETTask.CompletedTask;
		}
	}

}
