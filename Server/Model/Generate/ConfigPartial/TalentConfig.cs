using System.Collections.Generic;

namespace ET
{
    public partial class TalentConfigCategory
    {
        public List<int> GetTalentIdByCode(string code)
        {
            List<int> talents = new List<int>();
            foreach(TalentConfig config in TalentConfigCategory.Instance.GetAll().Values)
            {
                if(config.Code == code)
                {
                    talents.Add(config.Id);
                }
            }
            return talents;
        }
    }
}
