
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgMap1ViewComponent : Entity,IAwake,IUpdate,IDestroy
	{
		public UnityEngine.UI.Image EButtonListImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButtonListImage == null )
     			{
		    		this.m_EButtonListImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButtonList");
     			}
     			return this.m_EButtonListImage;
     		}
     	}

		public ESButton_CreateTower ESButton_CreateTower1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esbutton_createtower1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EButtonList/ESButton_CreateTower1");
		    	   this.m_esbutton_createtower1 = this.AddChild<ESButton_CreateTower,Transform>(subTrans);
     			}
     			return this.m_esbutton_createtower1;
     		}
     	}

		public ESButton_CreateTower ESButton_CreateTower2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esbutton_createtower2 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EButtonList/ESButton_CreateTower2");
		    	   this.m_esbutton_createtower2 = this.AddChild<ESButton_CreateTower,Transform>(subTrans);
     			}
     			return this.m_esbutton_createtower2;
     		}
     	}

		public ESButton_CreateTower ESButton_CreateTower3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esbutton_createtower3 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EButtonList/ESButton_CreateTower3");
		    	   this.m_esbutton_createtower3 = this.AddChild<ESButton_CreateTower,Transform>(subTrans);
     			}
     			return this.m_esbutton_createtower3;
     		}
     	}

		public ESButton_CreateTower ESButton_CreateTower4
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esbutton_createtower4 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EButtonList/ESButton_CreateTower4");
		    	   this.m_esbutton_createtower4 = this.AddChild<ESButton_CreateTower,Transform>(subTrans);
     			}
     			return this.m_esbutton_createtower4;
     		}
     	}

		public ESButton_CreateTower ESButton_CreateTower5
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esbutton_createtower5 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EButtonList/ESButton_CreateTower5");
		    	   this.m_esbutton_createtower5 = this.AddChild<ESButton_CreateTower,Transform>(subTrans);
     			}
     			return this.m_esbutton_createtower5;
     		}
     	}

		public ESButton_CreateTower ESButton_CreateTower6
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esbutton_createtower6 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EButtonList/ESButton_CreateTower6");
		    	   this.m_esbutton_createtower6 = this.AddChild<ESButton_CreateTower,Transform>(subTrans);
     			}
     			return this.m_esbutton_createtower6;
     		}
     	}

		public ESButton_CreateTower ESButton_CreateTower7
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esbutton_createtower7 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EButtonList/ESButton_CreateTower7");
		    	   this.m_esbutton_createtower7 = this.AddChild<ESButton_CreateTower,Transform>(subTrans);
     			}
     			return this.m_esbutton_createtower7;
     		}
     	}

		public ESButton_CreateTower ESButton_CreateTower8
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esbutton_createtower8 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EButtonList/ESButton_CreateTower8");
		    	   this.m_esbutton_createtower8 = this.AddChild<ESButton_CreateTower,Transform>(subTrans);
     			}
     			return this.m_esbutton_createtower8;
     		}
     	}

		public ESButton_CreateTower ESButton_CreateTower9
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esbutton_createtower9 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EButtonList/ESButton_CreateTower9");
		    	   this.m_esbutton_createtower9 = this.AddChild<ESButton_CreateTower,Transform>(subTrans);
     			}
     			return this.m_esbutton_createtower9;
     		}
     	}

		public ESButton_CreateTower ESButton_CreateTower10
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esbutton_createtower10 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EButtonList/ESButton_CreateTower10");
		    	   this.m_esbutton_createtower10 = this.AddChild<ESButton_CreateTower,Transform>(subTrans);
     			}
     			return this.m_esbutton_createtower10;
     		}
     	}

		public ESButton_CreateTower ESButton_CreateTower11
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esbutton_createtower11 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EButtonList/ESButton_CreateTower11");
		    	   this.m_esbutton_createtower11 = this.AddChild<ESButton_CreateTower,Transform>(subTrans);
     			}
     			return this.m_esbutton_createtower11;
     		}
     	}

		public ESButton_CreateTower ESButton_CreateTower12
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esbutton_createtower12 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EButtonList/ESButton_CreateTower12");
		    	   this.m_esbutton_createtower12 = this.AddChild<ESButton_CreateTower,Transform>(subTrans);
     			}
     			return this.m_esbutton_createtower12;
     		}
     	}

		public ESButton_CreateTower ESButton_CreateTower13
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esbutton_createtower13 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EButtonList/ESButton_CreateTower13");
		    	   this.m_esbutton_createtower13 = this.AddChild<ESButton_CreateTower,Transform>(subTrans);
     			}
     			return this.m_esbutton_createtower13;
     		}
     	}

		public ESButton_CreateTower ESButton_CreateTower14
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esbutton_createtower14 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EButtonList/ESButton_CreateTower14");
		    	   this.m_esbutton_createtower14 = this.AddChild<ESButton_CreateTower,Transform>(subTrans);
     			}
     			return this.m_esbutton_createtower14;
     		}
     	}

		public ESButton_CreateTower ESButton_CreateTower15
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esbutton_createtower15 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EButtonList/ESButton_CreateTower15");
		    	   this.m_esbutton_createtower15 = this.AddChild<ESButton_CreateTower,Transform>(subTrans);
     			}
     			return this.m_esbutton_createtower15;
     		}
     	}

		public ESButton_CreateTower ESButton_CreateTower16
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esbutton_createtower16 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EButtonList/ESButton_CreateTower16");
		    	   this.m_esbutton_createtower16 = this.AddChild<ESButton_CreateTower,Transform>(subTrans);
     			}
     			return this.m_esbutton_createtower16;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EButtonListImage = null;
			this.m_esbutton_createtower1?.Dispose();
			this.m_esbutton_createtower1 = null;
			this.m_esbutton_createtower2?.Dispose();
			this.m_esbutton_createtower2 = null;
			this.m_esbutton_createtower3?.Dispose();
			this.m_esbutton_createtower3 = null;
			this.m_esbutton_createtower4?.Dispose();
			this.m_esbutton_createtower4 = null;
			this.m_esbutton_createtower5?.Dispose();
			this.m_esbutton_createtower5 = null;
			this.m_esbutton_createtower6?.Dispose();
			this.m_esbutton_createtower6 = null;
			this.m_esbutton_createtower7?.Dispose();
			this.m_esbutton_createtower7 = null;
			this.m_esbutton_createtower8?.Dispose();
			this.m_esbutton_createtower8 = null;
			this.m_esbutton_createtower9?.Dispose();
			this.m_esbutton_createtower9 = null;
			this.m_esbutton_createtower10?.Dispose();
			this.m_esbutton_createtower10 = null;
			this.m_esbutton_createtower11?.Dispose();
			this.m_esbutton_createtower11 = null;
			this.m_esbutton_createtower12?.Dispose();
			this.m_esbutton_createtower12 = null;
			this.m_esbutton_createtower13?.Dispose();
			this.m_esbutton_createtower13 = null;
			this.m_esbutton_createtower14?.Dispose();
			this.m_esbutton_createtower14 = null;
			this.m_esbutton_createtower15?.Dispose();
			this.m_esbutton_createtower15 = null;
			this.m_esbutton_createtower16?.Dispose();
			this.m_esbutton_createtower16 = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_EButtonListImage = null;
		private ESButton_CreateTower m_esbutton_createtower1 = null;
		private ESButton_CreateTower m_esbutton_createtower2 = null;
		private ESButton_CreateTower m_esbutton_createtower3 = null;
		private ESButton_CreateTower m_esbutton_createtower4 = null;
		private ESButton_CreateTower m_esbutton_createtower5 = null;
		private ESButton_CreateTower m_esbutton_createtower6 = null;
		private ESButton_CreateTower m_esbutton_createtower7 = null;
		private ESButton_CreateTower m_esbutton_createtower8 = null;
		private ESButton_CreateTower m_esbutton_createtower9 = null;
		private ESButton_CreateTower m_esbutton_createtower10 = null;
		private ESButton_CreateTower m_esbutton_createtower11 = null;
		private ESButton_CreateTower m_esbutton_createtower12 = null;
		private ESButton_CreateTower m_esbutton_createtower13 = null;
		private ESButton_CreateTower m_esbutton_createtower14 = null;
		private ESButton_CreateTower m_esbutton_createtower15 = null;
		private ESButton_CreateTower m_esbutton_createtower16 = null;
		public Transform uiTransform = null;
    }
}
