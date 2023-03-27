using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	[FriendClass(typeof(RoleInfosComponent))]
	[FriendClass(typeof(DlgLobby))]
	[FriendClass(typeof(RoleInfo))]
	public static  class DlgLobbySystem
	{

		public static void RegisterUIEvent(this DlgLobby self)
		{
		    self.View.E_EnterMapButton.AddListener(()=>
		    {
		        self.OnEnterMapClickHandler().Coroutine();
			});
			self.View.EButton_createroleButton.AddListenerAsync( ()=> { return self.OnCreateRole(); } );
            self.View.EButton_deleteroleButton.AddListenerAsync(() => { return self.OnDeleteRole(); });
            self.View.ELoopScrollList_roleinfoLoopHorizontalScrollRect.AddItemRefreshListener((Transform transform,int index) => { self.ScrollRefresh(transform, index); });
		}
		public static async ETTask OnDeleteRole(this DlgLobby self)
		{
			if(self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId == 0)
			{
				Log.Error("请选择游戏角色");
				return;
			}
			try
			{
				int errorCode = await LoginHelper.DeleteRole(self.ZoneScene());
				if(errorCode != ErrorCode.ERR_Success)
				{
					Log.Error(errorCode.ToString());
					return;
				}
                self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Lobby);
                self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Lobby);

            }
			catch(Exception e)
			{
				Log.Error(e.ToString());
				return;
			}
			await ETTask.CompletedTask;
		}
		public static void ShowWindow(this DlgLobby self, Entity contextData = null)
		{
			self.View.ELabel_createroleText.SetText("创建角色");
			self.View.ELabel_deleteroleText.SetText("删除角色");
			self.View.ETextText.SetText("进入地图");
            int count = self.ZoneScene().GetComponent<RoleInfosComponent>().RoleInfos.Count;
            self.AddUIScrollItems(ref self.items, count);
            self.View.ELoopScrollList_roleinfoLoopHorizontalScrollRect.SetVisible(true, count);
        }
		public static async ETTask OnCreateRole(this DlgLobby self)
		{
			await LoginHelper.CreateRole(self.ZoneScene(),self.View.E_RoleNameInputField.GetComponent<InputField>().text);
            self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Lobby);
            self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Lobby);
        }

		public static async ETTask OnEnterMapClickHandler(this DlgLobby self)
		{
			if(self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId == 0)
			{
				Log.Error("请选择进入地图的角色");
				return;
			}

			try
			{
				int errorCode = await LoginHelper.GetRealmKey(self.ZoneScene());
				if(errorCode != ErrorCode.ERR_Success)
				{
					Log.Error(errorCode.ToString());
					return;
				}

				errorCode = await LoginHelper.EnterGame(self.ZoneScene());
				if(errorCode != ErrorCode.ERR_Success)
				{
					Log.Error(errorCode.ToString());
					return;
				}
				self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Lobby);
                self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_MainHome);
            }
			catch(Exception e)
			{
				Log.Error(e.ToString());
				return;
			}	
		}
		public static void ScrollRefresh(this DlgLobby self,Transform transform,int index)
		{
            Scroll_Item_roleInfo roleinfo = self.items[index].BindTrans(transform);
			RoleInfo role = self.ZoneScene().GetComponent<RoleInfosComponent>().RoleInfos[index];
			roleinfo.ELabel_nameText.SetText(role.Name);
			if (self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId == index + 1)
			{
				roleinfo.EImageImage.color = Color.red;
			}
			else roleinfo.EImageImage.color = Color.black;
			roleinfo.EImageButton.AddListener(() => { self.OnSelectRoleItemHandler(index + 1); });
		}

        public static void OnSelectRoleItemHandler(this DlgLobby self, long roleId)
        {
            self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId = int.Parse(roleId.ToString());

            self.View.ELoopScrollList_roleinfoLoopHorizontalScrollRect.RefillCells();
        }
    }
}
