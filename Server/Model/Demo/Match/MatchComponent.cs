using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class MatchComponent : Entity,IAwake,IDestroy
    {
        public List<Unit> MatchUnits = new List<Unit>();
        public int CurrentMatch;
    }
}
