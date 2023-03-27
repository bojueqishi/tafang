
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class ES_shuzhi : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Text ELabel_shuzhiText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_shuzhiText == null )
     			{
		    		this.m_ELabel_shuzhiText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_shuzhi");
     			}
     			return this.m_ELabel_shuzhiText;
     		}
     	}

		public UnityEngine.UI.Button EButton_addButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_addButton == null )
     			{
		    		this.m_EButton_addButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_add");
     			}
     			return this.m_EButton_addButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_addImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_addImage == null )
     			{
		    		this.m_EButton_addImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_add");
     			}
     			return this.m_EButton_addImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ELabel_shuzhiText = null;
			this.m_EButton_addButton = null;
			this.m_EButton_addImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_ELabel_shuzhiText = null;
		private UnityEngine.UI.Button m_EButton_addButton = null;
		private UnityEngine.UI.Image m_EButton_addImage = null;
		public Transform uiTransform = null;
	}
}
