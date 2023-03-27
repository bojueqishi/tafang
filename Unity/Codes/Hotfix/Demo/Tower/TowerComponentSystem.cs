namespace ET
{
    [ObjectSystem]
    public class TowerComponentAwakeSystem : AwakeSystem<TowerComponent>
    {
        public override void Awake(TowerComponent self)
        {

        }
    }

    [ObjectSystem]
    public class TowerComponentDestroySystem : DestroySystem<TowerComponent>
    {
        public override void Destroy(TowerComponent self)
        {
        }
    }

    public static class TowerComponentSystem
    {
        public static void Add(this TowerComponent self, Tower tower)
        {
        }

        public static Tower Get(this TowerComponent self, long id)
        {
            Tower tower = self.GetChild<Tower>(id);
            return tower;
        }

        public static void Remove(this TowerComponent self, long id)
        {
            Tower tower = self.GetChild<Tower>(id);
            tower?.Dispose();
        }
    }
}