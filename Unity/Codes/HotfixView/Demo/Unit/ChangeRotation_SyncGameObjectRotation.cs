using UnityEngine;

namespace ET
{
    public class ChangeRotation_SyncGameObjectRotation: AEventClass<EventType.ChangeRotation>
    {
        protected override void Run(object changeRotation)
        {
            EventType.ChangeRotation args = changeRotation as EventType.ChangeRotation;
            GameObjectComponent gameObjectComponent = null;
            if (args.Unit != null) gameObjectComponent = args.Unit.GetComponent<GameObjectComponent>();
            if (args.Monster != null) gameObjectComponent = args.Monster.GetComponent<GameObjectComponent>();
            if (args.Tower != null) gameObjectComponent = args.Tower.GetComponent<GameObjectComponent>();
            if(args.Bullet != null) gameObjectComponent = args.Bullet.GetComponent<GameObjectComponent>();
            if (gameObjectComponent == null)
            {
                return;
            }
            Transform transform = gameObjectComponent.GameObject.transform;
            if(args.Unit != null)
            {
                transform.rotation = args.Unit.Rotation;
            }
            if (args.Monster != null)
            {
                transform.rotation = args.Monster.Rotation;
            }
            if(args.Tower != null)
            {
                transform.rotation = args.Tower.Rotation;
            }
            if (args.Bullet != null)
            {
                transform.rotation = args.Bullet.Rotation;
            }
        }
    }
}
