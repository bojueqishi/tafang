using ProtoBuf;
using System.Collections.Generic;

namespace ET
{
    public partial class MonsterWaveConfigCategory : ProtoObject, IMerge
    {
        public List<MonsterWaveConfig> GetAllConfigByWaveCode(string WaveCode)
        {
            List<MonsterWaveConfig> waves = new List<MonsterWaveConfig>();
            foreach (MonsterWaveConfig config in list)
            {
                if (config.WaveCode == WaveCode)
                {
                    waves.Add(config);
                }
            }
            return waves;
        }
    }
}
