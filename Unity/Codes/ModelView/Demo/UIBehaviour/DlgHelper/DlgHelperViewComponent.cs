
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgHelperViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Text E_TipText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TipText == null )
     			{
		    		this.m_E_TipText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Tip");
     			}
     			return this.m_E_TipText;
     		}
     	}

		public UnityEngine.UI.Button EButton_UpButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_UpButton == null )
     			{
		    		this.m_EButton_UpButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_Up");
     			}
     			return this.m_EButton_UpButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_UpImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_UpImage == null )
     			{
		    		this.m_EButton_UpImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_Up");
     			}
     			return this.m_EButton_UpImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_levelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_levelText == null )
     			{
		    		this.m_ELabel_levelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_level");
     			}
     			return this.m_ELabel_levelText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_expText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_expText == null )
     			{
		    		this.m_ELabel_expText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_exp");
     			}
     			return this.m_ELabel_expText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_goldText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_goldText == null )
     			{
		    		this.m_ELabel_goldText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_gold");
     			}
     			return this.m_ELabel_goldText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_dsText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_dsText == null )
     			{
		    		this.m_ELabel_dsText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_ds");
     			}
     			return this.m_ELabel_dsText;
     		}
     	}

		public ES_shuzhi ES_shuzhi1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_shuzhi1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_shuzhi1");
		    	   this.m_es_shuzhi1 = this.AddChild<ES_shuzhi,Transform>(subTrans);
     			}
     			return this.m_es_shuzhi1;
     		}
     	}

		public ES_shuzhi ES_shuzhi2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_shuzhi2 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_shuzhi2");
		    	   this.m_es_shuzhi2 = this.AddChild<ES_shuzhi,Transform>(subTrans);
     			}
     			return this.m_es_shuzhi2;
     		}
     	}

		public ES_shuzhi ES_shuzhi3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_shuzhi3 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_shuzhi3");
		    	   this.m_es_shuzhi3 = this.AddChild<ES_shuzhi,Transform>(subTrans);
     			}
     			return this.m_es_shuzhi3;
     		}
     	}

		public ES_shuzhi ES_shuzhi4
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_shuzhi4 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_shuzhi4");
		    	   this.m_es_shuzhi4 = this.AddChild<ES_shuzhi,Transform>(subTrans);
     			}
     			return this.m_es_shuzhi4;
     		}
     	}

		public UnityEngine.UI.Button EButton_matchButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_matchButton == null )
     			{
		    		this.m_EButton_matchButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_match");
     			}
     			return this.m_EButton_matchButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_matchImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_matchImage == null )
     			{
		    		this.m_EButton_matchImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_match");
     			}
     			return this.m_EButton_matchImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_TipText = null;
			this.m_EButton_UpButton = null;
			this.m_EButton_UpImage = null;
			this.m_ELabel_levelText = null;
			this.m_ELabel_expText = null;
			this.m_ELabel_goldText = null;
			this.m_ELabel_dsText = null;
			this.m_es_shuzhi1?.Dispose();
			this.m_es_shuzhi1 = null;
			this.m_es_shuzhi2?.Dispose();
			this.m_es_shuzhi2 = null;
			this.m_es_shuzhi3?.Dispose();
			this.m_es_shuzhi3 = null;
			this.m_es_shuzhi4?.Dispose();
			this.m_es_shuzhi4 = null;
			this.m_EButton_matchButton = null;
			this.m_EButton_matchImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_E_TipText = null;
		private UnityEngine.UI.Button m_EButton_UpButton = null;
		private UnityEngine.UI.Image m_EButton_UpImage = null;
		private UnityEngine.UI.Text m_ELabel_levelText = null;
		private UnityEngine.UI.Text m_ELabel_expText = null;
		private UnityEngine.UI.Text m_ELabel_goldText = null;
		private UnityEngine.UI.Text m_ELabel_dsText = null;
		private ES_shuzhi m_es_shuzhi1 = null;
		private ES_shuzhi m_es_shuzhi2 = null;
		private ES_shuzhi m_es_shuzhi3 = null;
		private ES_shuzhi m_es_shuzhi4 = null;
		private UnityEngine.UI.Button m_EButton_matchButton = null;
		private UnityEngine.UI.Image m_EButton_matchImage = null;
		public Transform uiTransform = null;
	}
}
