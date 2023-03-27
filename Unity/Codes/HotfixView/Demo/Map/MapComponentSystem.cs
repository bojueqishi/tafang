using UnityEngine;

namespace ET
{
    public class MapComponentDestroySystem : DestroySystem<MapComponent>
    {
        public override void Destroy(MapComponent self)
        {
            if(self.MapObject !=null)
            {
                GameObject.Destroy(self.MapObject);
            }
            foreach(GameObject obj in self.TowerBgs)
            {
                if(obj != null)
                {
                    GameObject.Destroy(obj);
                }
            }
        }
    }
    public static class MapComponentSystem
    {
    }
}
