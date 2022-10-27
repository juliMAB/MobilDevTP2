using UnityEngine;

public class AndroidBaseClass
{
    protected AndroidJavaClass unityClass;
    protected AndroidJavaObject unityActivity;
    virtual protected void InitializePlugin(string pluginName)
    {
        unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        unityActivity = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
    }
}
