
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class Scroll_Item_shuzhi : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_shuzhi BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Text ELabel_shuzhiText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_ELabel_shuzhiText == null )
     				{
		    			this.m_ELabel_shuzhiText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_shuzhi");
     				}
     				return this.m_ELabel_shuzhiText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_shuzhi");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( this.m_EButton_addButton == null )
     				{
		    			this.m_EButton_addButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_add");
     				}
     				return this.m_EButton_addButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_add");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( this.m_EButton_addImage == null )
     				{
		    			this.m_EButton_addImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_add");
     				}
     				return this.m_EButton_addImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_add");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ELabel_shuzhiText = null;
			this.m_EButton_addButton = null;
			this.m_EButton_addImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Text m_ELabel_shuzhiText = null;
		private UnityEngine.UI.Button m_EButton_addButton = null;
		private UnityEngine.UI.Image m_EButton_addImage = null;
		public Transform uiTransform = null;
	}
}
