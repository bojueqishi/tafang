using System;

namespace ET
{
    public static class UnitCacheHelper 
    {
        //保存或者更新玩家缓存
        public static async ETTask AddOrUpdateUnitCache<T>(this T self,long serverId) where T: Entity,IUnitCache
        {
            Other2UnitCache_AddOrUpdateUnit message = new Other2UnitCache_AddOrUpdateUnit() {UnitId = self.Id};
            message.EntityTypes.Add(typeof(T).FullName);
            message.EntityBytes.Add(MongoHelper.ToBson(self));
            await MessageHelper.CallActor(StartSceneConfigCategory.Instance.GetUnitCacheConfig(serverId).InstanceId, message);
        }
        public static async ETTask<Unit> GetUnitCache(Scene scene, long AccountId,long serverId)
        {
            long instanceId = StartSceneConfigCategory.Instance.GetUnitCacheConfig(serverId).InstanceId;
            
            Other2UnitCache_GetUnit message = new Other2UnitCache_GetUnit() { UnitId = AccountId };
            UnitCache2Other_GetUnit query = (UnitCache2Other_GetUnit)await MessageHelper.CallActor(instanceId, message);
            if (query.Error != ErrorCode.ERR_Success || query.EntityList.Count <= 0)
            {
                return null;
            }

            int indexof = query.ComponentNameList.IndexOf(nameof(Unit));
            Unit unit = query.EntityList[indexof] as Unit;
            if (unit == null)
            {
                return null;
            }
            scene.AddChild(unit);
            foreach (Entity entity in query.EntityList)
            {
                if (entity == null || entity is Unit)
                {
                    continue;
                }
                unit.AddComponent(entity);
            }
            return unit;
        }
        //获取玩家组件缓存
        public static async ETTask<T> GetUnitComponentCache<T>(long unitId,long serverId) where T : Entity,IUnitCache
        {
            Other2UnitCache_GetUnit message = new Other2UnitCache_GetUnit() { UnitId = unitId };
            message.ComponentNameList.Add(typeof(T).Name);
            long instanceId = StartSceneConfigCategory.Instance.GetUnitCacheConfig(serverId).InstanceId;
            UnitCache2Other_GetUnit unitCache2Other_GetUnit = (UnitCache2Other_GetUnit) await MessageHelper.CallActor(instanceId, message);
            if(unitCache2Other_GetUnit.Error == ErrorCode.ERR_Success && unitCache2Other_GetUnit.EntityList.Count > 0)
            {
                return unitCache2Other_GetUnit.EntityList[0] as T;   
            }
            return null;
        }
        //删除玩家组件缓存
        public static async ETTask DeleteUnitCache(long unitId,long serverId)
        {
            Other2UnitCache_DeleteUnit message = new Other2UnitCache_DeleteUnit() { UnitId = unitId };
            long instanceId = StartSceneConfigCategory.Instance.GetUnitCacheConfig(serverId).InstanceId;
            await MessageHelper.CallActor(instanceId, message); 
        }
        public static async void AddOrUpdateUnitAllCache(Unit unit,long serverId)
        {
            Other2UnitCache_AddOrUpdateUnit message = new Other2UnitCache_AddOrUpdateUnit() { UnitId = unit.Id };
            message.EntityTypes.Add(unit.GetType().FullName);
            message.EntityBytes.Add(MongoHelper.ToBson(unit));
            foreach((Type key,Entity entity) in unit.Components)
            {
                if(!typeof(IUnitCache).IsAssignableFrom(key))
                {
                    continue;
                }
                message.EntityTypes.Add(key.FullName);
                message.EntityBytes.Add(MongoHelper.ToBson(entity));
            }

            await MessageHelper.CallActor(StartSceneConfigCategory.Instance.GetUnitCacheConfig(serverId).InstanceId, message);
        }
        
    }
}
