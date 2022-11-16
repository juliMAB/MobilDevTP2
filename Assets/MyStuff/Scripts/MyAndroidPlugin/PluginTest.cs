using System;
using UnityEngine;
using UnityEngine.UI;

public class PluginTest : MonoBehaviour
{
    //private AlertDialogManager alert;
    private CostomLogs androidLogs;
    private FileManagerAndroid fileManagerAndroid;
    private Alert2DialogManager alert2DialogManager;


    [SerializeField] private Button AlertButton;
    [SerializeField] private Button logButton;
    [SerializeField] private Button logButtonUnity;
    [SerializeField] private Button ClearDataButton;
    [SerializeField] private TMPro.TextMeshProUGUI showeableText;

    private void Start()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("Wrong platform");
            return;
        }
        //alert = new AlertDialogManager();
        androidLogs = new CostomLogs();
        fileManagerAndroid = new FileManagerAndroid();
        alert2DialogManager = new Alert2DialogManager();
        //AlertButton.onClick.AddListener(alert.ShowAlert);
        logButton.onClick.AddListener(ExampleLogCall);
        logButtonUnity.onClick.AddListener(UnityLogCall);
        ClearDataButton.onClick.AddListener(ShowAlert);
        androidLogs.OnAndroidCall += UpdateShowingText;
        UpdateShowingText("Start Test PluginExample");
    }
    private void ExampleLogCall() => androidLogs.AndroidLog("example_Log_Button_OnClick");

    private void UnityLogCall() => Debug.Log("example_unity_Debug.Log");

    private void UpdateShowingText(string msg)
    {
        fileManagerAndroid.WriteFile(msg + '\n');
        showeableText.text = fileManagerAndroid.ReadFile();
    }
    private void ShowAlert()
    {
        alert2DialogManager.showAlertDialog(new string[] { "POPAndroid", "ClearData?", "NO", "YES" }, (Int32 obj) => {
            if (obj == -2)
                ClearData();
        });
    }
    private void ClearData()
    {
        fileManagerAndroid.ClearFile();
        UpdateShowingText(" ");
    }


}

