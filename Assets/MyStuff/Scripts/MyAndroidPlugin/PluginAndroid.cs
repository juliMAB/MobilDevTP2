using UnityEngine;

public class PluginAndroid : MonoBehaviourSingleton<PluginAndroid>
{
    private CostomLogs androidLogs;
    private FileManagerAndroid fileManagerAndroid;
    private Alert2DialogManager alert2DialogManager;

    private void Start()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("Wrong platform");
            return;
        }
        androidLogs = new CostomLogs();
        fileManagerAndroid = new FileManagerAndroid();
        alert2DialogManager = new Alert2DialogManager();
    }

    public void SendLog(string msg)
    {
        androidLogs.AndroidLog(msg);
    }
}
