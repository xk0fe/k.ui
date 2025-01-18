using k.UI.Animations.Interfaces;
using k.UI.Models;
using UnityEngine;

namespace k.UI.Views
{
    public class ViewBase : MonoBehaviour
    {
        protected virtual void Awake()
        {
            Initialize();
        }

        protected virtual void OnEnable()
        {
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

        public virtual void SetActive(bool isActive, IViewAnimation viewAnimation = null)
        {
            gameObject.SetActive(isActive);
            if (isActive && viewAnimation != null) viewAnimation.Play(transform);
        }

        public bool IsActive => gameObject != null && gameObject.activeSelf;
    }
}