using Packaged.k.UI.Animations;
using Packaged.k.UI.Models;
using UnityEngine;

namespace Packaged.k.UI.Views
{
    public class ViewBase : MonoBehaviour
    {
        private ViewAnimation _viewAnimation;
        
        protected virtual void Awake()
        {
            Initialize();
            if (TryGetComponent<ViewAnimation>(out var openAnimation)) _viewAnimation = openAnimation;
        }

        protected virtual void OnEnable()
        {
            if (_viewAnimation != null) _viewAnimation.Play();
        }

        protected virtual void OnDisable()
        {
        }

        public virtual void OnViewModelUpdate(ViewModelBase model)
        {
        }

        protected virtual void Initialize()
        {
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public bool IsActive => gameObject != null && gameObject.activeSelf;
    }
}