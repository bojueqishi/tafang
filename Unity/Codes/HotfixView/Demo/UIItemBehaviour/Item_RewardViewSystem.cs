
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_RewardDestroySystem : DestroySystem<Scroll_Item_Reward> 
	{
		public override void Destroy( Scroll_Item_Reward self )
		{
			self.DestroyWidget();
		}
	}
}
