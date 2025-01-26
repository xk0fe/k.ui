using k.UI.Common.Interfaces;
using UnityEngine;

namespace k.UI.Common.Animations {
    public class ScriptableAnimationBase : ScriptableObject, IViewAnimation {
        public virtual void Play(Transform target) {
        }
    }
}