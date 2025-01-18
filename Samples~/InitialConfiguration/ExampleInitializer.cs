using System.Collections;
using UnityEngine;
using k.UI.Configs;
using k.UI;

namespace k.UI.Samples.InitialConfiguration
{
    public class ExampleInitializer : MonoBehaviour
    {
        [SerializeField] private UiConfig _config;
        
        private void Awake()
        {
            Ui.Instance.Initialize(_config, new ViewFactory());
        }

        private IEnumerator WaitAndOpenViewCoroutine()
        {
            yield return new WaitForSeconds(1);
            Ui.Open<ExampleView>();
        }
    }
}