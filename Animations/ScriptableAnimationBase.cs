using k.UI.Animations.Interfaces;
using UnityEngine;

namespace k.UI.Animations
{
    public class ScriptableAnimationBase : ScriptableObject, IViewAnimation
    {
        public virtual void Play(Transform target)
        {
        }
    }
}