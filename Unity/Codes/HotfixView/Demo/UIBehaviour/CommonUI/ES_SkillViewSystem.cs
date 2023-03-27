
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class ES_SkillAwakeSystem : AwakeSystem<ES_Skill,Transform> 
	{
		public override void Awake(ES_Skill self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ES_SkillDestroySystem : DestroySystem<ES_Skill> 
	{
		public override void Destroy(ES_Skill self)
		{
			self.DestroyWidget();
		}
	}
	[FriendClass(typeof(ES_Skill))]
	[ObjectSystem]
	public static class ES_SkillSystem
	{
		public static void HideWindow(this ES_Skill self)
		{
			self.uiTransform.gameObject.SetActive(false);
		}
	}
}
