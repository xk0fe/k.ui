using UnityEngine;
using k.Services;
using k.UI.Configs;
using k.UI;

namespace k.UI.Samples.ServiceConfiguration
{
    [CreateAssetMenu(menuName = "k/UI/" + nameof(UiService), fileName = nameof(UiService), order = 0)]
    public class UiService : GenericScriptableService<UiService>
    {
        [SerializeField] private UiConfig _config;

        public override void Initialize()
        {
            base.Initialize();
            Ui.Instance.Initialize(_config, new ViewFactory());
        }
    }
}