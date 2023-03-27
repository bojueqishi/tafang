namespace ET
{
    public class MatchComponentAwakeSystem : AwakeSystem<MatchComponent>
    {
        public override void Awake(MatchComponent self)
        {
            self.CurrentMatch = 0;
            self.MatchUnits.Clear();
        }
    }
    public class MatchComponentDestorySystem : DestroySystem<MatchComponent>
    {
        public override void Destroy(MatchComponent self)
        {
            self.CurrentMatch = 0;
            self.MatchUnits.Clear();
        }
    }
    [FriendClass(typeof(MatchComponent))]
    public static class MatchComponentSystem
    {
        public static void Add(this MatchComponent self,Unit unit)
        {
            if(self.MatchUnits.Contains(unit))
            {
                return;
            }
            self.MatchUnits.Add(unit);
        }
        public static void Remove(this MatchComponent self,Unit unit)
        {
            if(self.MatchUnits.Contains(unit))
            {
                self.MatchUnits.Remove(unit);
            }
        }
    }
}
