using System.Collections.Generic;
using Packaged.k.UI.Views;
using UnityEngine;

namespace Packaged.k.UI.Configs
{
    [CreateAssetMenu(menuName = "k.UI/" + nameof(UiConfig), fileName = nameof(UiConfig), order = 0)]
    public class UiConfig : ScriptableObject
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private List<ViewBase> _viewBases;

        public Canvas Canvas => _canvas;
        public List<ViewBase> ViewBases => _viewBases;
    }
}