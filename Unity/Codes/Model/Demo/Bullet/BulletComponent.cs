namespace ET
{
    [ComponentOf(typeof(Scene))]
    [ChildType(typeof(Bullet))]
    public class BulletComponent : Entity, IAwake, IDestroy
    {
    }
}
