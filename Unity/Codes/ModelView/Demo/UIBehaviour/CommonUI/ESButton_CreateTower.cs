
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class ESButton_CreateTower : Entity,ET.IAwake<UnityEngine.Transform>,IUpdate,IDestroy 
	{
		public UnityEngine.UI.Button EButton_CreateTowerButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_CreateTowerButton == null )
     			{
		    		this.m_EButton_CreateTowerButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_CreateTower");
     			}
     			return this.m_EButton_CreateTowerButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_CreateTowerImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_CreateTowerImage == null )
     			{
		    		this.m_EButton_CreateTowerImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_CreateTower");
     			}
     			return this.m_EButton_CreateTowerImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger EButton_CreateTowerEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_CreateTowerEventTrigger == null )
     			{
		    		this.m_EButton_CreateTowerEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"EButton_CreateTower");
     			}
     			return this.m_EButton_CreateTowerEventTrigger;
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

		public UnityEngine.UI.Button Ecreatebt1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Ecreatebt1Button == null )
     			{
		    		this.m_Ecreatebt1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EList/Ecreatebt1");
     			}
     			return this.m_Ecreatebt1Button;
     		}
     	}

		public UnityEngine.UI.Image Ecreatebt1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Ecreatebt1Image == null )
     			{
		    		this.m_Ecreatebt1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EList/Ecreatebt1");
     			}
     			return this.m_Ecreatebt1Image;
     		}
     	}

		public UnityEngine.UI.Image Espritetower1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Espritetower1Image == null )
     			{
		    		this.m_Espritetower1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EList/Ecreatebt1/Espritetower1");
     			}
     			return this.m_Espritetower1Image;
     		}
     	}

		public UnityEngine.UI.Text Ecreatemoneytext1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Ecreatemoneytext1Text == null )
     			{
		    		this.m_Ecreatemoneytext1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EList/Ecreatebt1/Ecreatemoneytext1");
     			}
     			return this.m_Ecreatemoneytext1Text;
     		}
     	}

		public UnityEngine.UI.Button Ecreatebt2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Ecreatebt2Button == null )
     			{
		    		this.m_Ecreatebt2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EList/Ecreatebt2");
     			}
     			return this.m_Ecreatebt2Button;
     		}
     	}

		public UnityEngine.UI.Image Ecreatebt2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Ecreatebt2Image == null )
     			{
		    		this.m_Ecreatebt2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EList/Ecreatebt2");
     			}
     			return this.m_Ecreatebt2Image;
     		}
     	}

		public UnityEngine.UI.Image Espritetower2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Espritetower2Image == null )
     			{
		    		this.m_Espritetower2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EList/Ecreatebt2/Espritetower2");
     			}
     			return this.m_Espritetower2Image;
     		}
     	}

		public UnityEngine.UI.Text Ecreatemoneytext2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Ecreatemoneytext2Text == null )
     			{
		    		this.m_Ecreatemoneytext2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EList/Ecreatebt2/Ecreatemoneytext2");
     			}
     			return this.m_Ecreatemoneytext2Text;
     		}
     	}

		public UnityEngine.UI.Button Ecreatebt3Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Ecreatebt3Button == null )
     			{
		    		this.m_Ecreatebt3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EList/Ecreatebt3");
     			}
     			return this.m_Ecreatebt3Button;
     		}
     	}

		public UnityEngine.UI.Image Ecreatebt3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Ecreatebt3Image == null )
     			{
		    		this.m_Ecreatebt3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EList/Ecreatebt3");
     			}
     			return this.m_Ecreatebt3Image;
     		}
     	}

		public UnityEngine.UI.Image Espritetower3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Espritetower3Image == null )
     			{
		    		this.m_Espritetower3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EList/Ecreatebt3/Espritetower3");
     			}
     			return this.m_Espritetower3Image;
     		}
     	}

		public UnityEngine.UI.Text Ecreatemoneytext3Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Ecreatemoneytext3Text == null )
     			{
		    		this.m_Ecreatemoneytext3Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EList/Ecreatebt3/Ecreatemoneytext3");
     			}
     			return this.m_Ecreatemoneytext3Text;
     		}
     	}

		public UnityEngine.UI.Button Ecreatebt4Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Ecreatebt4Button == null )
     			{
		    		this.m_Ecreatebt4Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EList/Ecreatebt4");
     			}
     			return this.m_Ecreatebt4Button;
     		}
     	}

		public UnityEngine.UI.Image Ecreatebt4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Ecreatebt4Image == null )
     			{
		    		this.m_Ecreatebt4Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EList/Ecreatebt4");
     			}
     			return this.m_Ecreatebt4Image;
     		}
     	}

		public UnityEngine.UI.Image Espritetower4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Espritetower4Image == null )
     			{
		    		this.m_Espritetower4Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EList/Ecreatebt4/Espritetower4");
     			}
     			return this.m_Espritetower4Image;
     		}
     	}

		public UnityEngine.UI.Text Ecreatemoneytext4Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Ecreatemoneytext4Text == null )
     			{
		    		this.m_Ecreatemoneytext4Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EList/Ecreatebt4/Ecreatemoneytext4");
     			}
     			return this.m_Ecreatemoneytext4Text;
     		}
     	}

		public UnityEngine.UI.Button EclosebtButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EclosebtButton == null )
     			{
		    		this.m_EclosebtButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EList/Eclosebt");
     			}
     			return this.m_EclosebtButton;
     		}
     	}

		public UnityEngine.UI.Image EclosebtImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EclosebtImage == null )
     			{
		    		this.m_EclosebtImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EList/Eclosebt");
     			}
     			return this.m_EclosebtImage;
     		}
     	}

		public UnityEngine.UI.Text EclosetextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EclosetextText == null )
     			{
		    		this.m_EclosetextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EList/Eclosebt/Eclosetext");
     			}
     			return this.m_EclosetextText;
     		}
     	}

		public UnityEngine.UI.Image EUpListImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EUpListImage == null )
     			{
		    		this.m_EUpListImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EUpList");
     			}
     			return this.m_EUpListImage;
     		}
     	}

		public UnityEngine.UI.Button ECloseUpButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ECloseUpButton == null )
     			{
		    		this.m_ECloseUpButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EUpList/ECloseUp");
     			}
     			return this.m_ECloseUpButton;
     		}
     	}

		public UnityEngine.UI.Image ECloseUpImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ECloseUpImage == null )
     			{
		    		this.m_ECloseUpImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EUpList/ECloseUp");
     			}
     			return this.m_ECloseUpImage;
     		}
     	}

		public UnityEngine.UI.Button EUpButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EUpButton == null )
     			{
		    		this.m_EUpButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EUpList/EUp");
     			}
     			return this.m_EUpButton;
     		}
     	}

		public UnityEngine.UI.Image EUpImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EUpImage == null )
     			{
		    		this.m_EUpImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EUpList/EUp");
     			}
     			return this.m_EUpImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_UpText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_UpText == null )
     			{
		    		this.m_ELabel_UpText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EUpList/EUp/ELabel_Up");
     			}
     			return this.m_ELabel_UpText;
     		}
     	}

		public UnityEngine.UI.Button EDeleteUpButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EDeleteUpButton == null )
     			{
		    		this.m_EDeleteUpButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EUpList/EDeleteUp");
     			}
     			return this.m_EDeleteUpButton;
     		}
     	}

		public UnityEngine.UI.Image EDeleteUpImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EDeleteUpImage == null )
     			{
		    		this.m_EDeleteUpImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EUpList/EDeleteUp");
     			}
     			return this.m_EDeleteUpImage;
     		}
     	}

		public UnityEngine.UI.Text EDeleteMoneyText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EDeleteMoneyText == null )
     			{
		    		this.m_EDeleteMoneyText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EUpList/EDeleteUp/EDeleteMoney");
     			}
     			return this.m_EDeleteMoneyText;
     		}
     	}

		public UnityEngine.UI.Button ETowerInfoButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ETowerInfoButton == null )
     			{
		    		this.m_ETowerInfoButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ETowerInfo");
     			}
     			return this.m_ETowerInfoButton;
     		}
     	}

		public UnityEngine.UI.Image ETowerInfoImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ETowerInfoImage == null )
     			{
		    		this.m_ETowerInfoImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ETowerInfo");
     			}
     			return this.m_ETowerInfoImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_TowerNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_TowerNameText == null )
     			{
		    		this.m_ELabel_TowerNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ETowerInfo/ELabel_TowerName");
     			}
     			return this.m_ELabel_TowerNameText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_TowerAttackValueText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_TowerAttackValueText == null )
     			{
		    		this.m_ELabel_TowerAttackValueText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ETowerInfo/ELabel_TowerAttackValue");
     			}
     			return this.m_ELabel_TowerAttackValueText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_TowerAttackIntervalText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_TowerAttackIntervalText == null )
     			{
		    		this.m_ELabel_TowerAttackIntervalText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ETowerInfo/ELabel_TowerAttackInterval");
     			}
     			return this.m_ELabel_TowerAttackIntervalText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_TowerNextMoneyText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_TowerNextMoneyText == null )
     			{
		    		this.m_ELabel_TowerNextMoneyText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ETowerInfo/ELabel_TowerNextMoney");
     			}
     			return this.m_ELabel_TowerNextMoneyText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EButton_CreateTowerButton = null;
			this.m_EButton_CreateTowerImage = null;
			this.m_EButton_CreateTowerEventTrigger = null;
			this.m_EListImage = null;
			this.m_Ecreatebt1Button = null;
			this.m_Ecreatebt1Image = null;
			this.m_Espritetower1Image = null;
			this.m_Ecreatemoneytext1Text = null;
			this.m_Ecreatebt2Button = null;
			this.m_Ecreatebt2Image = null;
			this.m_Espritetower2Image = null;
			this.m_Ecreatemoneytext2Text = null;
			this.m_Ecreatebt3Button = null;
			this.m_Ecreatebt3Image = null;
			this.m_Espritetower3Image = null;
			this.m_Ecreatemoneytext3Text = null;
			this.m_Ecreatebt4Button = null;
			this.m_Ecreatebt4Image = null;
			this.m_Espritetower4Image = null;
			this.m_Ecreatemoneytext4Text = null;
			this.m_EclosebtButton = null;
			this.m_EclosebtImage = null;
			this.m_EclosetextText = null;
			this.m_EUpListImage = null;
			this.m_ECloseUpButton = null;
			this.m_ECloseUpImage = null;
			this.m_EUpButton = null;
			this.m_EUpImage = null;
			this.m_ELabel_UpText = null;
			this.m_EDeleteUpButton = null;
			this.m_EDeleteUpImage = null;
			this.m_EDeleteMoneyText = null;
			this.m_ETowerInfoButton = null;
			this.m_ETowerInfoImage = null;
			this.m_ELabel_TowerNameText = null;
			this.m_ELabel_TowerAttackValueText = null;
			this.m_ELabel_TowerAttackIntervalText = null;
			this.m_ELabel_TowerNextMoneyText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_EButton_CreateTowerButton = null;
		private UnityEngine.UI.Image m_EButton_CreateTowerImage = null;
		private UnityEngine.EventSystems.EventTrigger m_EButton_CreateTowerEventTrigger = null;
		private UnityEngine.UI.Image m_EListImage = null;
		private UnityEngine.UI.Button m_Ecreatebt1Button = null;
		private UnityEngine.UI.Image m_Ecreatebt1Image = null;
		private UnityEngine.UI.Image m_Espritetower1Image = null;
		private UnityEngine.UI.Text m_Ecreatemoneytext1Text = null;
		private UnityEngine.UI.Button m_Ecreatebt2Button = null;
		private UnityEngine.UI.Image m_Ecreatebt2Image = null;
		private UnityEngine.UI.Image m_Espritetower2Image = null;
		private UnityEngine.UI.Text m_Ecreatemoneytext2Text = null;
		private UnityEngine.UI.Button m_Ecreatebt3Button = null;
		private UnityEngine.UI.Image m_Ecreatebt3Image = null;
		private UnityEngine.UI.Image m_Espritetower3Image = null;
		private UnityEngine.UI.Text m_Ecreatemoneytext3Text = null;
		private UnityEngine.UI.Button m_Ecreatebt4Button = null;
		private UnityEngine.UI.Image m_Ecreatebt4Image = null;
		private UnityEngine.UI.Image m_Espritetower4Image = null;
		private UnityEngine.UI.Text m_Ecreatemoneytext4Text = null;
		private UnityEngine.UI.Button m_EclosebtButton = null;
		private UnityEngine.UI.Image m_EclosebtImage = null;
		private UnityEngine.UI.Text m_EclosetextText = null;
		private UnityEngine.UI.Image m_EUpListImage = null;
		private UnityEngine.UI.Button m_ECloseUpButton = null;
		private UnityEngine.UI.Image m_ECloseUpImage = null;
		private UnityEngine.UI.Button m_EUpButton = null;
		private UnityEngine.UI.Image m_EUpImage = null;
		private UnityEngine.UI.Text m_ELabel_UpText = null;
		private UnityEngine.UI.Button m_EDeleteUpButton = null;
		private UnityEngine.UI.Image m_EDeleteUpImage = null;
		private UnityEngine.UI.Text m_EDeleteMoneyText = null;
		private UnityEngine.UI.Button m_ETowerInfoButton = null;
		private UnityEngine.UI.Image m_ETowerInfoImage = null;
		private UnityEngine.UI.Text m_ELabel_TowerNameText = null;
		private UnityEngine.UI.Text m_ELabel_TowerAttackValueText = null;
		private UnityEngine.UI.Text m_ELabel_TowerAttackIntervalText = null;
		private UnityEngine.UI.Text m_ELabel_TowerNextMoneyText = null;
		public Transform uiTransform = null;
        public int TowerConfigId;
        public long TowerId;
        public int TowerLevel;
        public int Position;
        public Tower tower;
        public EventTrigger ShowTowerInfo;
        public GameObject TowerInfoObj;
        public bool InfoIsTrigger;
        public float InfoTimer;
    }
}
