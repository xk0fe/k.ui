using UnityEngine;

namespace k.UI.Common.Animations
{
    public class ScriptableViewAnimation<T> : ScriptableAnimationBase where T : class
    {
        [SerializeField] protected T _animationParameters;
        public override void Play(Transform target)
        {
            base.Play(target);
        }
    }
}