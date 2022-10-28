using UnityEngine;

public class AndroidBaseClass
{
    protected AndroidJavaClass androidClass;
    protected AndroidJavaObject unityActivity;
    virtual protected void InitializePlugin(string pluginName)
    {
        androidClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        unityActivity = androidClass.GetStatic<AndroidJavaObject>("currentActivity");
    }
}
