using UnityEngine.UI;
using UnityEngine;
namespace ET
{
    public static class CampHelper
    {
        public static void InitCamp(Scene zonescene,Image hpbar1,Image hpbar2,Text LeftText,Text RightText,Text LeftPlayerName,Text RightPlayerName)
        {
            int position = UnitHelper.GetMyUnitFromCurrentScene(zonescene.CurrentScene()).GetComponent<NumericComponent>().GetAsInt(NumericType.Position);
            if (position == 1)//在左边
            {
                hpbar1.sprite = IconHelper.LoadIconSprite("GameElement", "MyHpBar");
                hpbar1.transform.rotation = Quaternion.Euler(0, 0, 0);
                hpbar1.fillOrigin = (int)Image.OriginHorizontal.Left;
                hpbar2.sprite = IconHelper.LoadIconSprite("GameElement", "OtherHpBar");
                hpbar2.transform.rotation = Quaternion.Euler(0, 0, 0);
                hpbar2.fillOrigin = (int)Image.OriginHorizontal.Left;
                RightText.SetText("???");
            }
            if(position == 2)//在右边
            {
                hpbar2.sprite = IconHelper.LoadIconSprite("GameElement", "MyHpBar");
                hpbar2.transform.rotation = Quaternion.Euler(0, 180, 0);
                hpbar2.fillOrigin = (int)Image.OriginHorizontal.Right;
                hpbar1.sprite = IconHelper.LoadIconSprite("GameElement", "OtherHpBar");
                hpbar1.transform.rotation = Quaternion.Euler(0, 180, 0);
                hpbar1.fillOrigin = (int)Image.OriginHorizontal.Right;
                LeftText.SetText("???");
            }
        }
    }
}
