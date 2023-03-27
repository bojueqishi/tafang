
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgMap1ViewComponentAwakeSystem : AwakeSystem<DlgMap1ViewComponent> 
	{
		public override void Awake(DlgMap1ViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;

		}
	}
    [FriendClass(typeof(GameComponent))]
    public class DlgMap1ViewComponentUpdateSystem : UpdateSystem<DlgMap1ViewComponent>
    {
        public override void Update(DlgMap1ViewComponent self)
        {
            
        }
    }

    [ObjectSystem]
	public class DlgMap1ViewComponentDestroySystem : DestroySystem<DlgMap1ViewComponent> 
	{
		public override void Destroy(DlgMap1ViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
