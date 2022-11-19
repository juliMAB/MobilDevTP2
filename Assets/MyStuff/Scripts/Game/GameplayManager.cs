using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private void Start()
    {
        StateManager.currentState = STATE.GAME;
    }

    public void ChangeToPause()
    {
        if (StateManager.currentState == STATE.GAME)
            StateManager.currentState = STATE.PAUSE;
        else if (StateManager.currentState == STATE.PAUSE)
            StateManager.currentState = STATE.GAME;
    }
}
