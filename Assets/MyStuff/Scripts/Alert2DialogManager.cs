using UnityEngine;

public class Alert2DialogManager
{
    const string pluginName = "com.pomelovolador.native_plugin.Alert2Class";
    class AlertViewCallback : AndroidJavaProxy
    {

        private System.Action<int> alertHandler;
        public AlertViewCallback(System.Action<int> alertHandlerIn) : base(pluginName + "$AlertViewCallback")
        {
            alertHandler = alertHandlerIn;
        }
        public void onButtonTapped(int index)
        {
            Debug.Log("Button tapped: " + index);
            if (alertHandler != null)
                alertHandler(index);
        }
    }


        static AndroidJavaClass _pluginClass;
        static AndroidJavaObject _pluginInstance;
    public static AndroidJavaClass PluginClass
    {
        get
        {
            if (_pluginClass == null)
            {
                _pluginClass = new AndroidJavaClass(pluginName);
                AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
                _pluginClass.SetStatic<AndroidJavaObject>("mainActivity", activity);
            }
            return _pluginClass;
        }
    }
    public static AndroidJavaObject PluginInstance
    {
        get
        {
            if (_pluginInstance == null)
            {
                _pluginInstance = PluginClass.CallStatic<AndroidJavaObject>("getInstance");
            }
            return _pluginInstance;
        }
    }
    public void showAlertDialog(string[] strings, System.Action<int> handler = null)
    {
        if (strings.Length < 3)
        {
            Debug.LogError("AlertView requires at least 3 strings");
            return;
        }

        if (Application.platform == RuntimePlatform.Android)
            PluginInstance.Call("showAlertView", new object[] { strings, new AlertViewCallback(handler) });
        else
            Debug.LogWarning("AlertView not supported on this platform");
    }

}
