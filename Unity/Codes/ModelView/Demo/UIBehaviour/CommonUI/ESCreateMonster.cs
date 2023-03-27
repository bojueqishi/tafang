
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class ESCreateMonster : Entity,ET.IAwake<UnityEngine.Transform>,IUpdate,IDestroy 
	{
		public UnityEngine.UI.Image EMonsterAvatorBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterAvatorBaseSpriteImage == null )
     			{
		    		this.m_EMonsterAvatorBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EMonsterAvatorBaseSprite");
     			}
     			return this.m_EMonsterAvatorBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image ECreateMonsterInputBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ECreateMonsterInputBaseSpriteImage == null )
     			{
		    		this.m_ECreateMonsterInputBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ECreateMonsterInputBaseSprite");
     			}
     			return this.m_ECreateMonsterInputBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Text ECreateMonsterInputTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ECreateMonsterInputTextText == null )
     			{
		    		this.m_ECreateMonsterInputTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ECreateMonsterInputText");
     			}
     			return this.m_ECreateMonsterInputTextText;
     		}
     	}

		public UnityEngine.UI.Image ECreateMonsterMoneyBaseSprite1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ECreateMonsterMoneyBaseSprite1Image == null )
     			{
		    		this.m_ECreateMonsterMoneyBaseSprite1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ECreateMonsterMoneyBaseSprite1");
     			}
     			return this.m_ECreateMonsterMoneyBaseSprite1Image;
     		}
     	}

		public UnityEngine.UI.Image ECreateMonsterMoneyBaseSprite2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ECreateMonsterMoneyBaseSprite2Image == null )
     			{
		    		this.m_ECreateMonsterMoneyBaseSprite2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ECreateMonsterMoneyBaseSprite2");
     			}
     			return this.m_ECreateMonsterMoneyBaseSprite2Image;
     		}
     	}

		public UnityEngine.UI.Text ECreateMonsterMoneyNumberTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ECreateMonsterMoneyNumberTextText == null )
     			{
		    		this.m_ECreateMonsterMoneyNumberTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ECreateMonsterMoneyNumberText");
     			}
     			return this.m_ECreateMonsterMoneyNumberTextText;
     		}
     	}

		public UnityEngine.UI.Button ECreateMonsterButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ECreateMonsterButtonButton == null )
     			{
		    		this.m_ECreateMonsterButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"ECreateMonsterButton");
     			}
     			return this.m_ECreateMonsterButtonButton;
     		}
     	}

		public UnityEngine.UI.Image ECreateMonsterButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ECreateMonsterButtonImage == null )
     			{
		    		this.m_ECreateMonsterButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ECreateMonsterButton");
     			}
     			return this.m_ECreateMonsterButtonImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger ECreateMonsterButtonEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ECreateMonsterButtonEventTrigger == null )
     			{
		    		this.m_ECreateMonsterButtonEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"ECreateMonsterButton");
     			}
     			return this.m_ECreateMonsterButtonEventTrigger;
     		}
     	}

		public UnityEngine.UI.Image EMonsterInfoBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterInfoBaseSpriteImage == null )
     			{
		    		this.m_EMonsterInfoBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite");
     			}
     			return this.m_EMonsterInfoBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image EMonsterAvatarBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterAvatarBaseSpriteImage == null )
     			{
		    		this.m_EMonsterAvatarBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterAvatarBaseSprite");
     			}
     			return this.m_EMonsterAvatarBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image EMonsterAvatarSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterAvatarSpriteImage == null )
     			{
		    		this.m_EMonsterAvatarSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterAvatarBaseSprite/EMonsterAvatarSprite");
     			}
     			return this.m_EMonsterAvatarSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image EMonsterNameBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterNameBaseSpriteImage == null )
     			{
		    		this.m_EMonsterNameBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterNameBaseSprite");
     			}
     			return this.m_EMonsterNameBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Text EMonsterNameTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterNameTextText == null )
     			{
		    		this.m_EMonsterNameTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterNameBaseSprite/EMonsterNameText");
     			}
     			return this.m_EMonsterNameTextText;
     		}
     	}

		public UnityEngine.UI.Image EMonsterLvBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterLvBaseSpriteImage == null )
     			{
		    		this.m_EMonsterLvBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterLvBaseSprite");
     			}
     			return this.m_EMonsterLvBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Text EMonsterLvTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterLvTextText == null )
     			{
		    		this.m_EMonsterLvTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterLvText");
     			}
     			return this.m_EMonsterLvTextText;
     		}
     	}

		public UnityEngine.UI.Image EMonsterNumericBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterNumericBaseSpriteImage == null )
     			{
		    		this.m_EMonsterNumericBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterNumericBaseSprite");
     			}
     			return this.m_EMonsterNumericBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Image EMonsterAttackBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterAttackBaseSpriteImage == null )
     			{
		    		this.m_EMonsterAttackBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterNumericBaseSprite/EMonsterAttackBaseSprite");
     			}
     			return this.m_EMonsterAttackBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Text EMonsterAttackTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterAttackTextText == null )
     			{
		    		this.m_EMonsterAttackTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterNumericBaseSprite/EMonsterAttackText");
     			}
     			return this.m_EMonsterAttackTextText;
     		}
     	}

		public UnityEngine.UI.Image EMonsterHpBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterHpBaseSpriteImage == null )
     			{
		    		this.m_EMonsterHpBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterNumericBaseSprite/EMonsterHpBaseSprite");
     			}
     			return this.m_EMonsterHpBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Text EMonsterHpTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterHpTextText == null )
     			{
		    		this.m_EMonsterHpTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterNumericBaseSprite/EMonsterHpText");
     			}
     			return this.m_EMonsterHpTextText;
     		}
     	}

		public UnityEngine.UI.Image EMonsterSpeedBaseSpriteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterSpeedBaseSpriteImage == null )
     			{
		    		this.m_EMonsterSpeedBaseSpriteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterNumericBaseSprite/EMonsterSpeedBaseSprite");
     			}
     			return this.m_EMonsterSpeedBaseSpriteImage;
     		}
     	}

		public UnityEngine.UI.Text EMonsterSpeedTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterSpeedTextText == null )
     			{
		    		this.m_EMonsterSpeedTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterNumericBaseSprite/EMonsterSpeedText");
     			}
     			return this.m_EMonsterSpeedTextText;
     		}
     	}

		public UnityEngine.UI.Image EMonsterSkillBaseSprite1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterSkillBaseSprite1Image == null )
     			{
		    		this.m_EMonsterSkillBaseSprite1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterSkillBaseSprite1");
     			}
     			return this.m_EMonsterSkillBaseSprite1Image;
     		}
     	}

		public UnityEngine.UI.Image EMonsterSkillAvatarBaseSprite1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterSkillAvatarBaseSprite1Image == null )
     			{
		    		this.m_EMonsterSkillAvatarBaseSprite1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterSkillBaseSprite1/EMonsterSkillAvatarBaseSprite1");
     			}
     			return this.m_EMonsterSkillAvatarBaseSprite1Image;
     		}
     	}

		public UnityEngine.UI.Image EMonsterSkillAvatarSprite1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterSkillAvatarSprite1Image == null )
     			{
		    		this.m_EMonsterSkillAvatarSprite1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterSkillBaseSprite1/EMonsterSkillAvatarBaseSprite1/EMonsterSkillAvatarSprite1");
     			}
     			return this.m_EMonsterSkillAvatarSprite1Image;
     		}
     	}

		public UnityEngine.UI.Text EMonsterSkillNameText1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterSkillNameText1Text == null )
     			{
		    		this.m_EMonsterSkillNameText1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterSkillBaseSprite1/EMonsterSkillNameText1");
     			}
     			return this.m_EMonsterSkillNameText1Text;
     		}
     	}

		public UnityEngine.UI.Text EMonsterSkillDescriptionText1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterSkillDescriptionText1Text == null )
     			{
		    		this.m_EMonsterSkillDescriptionText1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterSkillBaseSprite1/EMonsterSkillDescriptionText1");
     			}
     			return this.m_EMonsterSkillDescriptionText1Text;
     		}
     	}

		public UnityEngine.UI.Image EMonsterSkillBaseSprite2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterSkillBaseSprite2Image == null )
     			{
		    		this.m_EMonsterSkillBaseSprite2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterSkillBaseSprite2");
     			}
     			return this.m_EMonsterSkillBaseSprite2Image;
     		}
     	}

		public UnityEngine.UI.Image EMonsterSkillAvatarBaseSprite2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterSkillAvatarBaseSprite2Image == null )
     			{
		    		this.m_EMonsterSkillAvatarBaseSprite2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterSkillBaseSprite2/EMonsterSkillAvatarBaseSprite2");
     			}
     			return this.m_EMonsterSkillAvatarBaseSprite2Image;
     		}
     	}

		public UnityEngine.UI.Image EMonsterSkillAvatarSprite2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterSkillAvatarSprite2Image == null )
     			{
		    		this.m_EMonsterSkillAvatarSprite2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterSkillBaseSprite2/EMonsterSkillAvatarBaseSprite2/EMonsterSkillAvatarSprite2");
     			}
     			return this.m_EMonsterSkillAvatarSprite2Image;
     		}
     	}

		public UnityEngine.UI.Text EMonsterSkillNameText2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterSkillNameText2Text == null )
     			{
		    		this.m_EMonsterSkillNameText2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterSkillBaseSprite2/EMonsterSkillNameText2");
     			}
     			return this.m_EMonsterSkillNameText2Text;
     		}
     	}

		public UnityEngine.UI.Text EMonsterSkillDescriptionText2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMonsterSkillDescriptionText2Text == null )
     			{
		    		this.m_EMonsterSkillDescriptionText2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EMonsterInfoBaseSprite/EMonsterSkillBaseSprite2/EMonsterSkillDescriptionText2");
     			}
     			return this.m_EMonsterSkillDescriptionText2Text;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EMonsterAvatorBaseSpriteImage = null;
			this.m_ECreateMonsterInputBaseSpriteImage = null;
			this.m_ECreateMonsterInputTextText = null;
			this.m_ECreateMonsterMoneyBaseSprite1Image = null;
			this.m_ECreateMonsterMoneyBaseSprite2Image = null;
			this.m_ECreateMonsterMoneyNumberTextText = null;
			this.m_ECreateMonsterButtonButton = null;
			this.m_ECreateMonsterButtonImage = null;
			this.m_ECreateMonsterButtonEventTrigger = null;
			this.m_EMonsterInfoBaseSpriteImage = null;
			this.m_EMonsterAvatarBaseSpriteImage = null;
			this.m_EMonsterAvatarSpriteImage = null;
			this.m_EMonsterNameBaseSpriteImage = null;
			this.m_EMonsterNameTextText = null;
			this.m_EMonsterLvBaseSpriteImage = null;
			this.m_EMonsterLvTextText = null;
			this.m_EMonsterNumericBaseSpriteImage = null;
			this.m_EMonsterAttackBaseSpriteImage = null;
			this.m_EMonsterAttackTextText = null;
			this.m_EMonsterHpBaseSpriteImage = null;
			this.m_EMonsterHpTextText = null;
			this.m_EMonsterSpeedBaseSpriteImage = null;
			this.m_EMonsterSpeedTextText = null;
			this.m_EMonsterSkillBaseSprite1Image = null;
			this.m_EMonsterSkillAvatarBaseSprite1Image = null;
			this.m_EMonsterSkillAvatarSprite1Image = null;
			this.m_EMonsterSkillNameText1Text = null;
			this.m_EMonsterSkillDescriptionText1Text = null;
			this.m_EMonsterSkillBaseSprite2Image = null;
			this.m_EMonsterSkillAvatarBaseSprite2Image = null;
			this.m_EMonsterSkillAvatarSprite2Image = null;
			this.m_EMonsterSkillNameText2Text = null;
			this.m_EMonsterSkillDescriptionText2Text = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_EMonsterAvatorBaseSpriteImage = null;
		private UnityEngine.UI.Image m_ECreateMonsterInputBaseSpriteImage = null;
		private UnityEngine.UI.Text m_ECreateMonsterInputTextText = null;
		private UnityEngine.UI.Image m_ECreateMonsterMoneyBaseSprite1Image = null;
		private UnityEngine.UI.Image m_ECreateMonsterMoneyBaseSprite2Image = null;
		private UnityEngine.UI.Text m_ECreateMonsterMoneyNumberTextText = null;
		private UnityEngine.UI.Button m_ECreateMonsterButtonButton = null;
		private UnityEngine.UI.Image m_ECreateMonsterButtonImage = null;
		private UnityEngine.EventSystems.EventTrigger m_ECreateMonsterButtonEventTrigger = null;
		private UnityEngine.UI.Image m_EMonsterInfoBaseSpriteImage = null;
		private UnityEngine.UI.Image m_EMonsterAvatarBaseSpriteImage = null;
		private UnityEngine.UI.Image m_EMonsterAvatarSpriteImage = null;
		private UnityEngine.UI.Image m_EMonsterNameBaseSpriteImage = null;
		private UnityEngine.UI.Text m_EMonsterNameTextText = null;
		private UnityEngine.UI.Image m_EMonsterLvBaseSpriteImage = null;
		private UnityEngine.UI.Text m_EMonsterLvTextText = null;
		private UnityEngine.UI.Image m_EMonsterNumericBaseSpriteImage = null;
		private UnityEngine.UI.Image m_EMonsterAttackBaseSpriteImage = null;
		private UnityEngine.UI.Text m_EMonsterAttackTextText = null;
		private UnityEngine.UI.Image m_EMonsterHpBaseSpriteImage = null;
		private UnityEngine.UI.Text m_EMonsterHpTextText = null;
		private UnityEngine.UI.Image m_EMonsterSpeedBaseSpriteImage = null;
		private UnityEngine.UI.Text m_EMonsterSpeedTextText = null;
		private UnityEngine.UI.Image m_EMonsterSkillBaseSprite1Image = null;
		private UnityEngine.UI.Image m_EMonsterSkillAvatarBaseSprite1Image = null;
		private UnityEngine.UI.Image m_EMonsterSkillAvatarSprite1Image = null;
		private UnityEngine.UI.Text m_EMonsterSkillNameText1Text = null;
		private UnityEngine.UI.Text m_EMonsterSkillDescriptionText1Text = null;
		private UnityEngine.UI.Image m_EMonsterSkillBaseSprite2Image = null;
		private UnityEngine.UI.Image m_EMonsterSkillAvatarBaseSprite2Image = null;
		private UnityEngine.UI.Image m_EMonsterSkillAvatarSprite2Image = null;
		private UnityEngine.UI.Text m_EMonsterSkillNameText2Text = null;
		private UnityEngine.UI.Text m_EMonsterSkillDescriptionText2Text = null;
		public Transform uiTransform = null;
        public bool InfoIsTrigger;
        public float InfoTimer;
	}
}
