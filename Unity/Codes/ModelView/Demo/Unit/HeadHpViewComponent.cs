using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [ComponentOf]
    public class HeadHpViewComponent : Entity,IAwake,IUpdate,IDestroy
    {
        public GameObject HpBarGroup = null;
        public SpriteRenderer HpBar = null;
        public TextMeshPro HpText = null;
        public float Timer;
    }
}
