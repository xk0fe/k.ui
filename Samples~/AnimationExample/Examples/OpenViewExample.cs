using UnityEngine;

namespace k.UI.Samples.AnimationExample.Examples
{
    public class OpenViewExample : MonoBehaviour
    {
        [ContextMenu(nameof(Open))]
        public void Open()
        {
            Ui.Open<ViewExample>(animation: DefaultViewAnimations.OpenScaleFromZero);
        }
    }
}