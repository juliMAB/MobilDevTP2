using UnityEngine;

public class AlertDialogManager : AndroidBaseClass
{
    AndroidJavaObject pluginInstance;
    public AlertDialogManager()
    {
        InitializePlugin();
        CreateAlert();
    }
    override protected void InitializePlugin()
    {
        base.InitializePlugin();
        pluginInstance = new AndroidJavaObject("com.pomelovolador.native_plugin.AlertClass");
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
