using System;
using UnityEngine;
using UnityEngine.Events;

public class PluginAndroid : MonoBehaviourSingleton<PluginAndroid>
{
    private CostomLogs androidLogs;
    private FileManagerAndroid fileManagerAndroid;
    private Alert2DialogManager alert2DialogManager;

    public void MyStart()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("Wrong platform");
            return;
        }
        androidLogs = new CostomLogs();
        fileManagerAndroid = new FileManagerAndroid();
        alert2DialogManager = new Alert2DialogManager();
        androidLogs.OnAndroidCall+=fileManagerAndroid.WriteFile;
    }
    private void WriteFile(string msg)
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("Wrong platform");
            return;
        }
        fileManagerAndroid.WriteFile(msg + '\n');
    }
    public void SendLog(string msg)
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("Wrong platform");
            return;
        }
        androidLogs.AndroidLog(msg);
        WriteFile(msg);
    }
    public void CallAlert(string windowName, string textMsg, string afirmativeAnser, string negativeAnser,UnityAction actionIfAfirmative)
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("Wrong platform");
            return;
        }
        alert2DialogManager.showAlertDialog(new string[] { windowName, textMsg, negativeAnser, afirmativeAnser }, (Int32 obj) => {
            if (obj == -2)
                actionIfAfirmative?.Invoke();
        });
    }
    public void CallClear()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("Wrong platform");
            return;
        }
        fileManagerAndroid.ClearFile();
    }
    public string GetFile()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("Wrong platform");
            return "";
        }
        return fileManagerAndroid.ReadFile();
    }
}
