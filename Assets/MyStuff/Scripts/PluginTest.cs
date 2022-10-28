using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PluginTest : MonoBehaviour
{
    [SerializeField] private Button AlertButton;
    [SerializeField] private Button logButton;
    [SerializeField] private Button logButtonUnity;
    private AlertDialogManager alert;
    private CostomLogs androidLogs;

    private void Start()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("Wrong platform");
            return;
        }
        alert = new AlertDialogManager();
        androidLogs = new CostomLogs();
        AlertButton.onClick.AddListener(alert.ShowAlert);
        logButton.onClick.AddListener(ExampleLogCall);
    }
    private void ExampleLogCall() => androidLogs.AndroidLog("example_Log_Button_OnClick");

    public void UnityLogCall() => Debug.Log("example_unity_Debug.Log");

}

