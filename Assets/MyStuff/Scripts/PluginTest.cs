using UnityEngine;
using UnityEngine.UI;

public class PluginTest : MonoBehaviour
{
    [SerializeField] private Button AlertButton;
    [SerializeField] private Button logButton;
    [SerializeField] private Button logButtonUnity;
    [SerializeField] private Button ClearDataButton;
    private AlertDialogManager alert;
    private CostomLogs androidLogs;
    private FileManagerAndroid fileManagerAndroid;
    [SerializeField] private TMPro.TextMeshProUGUI showeableText;

    private void Start()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("Wrong platform");
            return;
        }
        alert = new AlertDialogManager();
        androidLogs = new CostomLogs();
        fileManagerAndroid = new FileManagerAndroid();
        AlertButton.onClick.AddListener(alert.ShowAlert);
        logButton.onClick.AddListener(ExampleLogCall);
        logButtonUnity.onClick.AddListener(UnityLogCall);
        ClearDataButton.onClick.AddListener(ClearData);
        androidLogs.OnAndroidCall += UpdateShowingText;
    }
    private void ExampleLogCall() => androidLogs.AndroidLog("example_Log_Button_OnClick");

    private void UnityLogCall() => Debug.Log("example_unity_Debug.Log");

    private void UpdateShowingText(string msg)
    {
        fileManagerAndroid.WriteFile(msg + '\n');
        showeableText.text = fileManagerAndroid.ReadFile();
    }
    private void ClearData()
    {
        fileManagerAndroid.ClearFile();
    }


}

