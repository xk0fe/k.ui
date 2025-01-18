using k.UI.Animations;
using UnityEngine;

namespace k.UI.Samples.AnimationExample
{
    /// <summary>
    /// You can simply derive from this class to add your own animations.
    /// </summary>
    public class ViewAnimationsBase<T> : MonoBehaviour where T : ViewAnimationsBase<T>
    {
        #region Singleton
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = FindFirstObjectByType<T>();

                if (_instance != null) return _instance;
                var singletonObj = new GameObject(nameof(T));
                _instance = singletonObj.AddComponent<T>();
                return _instance;
            }
        }
        #endregion
    }
}