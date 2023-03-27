namespace ET
{
    [ComponentOf(typeof(Scene))]
    [ChildType(typeof(Monster))]
    public class MonsterComponent : Entity, IAwake, IDestroy
    {
    }
}
