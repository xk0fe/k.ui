using k.UI.Animations;
using UnityEngine;

namespace k.UI.Samples.AnimationExample
{
    public class DefaultViewAnimations : ViewAnimationsBase<DefaultViewAnimations>
    {
        [SerializeField] private ScriptableAnimationBase _openScaleFromZero;

        public static ScriptableAnimationBase OpenScaleFromZero => Instance != null ? Instance._openScaleFromZero : null;
    }
}