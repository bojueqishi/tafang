using System.Collections.Generic;
namespace ET
{

    [FriendClass(typeof(Monster))]
    public static class BuffHelper
    {
        public static async ETTask MonsterAddBuff(List<Monster> monsters,int BuffId)
        {
            if (BuffId == 0) return;
            if (monsters == null) return;
            BuffConfig buffconfig = BuffConfigCategory.Instance.Get(BuffId);
            int Buff = buffconfig.BuffType;
            for(int i=0;i<monsters.Count;i++)
            {
                Monster monster = monsters[i];
                switch (Buff)
                {
                    case 1://灼烧
                        if(monster.GetComponent<BurningBuffComponent>() == null)
                        {
                            monster.AddComponent<BurningBuffComponent>();
                        }
                        monster.GetComponent<BurningBuffComponent>().SetBuffTime(buffconfig.BuffContinuedTime,buffconfig.BuffEffectInterval, buffconfig.BuffDamage[0], buffconfig.BuffDamage[1]).Coroutine();
                        break;
                    case 2:
                        break;
                }
            }
            
            await ETTask.CompletedTask;
        }
    }
}
