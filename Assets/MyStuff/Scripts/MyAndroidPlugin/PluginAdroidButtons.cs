using System;
using UnityEngine;
using UnityEngine.UI;
public class PluginAdroidButtons : MonoBehaviour
{
    [SerializeField] private Button ClearDataButton;
    [SerializeField] private TMPro.TextMeshProUGUI showeableText;

    private void Start()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("Wrong platform");
            return;
        }
        ClearDataButton.onClick.AddListener(ShowAlert);
    }
    private void OnEnable() => showeableText.text = PluginAndroid.Get()?.GetFile();

    private void ShowAlert() => PluginAndroid.Get()?.CallAlert("ALERT", "clear?", "yes", "no", PluginAndroid.Get().CallClear);
    
}
