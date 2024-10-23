using Packaged.k.UI.Views;
using UnityEngine;

namespace Packaged.k.UI
{
    public class ViewFactory
    {
        public virtual ViewBase CreateView(ViewBase prefab, Transform parent)
        {
            return Object.Instantiate(prefab, parent);
        }
    }
}