using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	[FriendClass(typeof(DlgServerChoose))]
	[FriendClass(typeof(ServerInfosComponent))]
    [FriendClass(typeof(ServerInfo))]
    public static  class DlgServerChooseSystem
	{

		public static void RegisterUIEvent(this DlgServerChoose self)
		{
			self.View.EButton_EnterButton.AddListenerAsync(()=> { return self.EnterServerClick(); });
			self.View.ELoopScrollList_ServerLoopHorizontalScrollRect.AddItemRefreshListener((Transform transform, int index) => { self.OnScrollItemRefreshHandler(transform, index); });
		}

		public static void ShowWindow(this DlgServerChoose self, Entity contextData = null)
		{
			self.View.ELabel_EnterText.SetText("进入服务器");
			int count = self.ZoneScene().GetComponent<ServerInfosComponent>().ServerInfoList.Count;
			self.AddUIScrollItems(ref self.Items, count);
			self.View.ELoopScrollList_ServerLoopHorizontalScrollRect.SetVisible(true,count);
        }
		public static void HideWindow(this DlgServerChoose self)
		{
			self.RemoveUIScrollItems(ref self.Items);
		}
		public static async ETTask EnterServerClick(this DlgServerChoose self)
		{
			bool selectServer = self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId != 0;
			if(!selectServer)
			{
				Log.Error("先选择区服");
				return;
			}
			
			try
			{
				int errorCode = await LoginHelper.GetRoleInofs(self.ZoneScene());
                
                if (errorCode != ErrorCode.ERR_Success)
				{
					Log.Error(errorCode.ToString());
					return;
				}
			}
			catch(Exception e)
			{
				Log.Error(e.ToString());
				return;
			}

			
            self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_ServerChoose);
            self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Lobby);
        }
		public static void OnScrollItemRefreshHandler(this DlgServerChoose self,Transform transform,int index)
		{
			Scroll_Item_serverTest item = self.Items[index].BindTrans(transform);
			ServerInfo info = self.ZoneScene().GetComponent<ServerInfosComponent>().ServerInfoList[index];
			if(info.Id == self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId)
			{
				item.EI_serverTestImage.color = Color.red;
			}
			else
			{
				item.EI_serverTestImage.color = Color.black;
			}
			item.E_serverTestTipText.SetText(info.ServerName);
			item.EI_serverTestButton.AddListener(()=> { self.OnSelectServerItemHandler(info.Id); });

		}
		public static void OnSelectServerItemHandler(this DlgServerChoose self,long ServerId)
		{
			self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId = int.Parse(ServerId.ToString());

			self.View.ELoopScrollList_ServerLoopHorizontalScrollRect.RefillCells();
		}
	}
}
