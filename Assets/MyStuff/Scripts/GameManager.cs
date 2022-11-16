using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    void Start()
    {
        MyGooglePlayGames.Init();
        Debug.Log("GameManager.Start");
        DataManager.LoadData();
    }
}
