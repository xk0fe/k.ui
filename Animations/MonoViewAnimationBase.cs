using k.UI.Animations.Interfaces;
using UnityEngine;

namespace k.UI.Animations
{
    /// <summary>
    /// TODO: remove MonoBehaviour, add ViewAnimation as optional parameter from code
    /// </summary>
    public class MonoViewAnimationBase : MonoBehaviour, IViewAnimation
    {
        public virtual void Play(Transform target)
        {
        }
    }
}