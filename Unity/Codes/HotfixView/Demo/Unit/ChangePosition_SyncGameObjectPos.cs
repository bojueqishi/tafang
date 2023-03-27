using System;
using UnityEngine;

namespace ET
{
    public class ChangePosition_SyncGameObjectPos: AEventClass<EventType.ChangePosition>
    {
        protected override void Run(object changePosition)
        {
            EventType.ChangePosition args = changePosition as EventType.ChangePosition;;
            GameObjectComponent gameObjectComponent = null;
            if (args.Unit != null) gameObjectComponent = args.Unit.GetComponent<GameObjectComponent>();
            if (args.Monster != null) gameObjectComponent = args.Monster.GetComponent<GameObjectComponent>();
            if (args.Tower != null) gameObjectComponent = args.Tower.GetComponent<GameObjectComponent>();
            if(args.Bullet!=null) gameObjectComponent = args.Bullet.GetComponent<GameObjectComponent>();
            if (gameObjectComponent == null)
            {
                return;
            }
            Transform transform = gameObjectComponent.GameObject.transform;
            if(args.Unit != null) transform.position = args.Unit.Position;
            if (args.Monster != null) transform.position = args.Monster.Position;
            if (args.Tower != null) transform.position = args.Tower.Position;
            if (args.Bullet != null) transform.position = args.Bullet.Position;
        }
    }
}