using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public class FlyDamageValueViewAwakeComponent : AwakeSystem<FlyDamageValueViewComponent>
    {
        public override void Awake(FlyDamageValueViewComponent self)
        {
            self.Awake().Coroutine();
        }
    }
    public class FlyDamageValueViewDestroyComponent : DestroySystem<FlyDamageValueViewComponent>
    {
        public override void Destroy(FlyDamageValueViewComponent self)
        {
            ForeachHelper.Foreach<GameObject>(self.FlyingDamageSet, (o) =>
            {
                o.transform.DOKill();
                GameObject.Destroy(o);
            });
            self.FlyingDamageSet.Clear();
        }
    }
    [FriendClass(typeof(FlyDamageValueViewComponent))]
    public static class FlyDamageValueViewComponentSystem
    {
        public static async ETTask Awake(this FlyDamageValueViewComponent self)
        {
            await ResourcesComponent.Instance.LoadBundleAsync("FlyDamageValue.unity3d");
            GameObject prefabGameObject = (GameObject)ResourcesComponent.Instance.GetAsset("FlyDamageValue.unity3d", "FlyDamageValue");
            await GameObjectPoolHelper.InitPoolFormGamObjectAsync(prefabGameObject, 3);
        }
        public static async ETTask SpawnFlyDamage(this FlyDamageValueViewComponent self,Vector3 startpos,long damagevalue)
        {
            GameObject flyobj = GameObjectPoolHelper.GetObjectFromPool("FlyDamageValue");
            flyobj.transform.SetParent(GlobalComponent.Instance.Unit);
            self.FlyingDamageSet.Add(flyobj);
            flyobj.SetActive(true);

            flyobj.GetComponent<TextMeshPro>().text = "-" + damagevalue;
            flyobj.transform.position = startpos;

            flyobj.transform.DOMoveY(startpos.y + 1.5f,0.8f).onComplete = () =>{
                flyobj.SetActive(false);
                self.FlyingDamageSet.Remove(flyobj);
                GameObjectPoolHelper.ReturnObjectToPool(flyobj);
            };

            await ETTask.CompletedTask;
        }
    }
}
