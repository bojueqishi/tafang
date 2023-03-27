using UnityEngine;
namespace ET
{
    public class TowerChargeComponentAwakeSystem : AwakeSystem<TowerChargeComponent>
    {
        public override void Awake(TowerChargeComponent self)
        {
            GameObject obj = self.GetParent<Tower>().GetComponent<GameObjectComponent>().GameObject;
            self.TowerChargeBarGroup = obj.GetComponent<ReferenceCollector>().GetObject("TowerChargeBar") as GameObject;
            self.ChargeBar = (obj.GetComponent<ReferenceCollector>().GetObject("ChargeBar") as GameObject).GetComponent<SpriteRenderer>();
            if((obj.GetComponent<ReferenceCollector>().GetObject("AttackPoint") as GameObject)!=null)
            {
                self.AttackPoint = (obj.GetComponent<ReferenceCollector>().GetObject("AttackPoint") as GameObject).transform;
            }
            int skillId = self.GetParent<Tower>().GetComponent<NumericComponent>().GetAsInt(NumericType.TowerSkillId);
            if (skillId == 0) self.TowerChargeBarGroup.gameObject.SetActive(false);
            self.ChargeBar.size = new Vector2(0, 0.2f);
        }
    }
    public class TowerChargeComponentDestroySystem : DestroySystem<TowerChargeComponent>
    {
        public override void Destroy(TowerChargeComponent self)
        {
            self.TowerChargeBarGroup = null;
            self.ChargeBar = null;
        }
    }
    [FriendClass(typeof(TowerChargeComponent))]
    public static class TowerChargeComponentSystem
    {
        public static void SetChargeBar(this TowerChargeComponent self,float SizeX)
        {
            self.ChargeBar.size = new Vector2(SizeX * 76.0f / 10.0f, 1f);
        }
    }
}
