using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private void Start()
    {
        StateManager.currentState = STATE.GAME;
    }

    public void ChangeToPause()
    {
        StateManager.TooglePause();
    }
}
