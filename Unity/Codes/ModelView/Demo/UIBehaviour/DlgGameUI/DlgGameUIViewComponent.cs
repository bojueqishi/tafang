
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgGameUIViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button EButton_readyButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_readyButton == null )
     			{
		    		this.m_EButton_readyButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_ready");
     			}
     			return this.m_EButton_readyButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_readyImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_readyImage == null )
     			{
		    		this.m_EButton_readyImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_ready");
     			}
     			return this.m_EButton_readyImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Text == null )
     			{
		    		this.m_ELabel_Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EButton_ready/ELabel_");
     			}
     			return this.m_ELabel_Text;
     		}
     	}

		public UnityEngine.UI.Image EListImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EListImage == null )
     			{
		    		this.m_EListImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EList");
     			}
     			return this.m_EListImage;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EList/ESButton_CreateTower1");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EList/ESButton_CreateTower2");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EList/ESButton_CreateTower3");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EList/ESButton_CreateTower4");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EList/ESButton_CreateTower5");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EList/ESButton_CreateTower6");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EList/ESButton_CreateTower7");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EList/ESButton_CreateTower8");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EList/ESButton_CreateTower9");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EList/ESButton_CreateTower10");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EList/ESButton_CreateTower11");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EList/ESButton_CreateTower12");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EList/ESButton_CreateTower13");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EList/ESButton_CreateTower14");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EList/ESButton_CreateTower15");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EList/ESButton_CreateTower16");
		    	   this.m_esbutton_createtower16 = this.AddChild<ESButton_CreateTower,Transform>(subTrans);
     			}
     			return this.m_esbutton_createtower16;
     		}
     	}

		public ESButton_CreateTower ESButton_CreateTower17
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esbutton_createtower17 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EList/ESButton_CreateTower17");
		    	   this.m_esbutton_createtower17 = this.AddChild<ESButton_CreateTower,Transform>(subTrans);
     			}
     			return this.m_esbutton_createtower17;
     		}
     	}

		public ESButton_CreateTower ESButton_CreateTower18
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esbutton_createtower18 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EList/ESButton_CreateTower18");
		    	   this.m_esbutton_createtower18 = this.AddChild<ESButton_CreateTower,Transform>(subTrans);
     			}
     			return this.m_esbutton_createtower18;
     		}
     	}

		public ESButton_CreateTower ESButton_CreateTower19
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esbutton_createtower19 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EList/ESButton_CreateTower19");
		    	   this.m_esbutton_createtower19 = this.AddChild<ESButton_CreateTower,Transform>(subTrans);
     			}
     			return this.m_esbutton_createtower19;
     		}
     	}

		public ESButton_CreateTower ESButton_CreateTower20
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esbutton_createtower20 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EList/ESButton_CreateTower20");
		    	   this.m_esbutton_createtower20 = this.AddChild<ESButton_CreateTower,Transform>(subTrans);
     			}
     			return this.m_esbutton_createtower20;
     		}
     	}

		public UnityEngine.UI.Image EInfoLeftImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInfoLeftImage == null )
     			{
		    		this.m_EInfoLeftImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EInfoLeft");
     			}
     			return this.m_EInfoLeftImage;
     		}
     	}

		public UnityEngine.UI.Image ELeftInfoBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELeftInfoBaseSpriteImage == null )
     			{
		    		this.m_ELeftInfoBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EInfoLeft/ELeftInfoBaseSprite");
     			}
     			return this.m_ELeftInfoBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image ELeftPlayerAvatarBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELeftPlayerAvatarBaseSpriteImage == null )
     			{
		    		this.m_ELeftPlayerAvatarBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EInfoLeft/ELeftPlayerAvatarBaseSprite");
     			}
     			return this.m_ELeftPlayerAvatarBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image ELeftPlayerAvatarSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELeftPlayerAvatarSpriteImage == null )
     			{
		    		this.m_ELeftPlayerAvatarSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EInfoLeft/ELeftPlayerAvatarBaseSprite/ELeftPlayerAvatarSprite");
     			}
     			return this.m_ELeftPlayerAvatarSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image ELeftPlayerNameBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELeftPlayerNameBaseSpriteImage == null )
     			{
		    		this.m_ELeftPlayerNameBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EInfoLeft/ELeftPlayerNameBaseSprite");
     			}
     			return this.m_ELeftPlayerNameBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Text ELeftPlayerNameTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELeftPlayerNameTextText == null )
     			{
		    		this.m_ELeftPlayerNameTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EInfoLeft/ELeftPlayerNameBaseSprite/ELeftPlayerNameText");
     			}
     			return this.m_ELeftPlayerNameTextText;
     		}
     	}

		public UnityEngine.UI.Image ELeftPlayerHpBarImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELeftPlayerHpBarImage == null )
     			{
		    		this.m_ELeftPlayerHpBarImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EInfoLeft/ELeftPlayerNameBaseSprite/ELeftPlayerHpBar");
     			}
     			return this.m_ELeftPlayerHpBarImage;
     		}
     	}

		public UnityEngine.UI.Image ELeftPlayerMoneyBaseSprite1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELeftPlayerMoneyBaseSprite1Image == null )
     			{
		    		this.m_ELeftPlayerMoneyBaseSprite1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EInfoLeft/LeftPlayerMoneyAll/ELeftPlayerMoneyBaseSprite1");
     			}
     			return this.m_ELeftPlayerMoneyBaseSprite1Image;
     		}
     	}

		public UnityEngine.UI.Image ELeftPlayerMoneyBaseSprite2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELeftPlayerMoneyBaseSprite2Image == null )
     			{
		    		this.m_ELeftPlayerMoneyBaseSprite2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EInfoLeft/LeftPlayerMoneyAll/ELeftPlayerMoneyBaseSprite2");
     			}
     			return this.m_ELeftPlayerMoneyBaseSprite2Image;
     		}
     	}

		public UnityEngine.UI.Image ELeftPlayerMoneySpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELeftPlayerMoneySpriteImage == null )
     			{
		    		this.m_ELeftPlayerMoneySpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EInfoLeft/LeftPlayerMoneyAll/ELeftPlayerMoneySprite");
     			}
     			return this.m_ELeftPlayerMoneySpriteImage;
     		}
     	}

		public UnityEngine.UI.Text ELeftPlayerMoneyTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELeftPlayerMoneyTextText == null )
     			{
		    		this.m_ELeftPlayerMoneyTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EInfoLeft/LeftPlayerMoneyAll/ELeftPlayerMoneyText");
     			}
     			return this.m_ELeftPlayerMoneyTextText;
     		}
     	}

		public UnityEngine.UI.Image EInfoRightImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInfoRightImage == null )
     			{
		    		this.m_EInfoRightImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EInfoRight");
     			}
     			return this.m_EInfoRightImage;
     		}
     	}

		public UnityEngine.UI.Image ERightInfoBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ERightInfoBaseSpriteImage == null )
     			{
		    		this.m_ERightInfoBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EInfoRight/ERightInfoBaseSprite");
     			}
     			return this.m_ERightInfoBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image ERightPlayerAvatarBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ERightPlayerAvatarBaseSpriteImage == null )
     			{
		    		this.m_ERightPlayerAvatarBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EInfoRight/ERightPlayerAvatarBaseSprite");
     			}
     			return this.m_ERightPlayerAvatarBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image ERightPlayerAvatarSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ERightPlayerAvatarSpriteImage == null )
     			{
		    		this.m_ERightPlayerAvatarSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EInfoRight/ERightPlayerAvatarBaseSprite/ERightPlayerAvatarSprite");
     			}
     			return this.m_ERightPlayerAvatarSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image ERightPlayerNameBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ERightPlayerNameBaseSpriteImage == null )
     			{
		    		this.m_ERightPlayerNameBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EInfoRight/ERightPlayerNameBaseSprite");
     			}
     			return this.m_ERightPlayerNameBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Text ERightPlayerNameTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ERightPlayerNameTextText == null )
     			{
		    		this.m_ERightPlayerNameTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EInfoRight/ERightPlayerNameBaseSprite/ERightPlayerNameText");
     			}
     			return this.m_ERightPlayerNameTextText;
     		}
     	}

		public UnityEngine.UI.Image ERightPlayerHpBarImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ERightPlayerHpBarImage == null )
     			{
		    		this.m_ERightPlayerHpBarImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EInfoRight/ERightPlayerNameBaseSprite/ERightPlayerHpBar");
     			}
     			return this.m_ERightPlayerHpBarImage;
     		}
     	}

		public UnityEngine.UI.Image ERightPlayerMoneyBaseSprite1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ERightPlayerMoneyBaseSprite1Image == null )
     			{
		    		this.m_ERightPlayerMoneyBaseSprite1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EInfoRight/RightPlayerMoneyAll/ERightPlayerMoneyBaseSprite1");
     			}
     			return this.m_ERightPlayerMoneyBaseSprite1Image;
     		}
     	}

		public UnityEngine.UI.Image ERightPlayerMoneyBaseSprite2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ERightPlayerMoneyBaseSprite2Image == null )
     			{
		    		this.m_ERightPlayerMoneyBaseSprite2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EInfoRight/RightPlayerMoneyAll/ERightPlayerMoneyBaseSprite2");
     			}
     			return this.m_ERightPlayerMoneyBaseSprite2Image;
     		}
     	}

		public UnityEngine.UI.Image ERightPlayerMoneySpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ERightPlayerMoneySpriteImage == null )
     			{
		    		this.m_ERightPlayerMoneySpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EInfoRight/RightPlayerMoneyAll/ERightPlayerMoneySprite");
     			}
     			return this.m_ERightPlayerMoneySpriteImage;
     		}
     	}

		public UnityEngine.UI.Text ERightPlayerMoneyTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ERightPlayerMoneyTextText == null )
     			{
		    		this.m_ERightPlayerMoneyTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EInfoRight/RightPlayerMoneyAll/ERightPlayerMoneyText");
     			}
     			return this.m_ERightPlayerMoneyTextText;
     		}
     	}

		public UnityEngine.UI.Image ERoundInfoBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ERoundInfoBaseSpriteImage == null )
     			{
		    		this.m_ERoundInfoBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ERoundInfo/ERoundInfoBaseSprite");
     			}
     			return this.m_ERoundInfoBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image ERoundInfoWaveBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ERoundInfoWaveBaseSpriteImage == null )
     			{
		    		this.m_ERoundInfoWaveBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ERoundInfo/ERoundInfoWaveBaseSprite");
     			}
     			return this.m_ERoundInfoWaveBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Text ERoundInfoWaveNumberTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ERoundInfoWaveNumberTextText == null )
     			{
		    		this.m_ERoundInfoWaveNumberTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ERoundInfo/ERoundInfoWaveNumberText");
     			}
     			return this.m_ERoundInfoWaveNumberTextText;
     		}
     	}

		public UnityEngine.UI.Image ETimeLeftBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ETimeLeftBaseSpriteImage == null )
     			{
		    		this.m_ETimeLeftBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ERoundInfo/ETimeLeftBaseSprite");
     			}
     			return this.m_ETimeLeftBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Text ETimeLeftTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ETimeLeftTextText == null )
     			{
		    		this.m_ETimeLeftTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ERoundInfo/ETimeLeftText");
     			}
     			return this.m_ETimeLeftTextText;
     		}
     	}

		public UnityEngine.UI.Image ECreateMonsterAllImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ECreateMonsterAllImage == null )
     			{
		    		this.m_ECreateMonsterAllImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ECreateMonsterAll");
     			}
     			return this.m_ECreateMonsterAllImage;
     		}
     	}

		public UnityEngine.UI.Image ECreateMonsterAllBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ECreateMonsterAllBaseSpriteImage == null )
     			{
		    		this.m_ECreateMonsterAllBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ECreateMonsterAll/ECreateMonsterAllBaseSprite");
     			}
     			return this.m_ECreateMonsterAllBaseSpriteImage;
     		}
     	}

		public ESCreateMonster ESCreateMonster1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_escreatemonster1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ECreateMonsterAll/ESCreateMonster1");
		    	   this.m_escreatemonster1 = this.AddChild<ESCreateMonster,Transform>(subTrans);
     			}
     			return this.m_escreatemonster1;
     		}
     	}

		public ESCreateMonster ESCreateMonster2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_escreatemonster2 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ECreateMonsterAll/ESCreateMonster2");
		    	   this.m_escreatemonster2 = this.AddChild<ESCreateMonster,Transform>(subTrans);
     			}
     			return this.m_escreatemonster2;
     		}
     	}

		public ESCreateMonster ESCreateMonster3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_escreatemonster3 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ECreateMonsterAll/ESCreateMonster3");
		    	   this.m_escreatemonster3 = this.AddChild<ESCreateMonster,Transform>(subTrans);
     			}
     			return this.m_escreatemonster3;
     		}
     	}

		public ESCreateMonster ESCreateMonster4
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_escreatemonster4 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ECreateMonsterAll/ESCreateMonster4");
		    	   this.m_escreatemonster4 = this.AddChild<ESCreateMonster,Transform>(subTrans);
     			}
     			return this.m_escreatemonster4;
     		}
     	}

		public UnityEngine.UI.Image E_SkillAllImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillAllImage == null )
     			{
		    		this.m_E_SkillAllImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SkillAll");
     			}
     			return this.m_E_SkillAllImage;
     		}
     	}

		public ES_Skill ES_Skill1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_skill1 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"E_SkillAll/ES_Skill1");
		    	   this.m_es_skill1 = this.AddChild<ES_Skill,Transform>(subTrans);
     			}
     			return this.m_es_skill1;
     		}
     	}

		public ES_Skill ES_Skill2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_skill2 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"E_SkillAll/ES_Skill2");
		    	   this.m_es_skill2 = this.AddChild<ES_Skill,Transform>(subTrans);
     			}
     			return this.m_es_skill2;
     		}
     	}

		public ES_Skill ES_Skill3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_skill3 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"E_SkillAll/ES_Skill3");
		    	   this.m_es_skill3 = this.AddChild<ES_Skill,Transform>(subTrans);
     			}
     			return this.m_es_skill3;
     		}
     	}

		public ES_Skill ES_Skill4
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_skill4 == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"E_SkillAll/ES_Skill4");
		    	   this.m_es_skill4 = this.AddChild<ES_Skill,Transform>(subTrans);
     			}
     			return this.m_es_skill4;
     		}
     	}

		public UnityEngine.UI.Image EvisualLImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EvisualLImage == null )
     			{
		    		this.m_EvisualLImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Evisual/EvisualL");
     			}
     			return this.m_EvisualLImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger EvisualLEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EvisualLEventTrigger == null )
     			{
		    		this.m_EvisualLEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Evisual/EvisualL");
     			}
     			return this.m_EvisualLEventTrigger;
     		}
     	}

		public UnityEngine.UI.Image EvisualLUImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EvisualLUImage == null )
     			{
		    		this.m_EvisualLUImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Evisual/EvisualLU");
     			}
     			return this.m_EvisualLUImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger EvisualLUEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EvisualLUEventTrigger == null )
     			{
		    		this.m_EvisualLUEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Evisual/EvisualLU");
     			}
     			return this.m_EvisualLUEventTrigger;
     		}
     	}

		public UnityEngine.UI.Image EvisualUImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EvisualUImage == null )
     			{
		    		this.m_EvisualUImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Evisual/EvisualU");
     			}
     			return this.m_EvisualUImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger EvisualUEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EvisualUEventTrigger == null )
     			{
		    		this.m_EvisualUEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Evisual/EvisualU");
     			}
     			return this.m_EvisualUEventTrigger;
     		}
     	}

		public UnityEngine.UI.Image EvisualRUImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EvisualRUImage == null )
     			{
		    		this.m_EvisualRUImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Evisual/EvisualRU");
     			}
     			return this.m_EvisualRUImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger EvisualRUEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EvisualRUEventTrigger == null )
     			{
		    		this.m_EvisualRUEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Evisual/EvisualRU");
     			}
     			return this.m_EvisualRUEventTrigger;
     		}
     	}

		public UnityEngine.UI.Image EvisualRImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EvisualRImage == null )
     			{
		    		this.m_EvisualRImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Evisual/EvisualR");
     			}
     			return this.m_EvisualRImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger EvisualREventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EvisualREventTrigger == null )
     			{
		    		this.m_EvisualREventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Evisual/EvisualR");
     			}
     			return this.m_EvisualREventTrigger;
     		}
     	}

		public UnityEngine.UI.Image EvisualRDImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EvisualRDImage == null )
     			{
		    		this.m_EvisualRDImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Evisual/EvisualRD");
     			}
     			return this.m_EvisualRDImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger EvisualRDEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EvisualRDEventTrigger == null )
     			{
		    		this.m_EvisualRDEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Evisual/EvisualRD");
     			}
     			return this.m_EvisualRDEventTrigger;
     		}
     	}

		public UnityEngine.UI.Image EvisualDImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EvisualDImage == null )
     			{
		    		this.m_EvisualDImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Evisual/EvisualD");
     			}
     			return this.m_EvisualDImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger EvisualDEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EvisualDEventTrigger == null )
     			{
		    		this.m_EvisualDEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Evisual/EvisualD");
     			}
     			return this.m_EvisualDEventTrigger;
     		}
     	}

		public UnityEngine.UI.Image EvisualLDImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EvisualLDImage == null )
     			{
		    		this.m_EvisualLDImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Evisual/EvisualLD");
     			}
     			return this.m_EvisualLDImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger EvisualLDEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EvisualLDEventTrigger == null )
     			{
		    		this.m_EvisualLDEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Evisual/EvisualLD");
     			}
     			return this.m_EvisualLDEventTrigger;
     		}
     	}

		public UnityEngine.UI.Button E_GameSettingButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GameSettingButton == null )
     			{
		    		this.m_E_GameSettingButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_GameSetting");
     			}
     			return this.m_E_GameSettingButton;
     		}
     	}

		public UnityEngine.UI.Image E_GameSettingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GameSettingImage == null )
     			{
		    		this.m_E_GameSettingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_GameSetting");
     			}
     			return this.m_E_GameSettingImage;
     		}
     	}

		public UnityEngine.UI.Image E_SettingBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingBaseSpriteImage == null )
     			{
		    		this.m_E_SettingBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SettingBaseSprite");
     			}
     			return this.m_E_SettingBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image E_SettingTitleSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingTitleSpriteImage == null )
     			{
		    		this.m_E_SettingTitleSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SettingBaseSprite/E_SettingTitleSprite");
     			}
     			return this.m_E_SettingTitleSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image E_SettingInsideBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingInsideBaseSpriteImage == null )
     			{
		    		this.m_E_SettingInsideBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SettingBaseSprite/E_SettingInsideBaseSprite");
     			}
     			return this.m_E_SettingInsideBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image E_SettingMusicBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingMusicBaseSpriteImage == null )
     			{
		    		this.m_E_SettingMusicBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SettingBaseSprite/E_SettingInsideBaseSprite/E_SettingMusicBaseSprite");
     			}
     			return this.m_E_SettingMusicBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image E_SettingMusicSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingMusicSpriteImage == null )
     			{
		    		this.m_E_SettingMusicSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SettingBaseSprite/E_SettingInsideBaseSprite/E_SettingMusicBaseSprite/E_SettingMusicSprite");
     			}
     			return this.m_E_SettingMusicSpriteImage;
     		}
     	}

		public UnityEngine.UI.Slider E_SettingMusicSliderSlider
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingMusicSliderSlider == null )
     			{
		    		this.m_E_SettingMusicSliderSlider = UIFindHelper.FindDeepChild<UnityEngine.UI.Slider>(this.uiTransform.gameObject,"E_SettingBaseSprite/E_SettingInsideBaseSprite/E_SettingMusicBaseSprite/E_SettingMusicSlider");
     			}
     			return this.m_E_SettingMusicSliderSlider;
     		}
     	}

		public UnityEngine.UI.Image E_SettingMusicSliderImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingMusicSliderImage == null )
     			{
		    		this.m_E_SettingMusicSliderImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SettingBaseSprite/E_SettingInsideBaseSprite/E_SettingMusicBaseSprite/E_SettingMusicSlider");
     			}
     			return this.m_E_SettingMusicSliderImage;
     		}
     	}

		public UnityEngine.UI.Image E_SettingMusicAdjustImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingMusicAdjustImage == null )
     			{
		    		this.m_E_SettingMusicAdjustImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SettingBaseSprite/E_SettingInsideBaseSprite/E_SettingMusicBaseSprite/E_SettingMusicSlider/E_SettingMusicAdjust");
     			}
     			return this.m_E_SettingMusicAdjustImage;
     		}
     	}

		public UnityEngine.UI.Image E_SettingEffectBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingEffectBaseSpriteImage == null )
     			{
		    		this.m_E_SettingEffectBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SettingBaseSprite/E_SettingInsideBaseSprite/E_SettingEffectBaseSprite");
     			}
     			return this.m_E_SettingEffectBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image E_SettingEffectSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingEffectSpriteImage == null )
     			{
		    		this.m_E_SettingEffectSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SettingBaseSprite/E_SettingInsideBaseSprite/E_SettingEffectBaseSprite/E_SettingEffectSprite");
     			}
     			return this.m_E_SettingEffectSpriteImage;
     		}
     	}

		public UnityEngine.UI.Slider E_SettingEffectSliderSlider
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingEffectSliderSlider == null )
     			{
		    		this.m_E_SettingEffectSliderSlider = UIFindHelper.FindDeepChild<UnityEngine.UI.Slider>(this.uiTransform.gameObject,"E_SettingBaseSprite/E_SettingInsideBaseSprite/E_SettingEffectBaseSprite/E_SettingEffectSlider");
     			}
     			return this.m_E_SettingEffectSliderSlider;
     		}
     	}

		public UnityEngine.UI.Image E_SettingEffectSliderImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingEffectSliderImage == null )
     			{
		    		this.m_E_SettingEffectSliderImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SettingBaseSprite/E_SettingInsideBaseSprite/E_SettingEffectBaseSprite/E_SettingEffectSlider");
     			}
     			return this.m_E_SettingEffectSliderImage;
     		}
     	}

		public UnityEngine.UI.Image E_SettingEffectAdjustImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingEffectAdjustImage == null )
     			{
		    		this.m_E_SettingEffectAdjustImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SettingBaseSprite/E_SettingInsideBaseSprite/E_SettingEffectBaseSprite/E_SettingEffectSlider/E_SettingEffectAdjust");
     			}
     			return this.m_E_SettingEffectAdjustImage;
     		}
     	}

		public UnityEngine.UI.Button E_SettingGiveUpBaseSpriteButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingGiveUpBaseSpriteButton == null )
     			{
		    		this.m_E_SettingGiveUpBaseSpriteButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_SettingBaseSprite/E_SettingGiveUpBaseSprite");
     			}
     			return this.m_E_SettingGiveUpBaseSpriteButton;
     		}
     	}

		public UnityEngine.UI.Image E_SettingGiveUpBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingGiveUpBaseSpriteImage == null )
     			{
		    		this.m_E_SettingGiveUpBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SettingBaseSprite/E_SettingGiveUpBaseSprite");
     			}
     			return this.m_E_SettingGiveUpBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image E_SettingGiveUpImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingGiveUpImage == null )
     			{
		    		this.m_E_SettingGiveUpImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SettingBaseSprite/E_SettingGiveUpBaseSprite/E_SettingGiveUp");
     			}
     			return this.m_E_SettingGiveUpImage;
     		}
     	}

		public UnityEngine.UI.Button E_SettingCloseBaseSpriteButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingCloseBaseSpriteButton == null )
     			{
		    		this.m_E_SettingCloseBaseSpriteButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_SettingBaseSprite/E_SettingCloseBaseSprite");
     			}
     			return this.m_E_SettingCloseBaseSpriteButton;
     		}
     	}

		public UnityEngine.UI.Image E_SettingCloseBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingCloseBaseSpriteImage == null )
     			{
		    		this.m_E_SettingCloseBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SettingBaseSprite/E_SettingCloseBaseSprite");
     			}
     			return this.m_E_SettingCloseBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image E_SettingCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingCloseImage == null )
     			{
		    		this.m_E_SettingCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SettingBaseSprite/E_SettingCloseBaseSprite/E_SettingClose");
     			}
     			return this.m_E_SettingCloseImage;
     		}
     	}

		public UnityEngine.UI.Image E_GiveUpBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GiveUpBaseSpriteImage == null )
     			{
		    		this.m_E_GiveUpBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_GiveUpBaseSprite");
     			}
     			return this.m_E_GiveUpBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image E_GiveUpTitleSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GiveUpTitleSpriteImage == null )
     			{
		    		this.m_E_GiveUpTitleSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_GiveUpBaseSprite/E_GiveUpTitleSprite");
     			}
     			return this.m_E_GiveUpTitleSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image E_GiveUpInsideBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GiveUpInsideBaseSpriteImage == null )
     			{
		    		this.m_E_GiveUpInsideBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_GiveUpBaseSprite/E_GiveUpInsideBaseSprite");
     			}
     			return this.m_E_GiveUpInsideBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image E_GiveUpInsideValueSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GiveUpInsideValueSpriteImage == null )
     			{
		    		this.m_E_GiveUpInsideValueSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_GiveUpBaseSprite/E_GiveUpInsideBaseSprite/E_GiveUpInsideValueSprite");
     			}
     			return this.m_E_GiveUpInsideValueSpriteImage;
     		}
     	}

		public UnityEngine.UI.Button E_GiveUpSpriteButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GiveUpSpriteButton == null )
     			{
		    		this.m_E_GiveUpSpriteButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_GiveUpBaseSprite/E_GiveUpSprite");
     			}
     			return this.m_E_GiveUpSpriteButton;
     		}
     	}

		public UnityEngine.UI.Image E_GiveUpSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GiveUpSpriteImage == null )
     			{
		    		this.m_E_GiveUpSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_GiveUpBaseSprite/E_GiveUpSprite");
     			}
     			return this.m_E_GiveUpSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image E_GiveUpImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GiveUpImage == null )
     			{
		    		this.m_E_GiveUpImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_GiveUpBaseSprite/E_GiveUpSprite/E_GiveUp");
     			}
     			return this.m_E_GiveUpImage;
     		}
     	}

		public UnityEngine.UI.Button E_GiveUpCloseSpriteButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GiveUpCloseSpriteButton == null )
     			{
		    		this.m_E_GiveUpCloseSpriteButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_GiveUpBaseSprite/E_GiveUpCloseSprite");
     			}
     			return this.m_E_GiveUpCloseSpriteButton;
     		}
     	}

		public UnityEngine.UI.Image E_GiveUpCloseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GiveUpCloseSpriteImage == null )
     			{
		    		this.m_E_GiveUpCloseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_GiveUpBaseSprite/E_GiveUpCloseSprite");
     			}
     			return this.m_E_GiveUpCloseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image E_SettingGiveUpCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingGiveUpCloseImage == null )
     			{
		    		this.m_E_SettingGiveUpCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_GiveUpBaseSprite/E_GiveUpCloseSprite/E_SettingGiveUpClose");
     			}
     			return this.m_E_SettingGiveUpCloseImage;
     		}
     	}

		public UnityEngine.UI.Button EButton_winButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_winButton == null )
     			{
		    		this.m_EButton_winButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_win");
     			}
     			return this.m_EButton_winButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_winImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_winImage == null )
     			{
		    		this.m_EButton_winImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_win");
     			}
     			return this.m_EButton_winImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_winText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_winText == null )
     			{
		    		this.m_ELabel_winText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EButton_win/ELabel_win");
     			}
     			return this.m_ELabel_winText;
     		}
     	}

		public UnityEngine.UI.Image EResultBackgroundImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EResultBackgroundImage == null )
     			{
		    		this.m_EResultBackgroundImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EResultBackground");
     			}
     			return this.m_EResultBackgroundImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_ResultLabelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_ResultLabelText == null )
     			{
		    		this.m_ELabel_ResultLabelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EResultBackground/ELabel_ResultLabel");
     			}
     			return this.m_ELabel_ResultLabelText;
     		}
     	}

		public UnityEngine.UI.LoopHorizontalScrollRect ELoopScrollListRewardLoopHorizontalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollListRewardLoopHorizontalScrollRect == null )
     			{
		    		this.m_ELoopScrollListRewardLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopHorizontalScrollRect>(this.uiTransform.gameObject,"EResultBackground/ELoopScrollListReward");
     			}
     			return this.m_ELoopScrollListRewardLoopHorizontalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button EButton_ExitGameButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ExitGameButton == null )
     			{
		    		this.m_EButton_ExitGameButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EResultBackground/EButton_ExitGame");
     			}
     			return this.m_EButton_ExitGameButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_ExitGameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ExitGameImage == null )
     			{
		    		this.m_EButton_ExitGameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EResultBackground/EButton_ExitGame");
     			}
     			return this.m_EButton_ExitGameImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_ExitGameLabelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_ExitGameLabelText == null )
     			{
		    		this.m_ELabel_ExitGameLabelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EResultBackground/EButton_ExitGame/ELabel_ExitGameLabel");
     			}
     			return this.m_ELabel_ExitGameLabelText;
     		}
     	}

		public UnityEngine.UI.Button E_GamePauseButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GamePauseButtonButton == null )
     			{
		    		this.m_E_GamePauseButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_GamePauseButton");
     			}
     			return this.m_E_GamePauseButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_GamePauseButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GamePauseButtonImage == null )
     			{
		    		this.m_E_GamePauseButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_GamePauseButton");
     			}
     			return this.m_E_GamePauseButtonImage;
     		}
     	}

		public UnityEngine.UI.Button E_GameContinueButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GameContinueButtonButton == null )
     			{
		    		this.m_E_GameContinueButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_GameContinueButton");
     			}
     			return this.m_E_GameContinueButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_GameContinueButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GameContinueButtonImage == null )
     			{
		    		this.m_E_GameContinueButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_GameContinueButton");
     			}
     			return this.m_E_GameContinueButtonImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EButton_readyButton = null;
			this.m_EButton_readyImage = null;
			this.m_ELabel_Text = null;
			this.m_EListImage = null;
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
			this.m_esbutton_createtower17?.Dispose();
			this.m_esbutton_createtower17 = null;
			this.m_esbutton_createtower18?.Dispose();
			this.m_esbutton_createtower18 = null;
			this.m_esbutton_createtower19?.Dispose();
			this.m_esbutton_createtower19 = null;
			this.m_esbutton_createtower20?.Dispose();
			this.m_esbutton_createtower20 = null;
			this.m_EInfoLeftImage = null;
			this.m_ELeftInfoBaseSpriteImage = null;
			this.m_ELeftPlayerAvatarBaseSpriteImage = null;
			this.m_ELeftPlayerAvatarSpriteImage = null;
			this.m_ELeftPlayerNameBaseSpriteImage = null;
			this.m_ELeftPlayerNameTextText = null;
			this.m_ELeftPlayerHpBarImage = null;
			this.m_ELeftPlayerMoneyBaseSprite1Image = null;
			this.m_ELeftPlayerMoneyBaseSprite2Image = null;
			this.m_ELeftPlayerMoneySpriteImage = null;
			this.m_ELeftPlayerMoneyTextText = null;
			this.m_EInfoRightImage = null;
			this.m_ERightInfoBaseSpriteImage = null;
			this.m_ERightPlayerAvatarBaseSpriteImage = null;
			this.m_ERightPlayerAvatarSpriteImage = null;
			this.m_ERightPlayerNameBaseSpriteImage = null;
			this.m_ERightPlayerNameTextText = null;
			this.m_ERightPlayerHpBarImage = null;
			this.m_ERightPlayerMoneyBaseSprite1Image = null;
			this.m_ERightPlayerMoneyBaseSprite2Image = null;
			this.m_ERightPlayerMoneySpriteImage = null;
			this.m_ERightPlayerMoneyTextText = null;
			this.m_ERoundInfoBaseSpriteImage = null;
			this.m_ERoundInfoWaveBaseSpriteImage = null;
			this.m_ERoundInfoWaveNumberTextText = null;
			this.m_ETimeLeftBaseSpriteImage = null;
			this.m_ETimeLeftTextText = null;
			this.m_ECreateMonsterAllImage = null;
			this.m_ECreateMonsterAllBaseSpriteImage = null;
			this.m_escreatemonster1?.Dispose();
			this.m_escreatemonster1 = null;
			this.m_escreatemonster2?.Dispose();
			this.m_escreatemonster2 = null;
			this.m_escreatemonster3?.Dispose();
			this.m_escreatemonster3 = null;
			this.m_escreatemonster4?.Dispose();
			this.m_escreatemonster4 = null;
			this.m_E_SkillAllImage = null;
			this.m_es_skill1?.Dispose();
			this.m_es_skill1 = null;
			this.m_es_skill2?.Dispose();
			this.m_es_skill2 = null;
			this.m_es_skill3?.Dispose();
			this.m_es_skill3 = null;
			this.m_es_skill4?.Dispose();
			this.m_es_skill4 = null;
			this.m_EvisualLImage = null;
			this.m_EvisualLEventTrigger = null;
			this.m_EvisualLUImage = null;
			this.m_EvisualLUEventTrigger = null;
			this.m_EvisualUImage = null;
			this.m_EvisualUEventTrigger = null;
			this.m_EvisualRUImage = null;
			this.m_EvisualRUEventTrigger = null;
			this.m_EvisualRImage = null;
			this.m_EvisualREventTrigger = null;
			this.m_EvisualRDImage = null;
			this.m_EvisualRDEventTrigger = null;
			this.m_EvisualDImage = null;
			this.m_EvisualDEventTrigger = null;
			this.m_EvisualLDImage = null;
			this.m_EvisualLDEventTrigger = null;
			this.m_E_GameSettingButton = null;
			this.m_E_GameSettingImage = null;
			this.m_E_SettingBaseSpriteImage = null;
			this.m_E_SettingTitleSpriteImage = null;
			this.m_E_SettingInsideBaseSpriteImage = null;
			this.m_E_SettingMusicBaseSpriteImage = null;
			this.m_E_SettingMusicSpriteImage = null;
			this.m_E_SettingMusicSliderSlider = null;
			this.m_E_SettingMusicSliderImage = null;
			this.m_E_SettingMusicAdjustImage = null;
			this.m_E_SettingEffectBaseSpriteImage = null;
			this.m_E_SettingEffectSpriteImage = null;
			this.m_E_SettingEffectSliderSlider = null;
			this.m_E_SettingEffectSliderImage = null;
			this.m_E_SettingEffectAdjustImage = null;
			this.m_E_SettingGiveUpBaseSpriteButton = null;
			this.m_E_SettingGiveUpBaseSpriteImage = null;
			this.m_E_SettingGiveUpImage = null;
			this.m_E_SettingCloseBaseSpriteButton = null;
			this.m_E_SettingCloseBaseSpriteImage = null;
			this.m_E_SettingCloseImage = null;
			this.m_E_GiveUpBaseSpriteImage = null;
			this.m_E_GiveUpTitleSpriteImage = null;
			this.m_E_GiveUpInsideBaseSpriteImage = null;
			this.m_E_GiveUpInsideValueSpriteImage = null;
			this.m_E_GiveUpSpriteButton = null;
			this.m_E_GiveUpSpriteImage = null;
			this.m_E_GiveUpImage = null;
			this.m_E_GiveUpCloseSpriteButton = null;
			this.m_E_GiveUpCloseSpriteImage = null;
			this.m_E_SettingGiveUpCloseImage = null;
			this.m_EButton_winButton = null;
			this.m_EButton_winImage = null;
			this.m_ELabel_winText = null;
			this.m_EResultBackgroundImage = null;
			this.m_ELabel_ResultLabelText = null;
			this.m_ELoopScrollListRewardLoopHorizontalScrollRect = null;
			this.m_EButton_ExitGameButton = null;
			this.m_EButton_ExitGameImage = null;
			this.m_ELabel_ExitGameLabelText = null;
			this.m_E_GamePauseButtonButton = null;
			this.m_E_GamePauseButtonImage = null;
			this.m_E_GameContinueButtonButton = null;
			this.m_E_GameContinueButtonImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_EButton_readyButton = null;
		private UnityEngine.UI.Image m_EButton_readyImage = null;
		private UnityEngine.UI.Text m_ELabel_Text = null;
		private UnityEngine.UI.Image m_EListImage = null;
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
		private ESButton_CreateTower m_esbutton_createtower17 = null;
		private ESButton_CreateTower m_esbutton_createtower18 = null;
		private ESButton_CreateTower m_esbutton_createtower19 = null;
		private ESButton_CreateTower m_esbutton_createtower20 = null;
		private UnityEngine.UI.Image m_EInfoLeftImage = null;
		private UnityEngine.UI.Image m_ELeftInfoBaseSpriteImage = null;
		private UnityEngine.UI.Image m_ELeftPlayerAvatarBaseSpriteImage = null;
		private UnityEngine.UI.Image m_ELeftPlayerAvatarSpriteImage = null;
		private UnityEngine.UI.Image m_ELeftPlayerNameBaseSpriteImage = null;
		private UnityEngine.UI.Text m_ELeftPlayerNameTextText = null;
		private UnityEngine.UI.Image m_ELeftPlayerHpBarImage = null;
		private UnityEngine.UI.Image m_ELeftPlayerMoneyBaseSprite1Image = null;
		private UnityEngine.UI.Image m_ELeftPlayerMoneyBaseSprite2Image = null;
		private UnityEngine.UI.Image m_ELeftPlayerMoneySpriteImage = null;
		private UnityEngine.UI.Text m_ELeftPlayerMoneyTextText = null;
		private UnityEngine.UI.Image m_EInfoRightImage = null;
		private UnityEngine.UI.Image m_ERightInfoBaseSpriteImage = null;
		private UnityEngine.UI.Image m_ERightPlayerAvatarBaseSpriteImage = null;
		private UnityEngine.UI.Image m_ERightPlayerAvatarSpriteImage = null;
		private UnityEngine.UI.Image m_ERightPlayerNameBaseSpriteImage = null;
		private UnityEngine.UI.Text m_ERightPlayerNameTextText = null;
		private UnityEngine.UI.Image m_ERightPlayerHpBarImage = null;
		private UnityEngine.UI.Image m_ERightPlayerMoneyBaseSprite1Image = null;
		private UnityEngine.UI.Image m_ERightPlayerMoneyBaseSprite2Image = null;
		private UnityEngine.UI.Image m_ERightPlayerMoneySpriteImage = null;
		private UnityEngine.UI.Text m_ERightPlayerMoneyTextText = null;
		private UnityEngine.UI.Image m_ERoundInfoBaseSpriteImage = null;
		private UnityEngine.UI.Image m_ERoundInfoWaveBaseSpriteImage = null;
		private UnityEngine.UI.Text m_ERoundInfoWaveNumberTextText = null;
		private UnityEngine.UI.Image m_ETimeLeftBaseSpriteImage = null;
		private UnityEngine.UI.Text m_ETimeLeftTextText = null;
		private UnityEngine.UI.Image m_ECreateMonsterAllImage = null;
		private UnityEngine.UI.Image m_ECreateMonsterAllBaseSpriteImage = null;
		private ESCreateMonster m_escreatemonster1 = null;
		private ESCreateMonster m_escreatemonster2 = null;
		private ESCreateMonster m_escreatemonster3 = null;
		private ESCreateMonster m_escreatemonster4 = null;
		private UnityEngine.UI.Image m_E_SkillAllImage = null;
		private ES_Skill m_es_skill1 = null;
		private ES_Skill m_es_skill2 = null;
		private ES_Skill m_es_skill3 = null;
		private ES_Skill m_es_skill4 = null;
		private UnityEngine.UI.Image m_EvisualLImage = null;
		private UnityEngine.EventSystems.EventTrigger m_EvisualLEventTrigger = null;
		private UnityEngine.UI.Image m_EvisualLUImage = null;
		private UnityEngine.EventSystems.EventTrigger m_EvisualLUEventTrigger = null;
		private UnityEngine.UI.Image m_EvisualUImage = null;
		private UnityEngine.EventSystems.EventTrigger m_EvisualUEventTrigger = null;
		private UnityEngine.UI.Image m_EvisualRUImage = null;
		private UnityEngine.EventSystems.EventTrigger m_EvisualRUEventTrigger = null;
		private UnityEngine.UI.Image m_EvisualRImage = null;
		private UnityEngine.EventSystems.EventTrigger m_EvisualREventTrigger = null;
		private UnityEngine.UI.Image m_EvisualRDImage = null;
		private UnityEngine.EventSystems.EventTrigger m_EvisualRDEventTrigger = null;
		private UnityEngine.UI.Image m_EvisualDImage = null;
		private UnityEngine.EventSystems.EventTrigger m_EvisualDEventTrigger = null;
		private UnityEngine.UI.Image m_EvisualLDImage = null;
		private UnityEngine.EventSystems.EventTrigger m_EvisualLDEventTrigger = null;
		private UnityEngine.UI.Button m_E_GameSettingButton = null;
		private UnityEngine.UI.Image m_E_GameSettingImage = null;
		private UnityEngine.UI.Image m_E_SettingBaseSpriteImage = null;
		private UnityEngine.UI.Image m_E_SettingTitleSpriteImage = null;
		private UnityEngine.UI.Image m_E_SettingInsideBaseSpriteImage = null;
		private UnityEngine.UI.Image m_E_SettingMusicBaseSpriteImage = null;
		private UnityEngine.UI.Image m_E_SettingMusicSpriteImage = null;
		private UnityEngine.UI.Slider m_E_SettingMusicSliderSlider = null;
		private UnityEngine.UI.Image m_E_SettingMusicSliderImage = null;
		private UnityEngine.UI.Image m_E_SettingMusicAdjustImage = null;
		private UnityEngine.UI.Image m_E_SettingEffectBaseSpriteImage = null;
		private UnityEngine.UI.Image m_E_SettingEffectSpriteImage = null;
		private UnityEngine.UI.Slider m_E_SettingEffectSliderSlider = null;
		private UnityEngine.UI.Image m_E_SettingEffectSliderImage = null;
		private UnityEngine.UI.Image m_E_SettingEffectAdjustImage = null;
		private UnityEngine.UI.Button m_E_SettingGiveUpBaseSpriteButton = null;
		private UnityEngine.UI.Image m_E_SettingGiveUpBaseSpriteImage = null;
		private UnityEngine.UI.Image m_E_SettingGiveUpImage = null;
		private UnityEngine.UI.Button m_E_SettingCloseBaseSpriteButton = null;
		private UnityEngine.UI.Image m_E_SettingCloseBaseSpriteImage = null;
		private UnityEngine.UI.Image m_E_SettingCloseImage = null;
		private UnityEngine.UI.Image m_E_GiveUpBaseSpriteImage = null;
		private UnityEngine.UI.Image m_E_GiveUpTitleSpriteImage = null;
		private UnityEngine.UI.Image m_E_GiveUpInsideBaseSpriteImage = null;
		private UnityEngine.UI.Image m_E_GiveUpInsideValueSpriteImage = null;
		private UnityEngine.UI.Button m_E_GiveUpSpriteButton = null;
		private UnityEngine.UI.Image m_E_GiveUpSpriteImage = null;
		private UnityEngine.UI.Image m_E_GiveUpImage = null;
		private UnityEngine.UI.Button m_E_GiveUpCloseSpriteButton = null;
		private UnityEngine.UI.Image m_E_GiveUpCloseSpriteImage = null;
		private UnityEngine.UI.Image m_E_SettingGiveUpCloseImage = null;
		private UnityEngine.UI.Button m_EButton_winButton = null;
		private UnityEngine.UI.Image m_EButton_winImage = null;
		private UnityEngine.UI.Text m_ELabel_winText = null;
		private UnityEngine.UI.Image m_EResultBackgroundImage = null;
		private UnityEngine.UI.Text m_ELabel_ResultLabelText = null;
		private UnityEngine.UI.LoopHorizontalScrollRect m_ELoopScrollListRewardLoopHorizontalScrollRect = null;
		private UnityEngine.UI.Button m_EButton_ExitGameButton = null;
		private UnityEngine.UI.Image m_EButton_ExitGameImage = null;
		private UnityEngine.UI.Text m_ELabel_ExitGameLabelText = null;
		private UnityEngine.UI.Button m_E_GamePauseButtonButton = null;
		private UnityEngine.UI.Image m_E_GamePauseButtonImage = null;
		private UnityEngine.UI.Button m_E_GameContinueButtonButton = null;
		private UnityEngine.UI.Image m_E_GameContinueButtonImage = null;
		public Transform uiTransform = null;
	}
}
