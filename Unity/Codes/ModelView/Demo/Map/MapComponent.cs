using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class MapComponent : Entity,IAwake,IDestroy
    {
        public GameObject MapObject;
        public List<GameObject> TowerBgs = new List<GameObject>();
    }
}
