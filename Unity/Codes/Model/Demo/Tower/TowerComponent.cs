namespace ET
{
    [ComponentOf(typeof(Scene))]
    [ChildType(typeof(Tower))]
    public class TowerComponent : Entity, IAwake, IDestroy
    {
    }
}
