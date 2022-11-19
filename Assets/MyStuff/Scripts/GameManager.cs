using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    void Start()
    {
        PluginAndroid.Get().MyStart(); //init de mi plugin.
        MyGooglePlayGames.Init(); //init de googleplay.
        Debug.Log("GameManager.Start"); //debug.
        DataManager.LoadData(); // load game data.
    }
}
