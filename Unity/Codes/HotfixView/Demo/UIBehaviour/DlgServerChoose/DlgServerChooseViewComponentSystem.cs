
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgServerChooseViewComponentAwakeSystem : AwakeSystem<DlgServerChooseViewComponent> 
	{
		public override void Awake(DlgServerChooseViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgServerChooseViewComponentDestroySystem : DestroySystem<DlgServerChooseViewComponent> 
	{
		public override void Destroy(DlgServerChooseViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
