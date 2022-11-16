using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    void Start()
    {
        Debug.Log("GameManager.Start");
        DataManager.LoadData();
    }
}
