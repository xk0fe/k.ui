using UnityEngine;
using k.Services;
using k.UI.Common;
using k.UI.Common.Configs;
using k.UI.Common.Implementations;

namespace k.UI.Samples.ServiceConfiguration
{
    [CreateAssetMenu(menuName = "k/UI/" + nameof(UiService), fileName = nameof(UiService), order = 0)]
    public class UiService : GenericScriptableService<UiService>
    {
        [SerializeField] private UiConfig _config;

        private Canvas _canvas;
        
        public override void Initialize()
        {
            base.Initialize();
            Ui.Instance.Initialize(_config, new ViewFactory(), out _canvas);
        }
    }
}