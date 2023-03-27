
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace ET
{
    [ObjectSystem]
    public class ESCreateMonsterAwakeSystem : AwakeSystem<ESCreateMonster, Transform>
    {
        public override void Awake(ESCreateMonster self, Transform transform)
        {
            self.uiTransform = transform;
            self.InfoIsTrigger = false;
        }
    }

    [ObjectSystem]
    public class ESCreateMonsterUpdateSystem : UpdateSystem<ESCreateMonster>
    {
        public override void Update(ESCreateMonster self)
        {
            if(self.InfoIsTrigger)
            {
                self.InfoTimer = self.InfoTimer + Time.deltaTime;
            }
            else
            {
                self.InfoTimer = 0;
            }
            if(self.InfoTimer >= 1)
            {
                self.EMonsterInfoBaseSpriteImage.gameObject.SetActive(true);
            }
        }
    }


    [ObjectSystem]
    public class ESCreateMonsterDestroySystem : DestroySystem<ESCreateMonster>
    {
        public override void Destroy(ESCreateMonster self)
        {
            self.DestroyWidget();
        }
    }
    [FriendClass(typeof(ESCreateMonster))]
    public static class ESCreateMonsterViewSystem
    {
        public static void RegisterEvenet(this ESCreateMonster self, int MonsterConfigId)
        {
            self.ECreateMonsterButtonButton.AddListenerAsync(() =>
            {
                return self.CreateMonster(MonsterConfigId);
            });
            self.RegisterMonsterInfo();
        }
        public static void RegisterMonsterInfo(this ESCreateMonster self)
        {
            EventTrigger.Entry entry1 = new EventTrigger.Entry();
            entry1.eventID = EventTriggerType.PointerEnter;
            entry1.callback.AddListener((data1) =>
            {
                self.ShowInfos();
            });
            self.ECreateMonsterButtonEventTrigger.triggers.Add(entry1);

            EventTrigger.Entry entry2 = new EventTrigger.Entry();
            entry2.eventID = EventTriggerType.PointerExit;
            entry2.callback.AddListener((data2) =>
            {
                self.CloseInfos();
            });
            self.ECreateMonsterButtonEventTrigger.triggers.Add(entry2);
        }
        public static void ShowInfos(this ESCreateMonster self)
        {
            self.InfoIsTrigger = true;
        }
        public static void CloseInfos(this ESCreateMonster self)
        {
            self.EMonsterInfoBaseSpriteImage.gameObject.SetActive(false);
            self.InfoIsTrigger = false;
        }
        public static void ShowWindow(this ESCreateMonster self, int MonsterConfigId)
        {
            self.uiTransform.gameObject.SetActive(true);
            MonsterConfig monsterconfig = MonsterConfigCategory.Instance.Get(MonsterConfigId);
            if(monsterconfig != null)
            {
                self.ECreateMonsterMoneyNumberTextText.SetText(monsterconfig.NeedMoney.ToString());
            }
            self.EMonsterInfoBaseSpriteImage.transform.gameObject.SetActive(false);
            //self.ELabelMonsterNameText.SetText(Monster.ToString());
        }
        public static void HideWindow(this ESCreateMonster self)
        {
            self.uiTransform.gameObject.SetActive(false);

        }
        public static async ETTask CreateMonster(this ESCreateMonster self, int MonsterConfigId)
        {
            self.CloseInfos();
            MonsterConfig monsterconfig = MonsterConfigCategory.Instance.Get(MonsterConfigId);
            int needmoney = monsterconfig.NeedMoney;
            int currentmoney = UnitHelper.GetMyUnitFromCurrentScene(self.ZoneScene().CurrentScene()).GetComponent<NumericComponent>().GetAsInt(NumericType.GameMoney);
            if (needmoney > currentmoney) return;
            try
            {
                int errorcode = await GameHelper.CreateMonster(self.ZoneScene(), MonsterConfigId);
                if (errorcode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorcode.ToString());
                    return;
                }
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return;
            }
        }
    }
}
