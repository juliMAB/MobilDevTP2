using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PluginTest : MonoBehaviour
{
    const string pluginName = "com.pomelovolador.unity.MyPlugin";

    static AndroidJavaClass _pluginClass;
    static AndroidJavaObject _pluginInstance;

    public static AndroidJavaClass PluginClass
    {
        get {
            if (_pluginClass==null)
            {
                _pluginClass = new AndroidJavaClass(pluginName);
            }
            return _pluginClass;
        }
    }
    public static AndroidJavaObject PluginInstance
    {
        get
        {
            if (_pluginInstance==null)
            {
                _pluginInstance = PluginClass.CallStatic<AndroidJavaObject>("getInstance");
            }
            return _pluginInstance;
        }
    }
    float elapsedTime = 0;
    public double ElapsedTime { 
        get 
        {
            if (Application.platform == RuntimePlatform.Android) 
                return PluginInstance.Call<double>("getElapsedTime");
            Debug.LogWarning("Wrong platform");
            return 0;
        } 
    }

    private void Start()
    {
        Debug.Log("Elapsed Time: " + ElapsedTime);
    }
    
    private void Update()
    {
        elapsedTime += Time.deltaTime;
        Debug.Log("Tick: " + ElapsedTime);
    }

}

