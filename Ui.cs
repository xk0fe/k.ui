using System.Collections.Generic;
using k.UI.Animations;
using k.UI.Animations.Interfaces;
using k.UI.Configs;
using k.UI.Enums;
using k.UI.Models;
using k.UI.Views;
using UnityEngine;

namespace k.UI
{
    public class Ui
    {
        #region Singleton
        private static Ui _instance;

        public static Ui Instance => _instance ??= new Ui();

        #endregion
        
        private Dictionary<string, ViewBase> _bases;
        private ViewManager _viewManager;
        
        public void Initialize(UiConfig uiConfig, ViewFactory viewFactory)
        {
            var canvas = Object.Instantiate(uiConfig.Canvas);
            Object.DontDestroyOnLoad(canvas);
            _viewManager = new ViewManager(canvas.transform, viewFactory, uiConfig.ViewBases);
            _instance = this;
        }

        public static T Open<T>(
            ViewModelBase model = null,
            ViewLoadingMode loadingMode = ViewLoadingMode.Additive,
            ScriptableAnimationBase animation = null
        ) where T : ViewBase
        {
            if (loadingMode == ViewLoadingMode.Single)
            {
                CloseAllViews();
            }

            var name = typeof(T).Name;
            return Instance._viewManager.SetActiveView<T>(name, true, model, animation);
        }

        public static void Close<T>() where T : ViewBase
        {
            var name = typeof(T).Name;
            Instance._viewManager.SetActiveView(name, false);
        }

        public static T SetActive<T>(
            bool isActive,
            ViewModelBase model = null,
            IViewAnimation animation = null
        ) where T : ViewBase
        {
            var name = typeof(T).Name;
            return Instance._viewManager.SetActiveView<T>(name, isActive, model, animation);
        }

        public static void SetActive(string viewName, bool isActive, ViewModelBase model = null)
        {
            Instance._viewManager.SetActiveView(viewName, isActive, model);
        }
        
        public static bool TryGet<T>(out T view) where T : ViewBase
        {
            var name = typeof(T).Name;
            return Instance._viewManager.TryGetView(name, out view);
        }
        
        public static bool IsActive<T>() where T : ViewBase
        {
            var viewName = typeof(T).Name;
            return IsActive(viewName);
        }

        public static bool IsActive(string viewName)
        {
            return Instance._viewManager.IsActive(viewName);
        }
        
        private static void CloseAllViews()
        {
            Instance._viewManager.CloseAllViews();
        }
    }
}