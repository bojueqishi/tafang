namespace ET
{
    [ObjectSystem]
    public class MonsterComponentAwakeSystem : AwakeSystem<MonsterComponent>
    {
        public override void Awake(MonsterComponent self)
        {
        }
    }

    [ObjectSystem]
    public class MonsterComponentDestroySystem : DestroySystem<MonsterComponent>
    {
        public override void Destroy(MonsterComponent self)
        {
        }
    }

    public static class MonsterComponentSystem
    {
        public static void Add(this MonsterComponent self, Monster monster)
        {
        }

        public static Monster Get(this MonsterComponent self, long id)
        {
            Monster monster = self.GetChild<Monster>(id);
            return monster;
        }

        public static void Remove(this MonsterComponent self, Monster monster)
        {
            monster?.Dispose();
        }
    }
}