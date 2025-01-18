using System.Collections.Generic;
using k.UI.Configs;
using k.UI.Views;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace k.UI.Editor
{
    public class UiResolverWindow : EditorWindow
    {
        private UiConfig _config;
        
        [MenuItem("k/UI/UiAutoResolver")]
        public static void Open()
        {
            var wnd = GetWindow<UiResolverWindow>();
            wnd.titleContent = new GUIContent("UiAutoResolver");
        }
        
        public void CreateGUI()
        {
            var root = rootVisualElement;

            CreateDescription(root);
            CreateConfig(root);
            CreateButton(root);
        }

        private void CreateDescription(VisualElement root)
        {
            var header = new Label("Resolve UI references")
            {
                style =
                {
                    fontSize = 16
                }
            };
            root.Add(header);
            var description = new Label("Find all UI prefabs that have ViewBase component and add them to the config.")
            {
                style =
                {
                    flexGrow = 1,
                    whiteSpace = WhiteSpace.Normal,
                    maxWidth = Length.Percent(100),
                    marginTop = 10
                }
            };
            root.Add(description);
        }

        private void CreateConfig(VisualElement root)
        {
            var config = new ObjectField("Config")
            {
                objectType = typeof(UiConfig)
            };
            config.RegisterValueChangedCallback(evt =>
            {
                _config = evt.newValue as UiConfig;
            });
            root.Add(config);
        }

        private void CreateButton(VisualElement root)
        {
            var button = new Button
            {
                name = "button",
                text = "Resolve"
            };
            button.clicked += OnButtonClick;
            root.Add(button);
        }

        private void OnButtonClick()
        {
            if (_config == null)
            {
                Debug.LogError("Config is null");
                return;
            }
            var prefabs = AssetDatabase.FindAssets("t:Prefab");
            var views = new List<ViewBase>();
            foreach (var prefab in prefabs)
            {
                var path = AssetDatabase.GUIDToAssetPath(prefab);
                var asset = AssetDatabase.LoadAssetAtPath<GameObject>(path);
                if (asset.TryGetComponent<ViewBase>(out var viewBase))
                {
                    views.Add(viewBase);
                }
            }
            
            _config.SetViews(views);
            EditorUtility.SetDirty(_config);
            AssetDatabase.SaveAssets();
        }
    }
}