using System;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.UIElements;

namespace ET
{
    [FriendClass(typeof(AnimatorComponent))]
    public static class AnimatorHelper 
    {
        public static async ETTask Play(Entity entity,string AnimatorName)
        {
            AnimatorComponent animatorcomponent = entity.GetComponent<AnimatorComponent>();
            if (animatorcomponent.Animator == null) return;
            if (!animatorcomponent.Animator.GetCurrentAnimatorStateInfo(0).IsName(AnimatorName) && IsExistAnimatorName(entity,AnimatorName))
            {
                animatorcomponent.Animator.CrossFade(AnimatorName, 0);
            }
            await ETTask.CompletedTask;
        }
        public static bool IsExistAnimatorName(Entity entity,string AnimatorName)
        {
            bool result = false;
            AnimatorComponent animatorcomponent = entity.GetComponent<AnimatorComponent>();
            AnimationClip[] clips = animatorcomponent.Animator.runtimeAnimatorController.animationClips;
            foreach (var animationclip in clips)
            {
                if (animationclip.name.Equals(AnimatorName))
                {
                    result = true;
                    return result;
                }
            }
            return result;
        }
        public static float GetCurrentClipTime(Entity entity,string AnimatorName)
        {
            float length = 0;
            AnimatorComponent animatorcomponent = entity.GetComponent<AnimatorComponent>();
            AnimationClip[] clips = animatorcomponent.Animator.runtimeAnimatorController.animationClips;
            foreach(var animationclip in clips)
            {
                if(animationclip.name.Equals(AnimatorName))
                {
                    length = animationclip.length;
                }
            }
            return length;
        }
    }
}
