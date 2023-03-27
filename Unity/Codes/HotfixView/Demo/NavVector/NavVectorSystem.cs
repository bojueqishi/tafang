using System;
using UnityEngine;
namespace ET
{
    public class NavVectorAwakeSystem : AwakeSystem<NavVector>
    {
        public override void Awake(NavVector self)
        {
            self.NavDictionary.Add(1, 
                new Vector3[] { 
                new Vector3(-4.8f,4.5f,0),
                new Vector3(-3.8f,2.8f,0),
                new Vector3(-5.1f,2.5f,0),
                new Vector3(-8.1f,2.2f,0),
                new Vector3(-7.5f,0.25f,0),
                new Vector3(-3.5f,0,0),
                new Vector3(-2.5f,-0.6f,0),
                new Vector3(-2.2f,-2.3f,0),
                new Vector3(-4.5f,-2.8f,0),
                new Vector3(-4.7f,-3.5f,0),
            });
            self.NavDictionary.Add(2,
                new Vector3[] {
                new Vector3(4.8f,4.5f,0),
                new Vector3(3.8f,2.8f,0),
                new Vector3(5.1f,2.5f,0),
                new Vector3(8.1f,2.2f,0),
                new Vector3(7.5f,0.25f,0),
                new Vector3(3.5f,0,0),
                new Vector3(2.5f,-0.6f,0),
                new Vector3(2.2f,-2.3f,0),
                new Vector3(4.5f,-2.8f,0),
                new Vector3(4.7f,-3.5f,0),
            });
        }
    }
    public class NavVectorDestroySystem : DestroySystem<NavVector>
    {
        public override void Destroy(NavVector self)
        {
            
        }
    }
    [FriendClass(typeof(NavVector))]
    public static class NavVectorSystem
    {
        public static Vector3[] GetPosByNavId(this NavVector self,int NavID)
        {
            return self.NavDictionary[NavID];
        } 
    }
}
