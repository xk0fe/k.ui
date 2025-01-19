using k.UI.Common.Interfaces;
using k.UI.Common.Views;
using UnityEngine;

namespace k.UI.Common.Implementations
{
    public class ViewFactory : IViewFactory
    {
        public virtual ViewBase CreateView(ViewBase prefab, Transform parent)
        {
            return Object.Instantiate(prefab, parent);
        }
    }
}