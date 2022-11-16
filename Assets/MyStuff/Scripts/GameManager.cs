using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    void Start()
    {
        PluginAndroid.Get().MyStart();
        MyGooglePlayGames.Init();
        Debug.Log("GameManager.Start");
        DataManager.LoadData();
    }
}
