using UnityEngine;

public class AlertDialogManager : AndroidBaseClass
{
    AndroidJavaObject pluginInstance;
    public AlertDialogManager()
    {
        InitializePlugin("com.pomelovolador.native_plugin.AlertClass");
        CreateAlert();
    }
    override protected void InitializePlugin(string pluginName)
    {
        base.InitializePlugin(pluginName);
        pluginInstance = new AndroidJavaObject(pluginName);
        if (pluginInstance==null)
        {
            Debug.Log("Plugin instance null!!");
            return;
        }
        pluginInstance.CallStatic("receiveUnityActivity", unityActivity);
    }
    void CreateAlert()
    {
        pluginInstance.Call("CreateAlert");
    }
    public void ShowAlert() 
    {
        pluginInstance.Call("ShowAlert");
    }
}
