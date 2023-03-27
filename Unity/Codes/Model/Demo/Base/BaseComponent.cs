namespace ET
{
    [ComponentOf(typeof(Scene))]
    [ChildType(typeof(Base))]
    public class BaseComponent : Entity, IAwake, IDestroy
    {
    }
}
