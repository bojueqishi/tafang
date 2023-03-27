
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgLobbyViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EGBackGroundRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGBackGroundRectTransform == null )
     			{
		    		this.m_EGBackGroundRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EGBackGround");
     			}
     			return this.m_EGBackGroundRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_EnterMapButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterMapButton == null )
     			{
		    		this.m_E_EnterMapButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_EnterMap");
     			}
     			return this.m_E_EnterMapButton;
     		}
     	}

		public UnityEngine.UI.Image E_EnterMapImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterMapImage == null )
     			{
		    		this.m_E_EnterMapImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_EnterMap");
     			}
     			return this.m_E_EnterMapImage;
     		}
     	}

		public UnityEngine.UI.Text ETextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ETextText == null )
     			{
		    		this.m_ETextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EGBackGround/E_EnterMap/EText");
     			}
     			return this.m_ETextText;
     		}
     	}

		public UnityEngine.UI.Button EButton_createroleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_createroleButton == null )
     			{
		    		this.m_EButton_createroleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/EButton_createrole");
     			}
     			return this.m_EButton_createroleButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_createroleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_createroleImage == null )
     			{
		    		this.m_EButton_createroleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/EButton_createrole");
     			}
     			return this.m_EButton_createroleImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_createroleText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_createroleText == null )
     			{
		    		this.m_ELabel_createroleText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EGBackGround/EButton_createrole/ELabel_createrole");
     			}
     			return this.m_ELabel_createroleText;
     		}
     	}

		public UnityEngine.UI.Button EButton_deleteroleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_deleteroleButton == null )
     			{
		    		this.m_EButton_deleteroleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/EButton_deleterole");
     			}
     			return this.m_EButton_deleteroleButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_deleteroleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_deleteroleImage == null )
     			{
		    		this.m_EButton_deleteroleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/EButton_deleterole");
     			}
     			return this.m_EButton_deleteroleImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_deleteroleText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_deleteroleText == null )
     			{
		    		this.m_ELabel_deleteroleText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EGBackGround/EButton_deleterole/ELabel_deleterole");
     			}
     			return this.m_ELabel_deleteroleText;
     		}
     	}

		public UnityEngine.UI.LoopHorizontalScrollRect ELoopScrollList_roleinfoLoopHorizontalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_roleinfoLoopHorizontalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_roleinfoLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopHorizontalScrollRect>(this.uiTransform.gameObject,"EGBackGround/ELoopScrollList_roleinfo");
     			}
     			return this.m_ELoopScrollList_roleinfoLoopHorizontalScrollRect;
     		}
     	}

		public UnityEngine.UI.InputField E_RoleNameInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoleNameInputField == null )
     			{
		    		this.m_E_RoleNameInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"EGBackGround/E_RoleName");
     			}
     			return this.m_E_RoleNameInputField;
     		}
     	}

		public UnityEngine.UI.Image E_RoleNameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoleNameImage == null )
     			{
		    		this.m_E_RoleNameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_RoleName");
     			}
     			return this.m_E_RoleNameImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EGBackGroundRectTransform = null;
			this.m_E_EnterMapButton = null;
			this.m_E_EnterMapImage = null;
			this.m_ETextText = null;
			this.m_EButton_createroleButton = null;
			this.m_EButton_createroleImage = null;
			this.m_ELabel_createroleText = null;
			this.m_EButton_deleteroleButton = null;
			this.m_EButton_deleteroleImage = null;
			this.m_ELabel_deleteroleText = null;
			this.m_ELoopScrollList_roleinfoLoopHorizontalScrollRect = null;
			this.m_E_RoleNameInputField = null;
			this.m_E_RoleNameImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EGBackGroundRectTransform = null;
		private UnityEngine.UI.Button m_E_EnterMapButton = null;
		private UnityEngine.UI.Image m_E_EnterMapImage = null;
		private UnityEngine.UI.Text m_ETextText = null;
		private UnityEngine.UI.Button m_EButton_createroleButton = null;
		private UnityEngine.UI.Image m_EButton_createroleImage = null;
		private UnityEngine.UI.Text m_ELabel_createroleText = null;
		private UnityEngine.UI.Button m_EButton_deleteroleButton = null;
		private UnityEngine.UI.Image m_EButton_deleteroleImage = null;
		private UnityEngine.UI.Text m_ELabel_deleteroleText = null;
		private UnityEngine.UI.LoopHorizontalScrollRect m_ELoopScrollList_roleinfoLoopHorizontalScrollRect = null;
		private UnityEngine.UI.InputField m_E_RoleNameInputField = null;
		private UnityEngine.UI.Image m_E_RoleNameImage = null;
		public Transform uiTransform = null;
	}
}
