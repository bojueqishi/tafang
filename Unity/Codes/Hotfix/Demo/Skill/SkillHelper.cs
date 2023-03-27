using System.Collections.Generic;
using System;
namespace ET
{
    public static class SkillHelper
    {
        public static Dictionary<string,int> GetSkillString(string SkillParams) 
        {
            Dictionary<string,int> list = new Dictionary<string,int>();
            string[] param = SkillParams.Split(';');
            for(int i=0;i<param.Length;i++)
            {
                string[] temp = param[i].Split(',');
                if(temp.Length == 2)
                {
                    string name = temp[0];
                    int numeric = int.Parse(temp[1]);
                    list.Add(name, numeric);
                }
            }
            return list;
        }
        public static void OnSkill(Entity entity)
        {
            foreach (Type type in entity.Components.Keys)
            {
                if (typeof(Skill).IsAssignableFrom(type))
                {
                    Entity component = entity.Components[type];
                    Type system = Type.GetType(type.FullName + "System");
                    system.GetMethod("OnSkill").Invoke(component, new object[] {component});
                }
            }
        }
    }
}
