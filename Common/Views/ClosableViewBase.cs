using UnityEngine;
using UnityEngine.UI;

namespace k.UI.Common.Views
{
    public class ClosableViewBase : ViewBase
    {
        [SerializeField] private Button[] _closeButtons;

        protected override void OnEnable()
        {
            base.OnEnable();
            foreach (var button in _closeButtons)
            {
                button.onClick.AddListener(DisableView);
            }
        }

        private void DisableView()
        {
            SetActive(false);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            foreach (var button in _closeButtons)
            {
                button.onClick.RemoveListener(DisableView);
            }
        }
    }
}