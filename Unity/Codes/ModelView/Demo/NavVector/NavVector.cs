using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class NavVector : Entity,IAwake,IDestroy
    {
        public Dictionary<int, Vector3[]> NavDictionary = new Dictionary<int, Vector3[]>();
    }
}
