using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
using DG.Tweening;
namespace ET
{
	[FriendClass(typeof(DlgMap1))]
    [FriendClass(typeof(ESButton_CreateTower))]
    public static  class DlgMap1System
	{

		public static void RegisterUIEvent(this DlgMap1 self)
		{
            self.View.ESButton_CreateTower1.RegisterEventAndShowLabelAndRegisterPosition(1);
            self.View.ESButton_CreateTower2.RegisterEventAndShowLabelAndRegisterPosition(1);
            self.View.ESButton_CreateTower3.RegisterEventAndShowLabelAndRegisterPosition(1);
            self.View.ESButton_CreateTower4.RegisterEventAndShowLabelAndRegisterPosition(1);
            self.View.ESButton_CreateTower5.RegisterEventAndShowLabelAndRegisterPosition(1);
            self.View.ESButton_CreateTower6.RegisterEventAndShowLabelAndRegisterPosition(1);
            self.View.ESButton_CreateTower7.RegisterEventAndShowLabelAndRegisterPosition(1);
            self.View.ESButton_CreateTower8.RegisterEventAndShowLabelAndRegisterPosition(1);
            self.View.ESButton_CreateTower9.RegisterEventAndShowLabelAndRegisterPosition(2);
            self.View.ESButton_CreateTower10.RegisterEventAndShowLabelAndRegisterPosition(2);
            self.View.ESButton_CreateTower11.RegisterEventAndShowLabelAndRegisterPosition(2);
            self.View.ESButton_CreateTower12.RegisterEventAndShowLabelAndRegisterPosition(2);
            self.View.ESButton_CreateTower13.RegisterEventAndShowLabelAndRegisterPosition(2);
            self.View.ESButton_CreateTower14.RegisterEventAndShowLabelAndRegisterPosition(2);
            self.View.ESButton_CreateTower15.RegisterEventAndShowLabelAndRegisterPosition(2);
            self.View.ESButton_CreateTower16.RegisterEventAndShowLabelAndRegisterPosition(2);

            self.eSButton_CreateTowers.Add(self.View.ESButton_CreateTower1);
            self.eSButton_CreateTowers.Add(self.View.ESButton_CreateTower2);
            self.eSButton_CreateTowers.Add(self.View.ESButton_CreateTower3);
            self.eSButton_CreateTowers.Add(self.View.ESButton_CreateTower4);
            self.eSButton_CreateTowers.Add(self.View.ESButton_CreateTower5);
            self.eSButton_CreateTowers.Add(self.View.ESButton_CreateTower6);
            self.eSButton_CreateTowers.Add(self.View.ESButton_CreateTower7);
            self.eSButton_CreateTowers.Add(self.View.ESButton_CreateTower8);
            self.eSButton_CreateTowers.Add(self.View.ESButton_CreateTower9);
            self.eSButton_CreateTowers.Add(self.View.ESButton_CreateTower10);
            self.eSButton_CreateTowers.Add(self.View.ESButton_CreateTower11);
            self.eSButton_CreateTowers.Add(self.View.ESButton_CreateTower12);
            self.eSButton_CreateTowers.Add(self.View.ESButton_CreateTower13);
            self.eSButton_CreateTowers.Add(self.View.ESButton_CreateTower14);
            self.eSButton_CreateTowers.Add(self.View.ESButton_CreateTower15);
            self.eSButton_CreateTowers.Add(self.View.ESButton_CreateTower16);
        }

		public static void ShowWindow(this DlgMap1 self, Entity contextData = null)
		{

		}
        public static void CloseOtherList(this DlgMap1 self,ESButton_CreateTower e)
        {
            for(int i=0;i<self.eSButton_CreateTowers.Count; i++)
            {
                if (self.eSButton_CreateTowers[i] != e)
                {
                    self.eSButton_CreateTowers[i].CloseListInfo().Coroutine();
                }
            }
        }
        public static async ETTask SettingTower(this DlgMap1 self,Tower tower,long TowerId,int opttype,float TowerX,float TowerY)
        {
            for(int i=0;i<self.eSButton_CreateTowers.Count;i++)
            {
                ESButton_CreateTower es = self.eSButton_CreateTowers[i];
                float px = es.EButton_CreateTowerButton.transform.position.x;
                float py = es.EButton_CreateTowerButton.transform.position.y;
                float distance = UnityEngine.Vector3.Distance(new UnityEngine.Vector2(px, py), new UnityEngine.Vector2((float)(TowerX/10000.0f), (float)(TowerY/10000.0f)));
                if(distance < 0.02f)
                {
                    es.SettingTower(tower,TowerId,opttype).Coroutine();
                }
            }

            await ETTask.CompletedTask;
        }
		 

	}
}
