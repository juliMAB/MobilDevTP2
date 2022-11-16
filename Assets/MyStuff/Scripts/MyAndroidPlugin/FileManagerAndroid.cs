using UnityEngine;

public class FileManagerAndroid : AndroidBaseClass
{
    const string PACK_NAME = "com.pomelovolador.native_plugin";

    const string FILEMANAGER_CLASS_NAME = "FileManagerClass";

    static AndroidJavaClass FileManagerClass = null;

    static AndroidJavaObject FileManagerInstance = null;

    public FileManagerAndroid()
    {
        InitializePlugin();
    }

    override protected void InitializePlugin()
    {
        base.InitializePlugin();
        FileManagerClass = new AndroidJavaClass(PACK_NAME + "." + FILEMANAGER_CLASS_NAME);
        FileManagerInstance = FileManagerClass.CallStatic<AndroidJavaObject>("GetInstance");
        FileManagerInstance.CallStatic("receiveUnityActivity", unityActivity);
    }

    public void WriteFile(string msg)
    {
        FileManagerInstance.CallStatic("WriteFile", msg);
    }
    public string ReadFile()
    {
        return FileManagerInstance.CallStatic<string>("ReadFile", " ");
    }
    public void ClearFile()
    {
        FileManagerInstance.CallStatic("ClearFile", " ");
    }
}
