using UnityEngine;
using UnityEngine.UI;
public class PluginAdroidButtons : MonoBehaviour
{
    [SerializeField] private Button ClearDataButton;
    [SerializeField] private Button OnGoPluginButton;
    [SerializeField] private TMPro.TextMeshProUGUI showeableText;

    private void Awake()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("Wrong platform");
            return;
        }
        ClearDataButton.onClick.AddListener(ShowAlert);
        OnGoPluginButton.onClick.AddListener(UpdateText);
    }

    private void ShowAlert() => PluginAndroid.Get()?.CallAlert("ALERT", "clear?", "yes", "no", PluginAndroid.Get().CallClear);

    private void UpdateText() => showeableText.text = PluginAndroid.Get()?.GetFile();
}
