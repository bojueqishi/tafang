using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Tower))]
    public class CanisterSkill : Entity,IAwake,IDestroy,LogicSkill,Skill
    {
        public int SkillTimer;
        public int SkillTime;
        public Dictionary<string, int> param;
        public int FlySpeed;
        public string PrefabName;
    }
}
