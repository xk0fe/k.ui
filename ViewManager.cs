using System.Collections.Generic;
using k.UI.Animations;
using k.UI.Animations.Interfaces;
using k.UI.Models;
using k.UI.Views;
using UnityEngine;

namespace k.UI
{
    public class ViewManager
    {
        private readonly Transform _viewParent;
        private readonly ViewFactory _viewFactory;
        private readonly Dictionary<string, ViewBase> _views = new();
        private readonly Dictionary<string, ViewBase> _viewInstances = new();

        
        public ViewManager(Transform viewParent, ViewFactory viewFactory, IEnumerable<ViewBase> views = null)
        {
            _viewParent = viewParent;
            _viewFactory = viewFactory;
            if (views != null) Register(views);
        }

        public void Register(IEnumerable<ViewBase> views)
        {
            foreach (var view in views)
            {
                Register(view.GetType().Name, view);
            }
        }
        
        public void Register(string viewName, ViewBase view)
        {
#if UNITY_EDITOR
            if (_views.ContainsKey(viewName))
            {
                Debug.LogError($"Duplicate view with name {viewName} found, overwriting the old one");
            }
#endif
            _views[viewName] = view;
        }

        public void Unregister(string viewName)
        {
            if (_views.ContainsKey(viewName))
            {
                _views.Remove(viewName);
            }
        }

        public void CloseAllViews()
        {
            foreach (var (id, instance) in _viewInstances)
            {
                instance.SetActive(false);
            }
        }

        public void SetActiveView(
            string viewName,
            bool isActive,
            ViewModelBase model = null,
            IViewAnimation animation = null)
        {
            SetActiveView<ViewBase>(viewName, isActive, model, animation);
        }

        public T SetActiveView<T>(
            string viewName,
            bool isActive,
            ViewModelBase model = null,
            IViewAnimation animation = null
        ) where T : ViewBase
        {
            if (string.IsNullOrEmpty(viewName))
            {
                Debug.LogError("View name cannot be null or empty.");
                return null;
            }
            
            if (!TryGetOrCreate(viewName, out var view)) return null;
            if (model != null) view.OnViewModelUpdate(model);
            if (isActive == view.IsActive) return (T)view;
            view.SetActive(isActive, animation);
            return (T)view;
        }

        private bool TryGetOrCreate(string viewName, out ViewBase view)
        {
            if (TryGetView(viewName, out view) && view != null) return true;
            if (TryCreateView(viewName, out view) && view != null) return true;
            return false;
        }

        private bool TryGetView(string viewName, out ViewBase view)
        {
            return _viewInstances.TryGetValue(viewName, out view);
        }

        private bool TryCreateView(string viewName, out ViewBase view)
        {
            view = null;
            if (!_views.TryGetValue(viewName, out var viewPrefab))
            {
                Debug.LogError($"View with name {viewName} not found");
                return false;
            }
            
            if (viewPrefab == null)
            {
                Debug.LogError($"View with name {viewName} is null");
                return false;
            }
            
            if (_viewParent == null)
            {
                Debug.LogError($"View parent is null");
                return false;
            }
            
            view = _viewFactory.CreateView(viewPrefab, _viewParent);
            _viewInstances[viewName] = view;
            return true;
        }
        
        public bool TryGetView<T>(string name, out T view) where T : ViewBase
        {
            if (TryGetOrCreate(name, out var viewBase))
            {
                view = (T)viewBase;
                return true;
            }

            view = null;
            return false;
        }

        public bool IsActive(string name)
        {
            if (!TryGetView(name, out var view)) return false;
            return view.IsActive;
        }
    }
}