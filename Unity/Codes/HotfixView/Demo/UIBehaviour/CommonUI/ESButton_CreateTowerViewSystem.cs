using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace ET
{
    [ObjectSystem]
    public class ESButton_CreateTowerAwakeSystem : AwakeSystem<ESButton_CreateTower, Transform>
    {
        public override void Awake(ESButton_CreateTower self, Transform transform)
        {
            self.uiTransform = transform;
        }
    }
    public class ESButton_CreateTowerUpdateSystem : UpdateSystem<ESButton_CreateTower>
    {
        public override void Update(ESButton_CreateTower self)
        {
            if (self.InfoIsTrigger)
            {
                self.InfoTimer = self.InfoTimer + Time.deltaTime;
            }
            else
            {
                self.InfoTimer = 0;
            }
            if (self.InfoTimer >= 1)
            {
                if (self.TowerLevel == 0) return;
                if (self.ETowerInfoImage.gameObject.activeSelf == false)
                {
                    self.ETowerInfoImage.gameObject.SetActive(true);
                }
                TowerConfig towerconfig = TowerConfigCategory.Instance.Get(self.TowerConfigId);

                if (self.TowerLevel < 3)
                {
                    self.ELabel_TowerNameText.SetText(towerconfig.Name);
                    self.ELabel_TowerAttackValueText.SetText("攻击伤害:" + towerconfig.Attack.ToString());
                    self.ELabel_TowerAttackIntervalText.SetText("攻击间隔:" + ((float)towerconfig.AttackInterval / 10000.0f).ToString());
                    TowerConfig nextconfig = TowerConfigCategory.Instance.Get(self.TowerConfigId + 1);
                    self.ELabel_TowerNextMoneyText.SetText("下一级造价:" + nextconfig.Price.ToString());
                }
                else
                {
                    self.ELabel_TowerNameText.SetText(towerconfig.Name);
                    self.ELabel_TowerAttackValueText.SetText("攻击伤害:" + towerconfig.Attack.ToString());
                    self.ELabel_TowerAttackIntervalText.SetText("攻击间隔:" + ((float)towerconfig.AttackInterval / 10000.0f).ToString());
                    self.ELabel_TowerNextMoneyText.SetText("最高级");
                }
            }
        }
    }


    [ObjectSystem]
    public class ESButton_CreateTowerDestroySystem : DestroySystem<ESButton_CreateTower>
    {
        public override void Destroy(ESButton_CreateTower self)
        {
            self.DestroyWidget();
        }
    }
    [FriendClass(typeof(ESButton_CreateTower))]
    [FriendClass(typeof(GameComponent))]
    public static class ESButton_CreateTowerSystem
    {
        public static void RegisterEventAndShowLabelAndRegisterPosition(this ESButton_CreateTower self, int Position)
        {
            self.EButton_CreateTowerButton.AddListener(() => {  self.ShowCreateButtonList().Coroutine(); });
            self.EclosebtButton.AddListener(() => { self.CloseCreateButtonList().Coroutine(); });
            Unit unit = UnitHelper.GetMyUnitFromCurrentScene(self.ZoneScene().CurrentScene());
            NumericComponent numeric = unit.GetComponent<NumericComponent>();
            self.Position = Position;
            int TowerId1 = numeric.GetAsInt(NumericType.TowerId1);
            int TowerId2 = numeric.GetAsInt(NumericType.TowerId2);
            int TowerId3 = numeric.GetAsInt(NumericType.TowerId3);
            int TowerId4 = numeric.GetAsInt(NumericType.TowerId4);
            float X = self.EButton_CreateTowerButton.transform.position.x;
            float Y = self.EButton_CreateTowerButton.transform.position.y;
            //绑定造塔按钮
            self.Ecreatebt1Button.AddListener(() =>
            {
                self.CreateTower(X, Y, TowerId1).Coroutine();
            });
            self.Ecreatebt2Button.AddListener(() =>
            {
                self.CreateTower(X, Y, TowerId2).Coroutine();
            });
            self.Ecreatebt3Button.AddListener(() =>
            {
                self.CreateTower(X, Y, TowerId3).Coroutine();
            });
            self.Ecreatebt4Button.AddListener(() =>
            {
                self.CreateTower(X,Y, TowerId4).Coroutine();
            });
            int pos = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.Position);
            if (self.Position != pos) self.EButton_CreateTowerButton.gameObject.SetActive(false);
            //显示造塔的Id
            self.Ecreatemoneytext1Text.SetText(TowerConfigCategory.Instance.GetTowerNeedMoneyByTowerId(TowerId1).ToString());
            self.Espritetower1Image.sprite = IconHelper.LoadIconSprite("Tower", TowerConfigCategory.Instance.Get(TowerId1).PrefabName);
            self.Ecreatemoneytext2Text.SetText(TowerConfigCategory.Instance.GetTowerNeedMoneyByTowerId(TowerId2).ToString());
            self.Espritetower2Image.sprite = IconHelper.LoadIconSprite("Tower", TowerConfigCategory.Instance.Get(TowerId2).PrefabName);
            self.Ecreatemoneytext3Text.SetText(TowerConfigCategory.Instance.GetTowerNeedMoneyByTowerId(TowerId3).ToString());
            self.Espritetower3Image.sprite = IconHelper.LoadIconSprite("Tower", TowerConfigCategory.Instance.Get(TowerId3).PrefabName);
            self.Ecreatemoneytext4Text.SetText(TowerConfigCategory.Instance.GetTowerNeedMoneyByTowerId(TowerId4).ToString());
            self.Espritetower4Image.sprite = IconHelper.LoadIconSprite("Tower", TowerConfigCategory.Instance.Get(TowerId4).PrefabName);
            self.EDeleteUpButton.AddListener(() => { self.DeleteTower().Coroutine(); });//售卖塔
            self.ECloseUpButton.AddListener(() => { self.CloseUpTowerList().Coroutine(); });
            self.EUpButton.AddListener(() => { self.UpTower(X,Y).Coroutine(); });
            //self.EclosetextText.SetText("关闭");
            self.ShowTowerInfo = self.EButton_CreateTowerEventTrigger;
            self.RegisterTowerInfos();
        }
        public static void RegisterPosition(this ESButton_CreateTower self, int position)
        {
            self.Position = position;
        }
        public static void RegisterTowerInfos(this ESButton_CreateTower self)
        {
            EventTrigger.Entry entry1 = new EventTrigger.Entry();
            entry1.eventID = EventTriggerType.PointerEnter;
            entry1.callback.AddListener((data1) =>
            {
                self.ShowInfos();
            });
            self.ShowTowerInfo.triggers.Add(entry1);

            EventTrigger.Entry entry2 = new EventTrigger.Entry();
            entry2.eventID = EventTriggerType.PointerExit;
            entry2.callback.AddListener((data2) =>
            {
                self.CloseInfos();
            });
            self.ShowTowerInfo.triggers.Add(entry2);
        }
        public static void ShowInfos(this ESButton_CreateTower self)
        {
            self.InfoIsTrigger = true;

        }
        public static void CloseInfos(this ESButton_CreateTower self)
        {
            if (self.ETowerInfoImage.gameObject.activeSelf == true)
            {
                self.ETowerInfoImage.gameObject.SetActive(false);
            }
            self.InfoIsTrigger = false;
        }
        public static async ETTask ShowCreateButtonList(this ESButton_CreateTower self)
        {
            int Position = UnitHelper.GetMyUnitFromCurrentScene(self.ZoneScene().CurrentScene()).GetComponent<NumericComponent>().GetAsInt(NumericType.Position);
            if (self.ZoneScene().CurrentScene().GetComponent<GameComponent>().GameEnding == false) return;
            if (Position != self.Position) return;
            self.InfoIsTrigger = false;
            self.CloseMapOtherList().Coroutine();
            if (self.ETowerInfoImage.gameObject.activeSelf == true)
            {
                self.ETowerInfoImage.gameObject.SetActive(false);
            }
            if (self.TowerLevel == 0)
            {
                self.EListImage.transform.gameObject.SetActive(true);
            }
            else if (self.TowerLevel == 1 || self.TowerLevel == 2)
            {
                //显示升级或者售出
                self.EUpListImage.gameObject.SetActive(true);
                self.ELabel_UpText.SetText(TowerConfigCategory.Instance.GetTowerNeedMoneyByTowerId(self.TowerConfigId + 1).ToString());
                self.EUpButton.gameObject.SetActive(true);
            }
            else if (self.TowerLevel == 3)
            {
                //只显示售出
                self.EUpListImage.gameObject.SetActive(true);
                self.EUpButton.gameObject.SetActive(false);
            }
            if (self.TowerLevel == 3) return;
            await ETTask.CompletedTask;
        }
        public static async ETTask CloseListInfo(this ESButton_CreateTower self)
        {
            self.EUpListImage.gameObject.SetActive(false);
            self.EListImage.gameObject.SetActive(false);
            await ETTask.CompletedTask;
        }
        public static async ETTask CloseUpTowerList(this ESButton_CreateTower self)
        {
            self.EUpListImage.gameObject.SetActive(false);
            await ETTask.CompletedTask;
        }
        public static async ETTask CloseCreateButtonList(this ESButton_CreateTower self)
        {
            self.EListImage.gameObject.SetActive(false);
            await ETTask.CompletedTask;
        }
        public static async ETTask DeleteTower(this ESButton_CreateTower self)
        {
            try
            {
                int errorcode = await GameHelper.DeleteTower(self.ZoneScene(), self.TowerId, self.TowerConfigId, self.EButton_CreateTowerButton.transform.position.x * 10000, self.EButton_CreateTowerButton.transform.position.y * 10000);
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
            await ETTask.CompletedTask;
        }
        public static async ETTask CreateTower(this ESButton_CreateTower self, float PX, float PY, int TowerConfigId)
        {
            //先判断钱 再发送消息
            Unit unit = UnitHelper.GetMyUnitFromCurrentScene(self.ZoneScene().CurrentScene());
            NumericComponent component = unit.GetComponent<NumericComponent>();
            int playerposition = component.GetAsInt(NumericType.Position);
            if (playerposition != self.Position) return;
            int CurrentMoney = component.GetAsInt(NumericType.GameMoney);//当前钱
            TowerConfig towerconfig = TowerConfigCategory.Instance.Get(TowerConfigId);//造塔钱
            int NeedMoney = towerconfig.Price;
            if (CurrentMoney < NeedMoney) return;

            //视角尺寸计算
            Transform cameratransform = GlobalComponent.Instance.MainCamera;
            float Scale = self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgGameUI>().SetVisualScale(0);
            //其余操作都在返回后更改
            try
            {
                int errorcode = await GameHelper.CreateTower(self.ZoneScene(), TowerConfigId, PX * 10000, PY * 10000);
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
            //在帧同步处绑定塔
            self.EListImage.gameObject.SetActive(false);
        }
        public static async ETTask UpTower(this ESButton_CreateTower self,float PX,float PY)
        {
            Unit unit = UnitHelper.GetMyUnitFromCurrentScene(self.ZoneScene().CurrentScene());
            NumericComponent component = unit.GetComponent<NumericComponent>();
            int playerposition = component.GetAsInt(NumericType.Position);
            if (playerposition != self.Position) return;
            int CurrentMoney = component.GetAsInt(NumericType.GameMoney);//当前钱
            int NewTowerConfigId = self.TowerConfigId + 1;//新的塔ConfigId
            TowerConfig towerconfig = TowerConfigCategory.Instance.Get(NewTowerConfigId);//造塔钱
            int NeedMoney = towerconfig.Price;
            if (CurrentMoney < NeedMoney) return;
            try//摧毁塔
            {
                int errorcode = await GameHelper.UpTower(self.ZoneScene(), NewTowerConfigId, self.TowerId, PX * 10000, PY * 10000);
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
            //在帧同步处绑定塔

            self.EUpListImage.transform.gameObject.SetActive(false);
            await ETTask.CompletedTask;
        }
        public static async ETTask SettingTower(this ESButton_CreateTower self, Tower tower, long TowerId, int opttype)
        {
            if (opttype == (int)OptType.CreateTower)
            {
                self.tower = tower;
                self.TowerConfigId = tower.Config.Id;
                self.TowerId = TowerId;
                self.TowerLevel = (tower.Config.Id - 1) % 3 + 1;
                int returnmoney = 0;
                for(int i=(int)(self.TowerConfigId - (self.TowerConfigId - 1)%3);i <= self.TowerConfigId; i++)
                {
                    returnmoney = returnmoney + TowerConfigCategory.Instance.Get(i).Price * 70 / 100;
                }
                self.EDeleteMoneyText.SetText(returnmoney.ToString());
            }
            if (opttype == (int)OptType.UpTower)
            {
                self.tower = tower;
                self.TowerConfigId = tower.Config.Id;
                self.TowerId = TowerId;
                self.TowerLevel = (tower.Config.Id - 1) % 3 + 1;
                int returnmoney = 0;
                for (int i = (int)(self.TowerConfigId - (self.TowerConfigId - 1) % 3); i <= self.TowerConfigId; i++)
                {
                    returnmoney = returnmoney + TowerConfigCategory.Instance.Get(i).Price * 70 / 100;
                }
                self.EDeleteMoneyText.SetText(returnmoney.ToString());
            }
            if (opttype == (int)OptType.DeleteTower)
            {
                self.tower = null;
                self.TowerConfigId = 0;
                self.TowerId = 0;
                self.TowerLevel = 0;
                self.EUpListImage.gameObject.SetActive(false);
                self.EButton_CreateTowerImage.color = new Color(1, 0, 0, 0);
            }

            await ETTask.CompletedTask;
        }
        public static async ETTask CloseMapOtherList(this ESButton_CreateTower self)
        {
            self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgGameUI>().CloseOtherList(self);
            await ETTask.CompletedTask;
        }
    }
}
