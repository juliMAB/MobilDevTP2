using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private void Start()
    {
        DataManager.UpdateTimer(0);
    }

    void Update()
    {
        if (!StateManager.InGame())
            return;
        DataManager.UpdateTimer(Data.currentTimer + Time.deltaTime);
    }
}
