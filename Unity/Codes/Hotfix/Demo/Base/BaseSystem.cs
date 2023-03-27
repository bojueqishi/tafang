namespace ET
{
    [ObjectSystem]
    public class BaseComponentAwakeSystem : AwakeSystem<BaseComponent>
    {
        public override void Awake(BaseComponent self)
        {
        }
    }

    [ObjectSystem]
    public class BaseComponentDestroySystem : DestroySystem<BaseComponent>
    {
        public override void Destroy(BaseComponent self)
        {
        }
    }

    public static class BaseComponentSystem
    {
        public static void Add(this BaseComponent self, Base Base)
        {
        }

        public static Base Get(this BaseComponent self, long id)
        {
            Base Base = self.GetChild<Base>(id);
            return Base;
        }

        public static void Remove(this BaseComponent self, Base Base)
        {
            Base?.Dispose();
        }
    }
}