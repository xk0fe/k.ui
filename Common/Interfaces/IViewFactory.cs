using k.UI.Common.Views;
using UnityEngine;

namespace k.UI.Common.Interfaces {
    public interface IViewFactory {
        public ViewBase CreateView(ViewBase prefab, Transform parent);
    }
}