
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgMainHomeViewComponentAwakeSystem : AwakeSystem<DlgMainHomeViewComponent> 
	{
		public override void Awake(DlgMainHomeViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgMainHomeViewComponentDestroySystem : DestroySystem<DlgMainHomeViewComponent> 
	{
		public override void Destroy(DlgMainHomeViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
