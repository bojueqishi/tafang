using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public class HeadHpViewComponentAwakeSystem : AwakeSystem<HeadHpViewComponent>
    {
        public override void Awake(HeadHpViewComponent self)
        {
            self.Timer = 0;
        }
    }
    public class HeadHpViewComponentUpdateSystem : UpdateSystem<HeadHpViewComponent>
    {
        public override void Update(HeadHpViewComponent self)
        {
            if (self.GetParent<Base>() != null) return;//基地
            if(self.HpBarGroup.activeSelf == true)
            {
                self.Timer = self.Timer + Time.deltaTime;
            }
            if(self.Timer > 3)
            {
                self.HideHpBar();
            }
        }
    }
    public class HeadHpViewComponentDestroySystem : DestroySystem<HeadHpViewComponent>
    {
        public override void Destroy(HeadHpViewComponent self)
        {
            self.HpBar = null;
            self.HpBarGroup = null;
            self.HpText = null;
            self.Timer = 0;
        }
    }

    [FriendClass(typeof(HeadHpViewComponent))]
    public static class HeadHpViewComponentSystem
    {
        public static void Init(this HeadHpViewComponent self,int type)
        {
            GameObject gameobject = null;
            switch (type)
            {
                case 1://怪物
                    gameobject = self.GetParent<Monster>().GetComponent<GameObjectComponent>().GameObject;
                    break;
                case 2://基地
                    gameobject = self.GetParent<Base>().GetComponent<GameObjectComponent>().GameObject;
                    break;
            }
            self.HpBarGroup = gameobject.GetComponent<ReferenceCollector>().GetObject("HpBarGroup") as GameObject;
            self.HpBar = (gameobject.GetComponent<ReferenceCollector>().GetObject("HpBar") as GameObject).GetComponent<SpriteRenderer>();
            self.HpText = (gameobject.GetComponent<ReferenceCollector>().GetObject("HpText") as GameObject).GetComponent<TextMeshPro>();
            self.HpBarGroup.gameObject.SetActive(false);
        }
        public static void SetMonsterHp(this HeadHpViewComponent self)  
        {
            NumericComponent num = self.GetParent<Monster>().GetComponent<NumericComponent>();
            int maxhp = num.GetAsInt(NumericType.MonsterMaxHp);
            int hp = num.GetAsInt(NumericType.MonsterHp);

            self.HpText.text = hp.ToString() + "/" + maxhp.ToString();
            self.HpBar.size = new Vector2((float)hp / maxhp * 76.0f / 10.0f, self.HpBar.size.y);
        }
        public static void ShowHpBar(this HeadHpViewComponent self)
        {
            self.HpBarGroup.SetActive(true);
            self.Timer = 0;
        }
        public static void HideHpBar(this HeadHpViewComponent self)
        {
            self.HpBarGroup.SetActive(false);
            self.Timer = 0;
        }
        public static void SetBaseHp(this HeadHpViewComponent self)
        {
            NumericComponent num = self.GetParent<Base>().GetComponent<NumericComponent>();
            int maxhp = num.GetAsInt(NumericType.BaseMaxHp);
            int hp = num.GetAsInt(NumericType.BaseHp);

            self.HpText.text = hp.ToString() + "/" + maxhp.ToString();
            self.HpBar.size = new Vector2((float)hp / maxhp, self.HpBar.size.y);
        }
    }
}
