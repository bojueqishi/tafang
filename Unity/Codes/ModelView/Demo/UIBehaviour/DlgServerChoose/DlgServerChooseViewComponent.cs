
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgServerChooseViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button EButton_EnterButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_EnterButton == null )
     			{
		    		this.m_EButton_EnterButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_Enter");
     			}
     			return this.m_EButton_EnterButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_EnterImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_EnterImage == null )
     			{
		    		this.m_EButton_EnterImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_Enter");
     			}
     			return this.m_EButton_EnterImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_EnterText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_EnterText == null )
     			{
		    		this.m_ELabel_EnterText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EButton_Enter/ELabel_Enter");
     			}
     			return this.m_ELabel_EnterText;
     		}
     	}

		public UnityEngine.UI.LoopHorizontalScrollRect ELoopScrollList_ServerLoopHorizontalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_ServerLoopHorizontalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_ServerLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopHorizontalScrollRect>(this.uiTransform.gameObject,"ELoopScrollList_Server");
     			}
     			return this.m_ELoopScrollList_ServerLoopHorizontalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EButton_EnterButton = null;
			this.m_EButton_EnterImage = null;
			this.m_ELabel_EnterText = null;
			this.m_ELoopScrollList_ServerLoopHorizontalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_EButton_EnterButton = null;
		private UnityEngine.UI.Image m_EButton_EnterImage = null;
		private UnityEngine.UI.Text m_ELabel_EnterText = null;
		private UnityEngine.UI.LoopHorizontalScrollRect m_ELoopScrollList_ServerLoopHorizontalScrollRect = null;
		public Transform uiTransform = null;
	}
}
