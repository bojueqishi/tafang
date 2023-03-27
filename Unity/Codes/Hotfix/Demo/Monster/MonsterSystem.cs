using System;

namespace ET
{
    public class MonsterAwakeSystem : AwakeSystem<Monster,int>
    {
        public override void Awake(Monster self,int configId)
        {
            self.ConfigId = configId;
        }
    }
    public static class MonsterSystem
    {
        public static async void OnLogicBuff(this Monster self,int dt)
        {
            if(self.GetComponent<BurningBuffComponent>() != null)
            {
                self.GetComponent<BurningBuffComponent>().OnLogicUpdate(dt).Coroutine();
            }
            await ETTask.CompletedTask;
        }

    }
}
