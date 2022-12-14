using UnityEngine;
public enum STATE
{
    INVALID = -1,
    INTRO,
    TUTORIAL,
    GAME,
    PAUSE,
    END,
    MAX
}

public class StateManager
{
    public static STATE currentState = STATE.INVALID;
    public static STATE lastState = STATE.INVALID;

    public static bool InGame()
    {
        return currentState == STATE.GAME;
    }
    public static bool TooglePause()
    {
        if (currentState!=STATE.PAUSE)
        {
            lastState = currentState;
            currentState = STATE.PAUSE;
            return true;
        }
        else if (currentState==STATE.PAUSE)
        {
            currentState = lastState;
            lastState = STATE.PAUSE;
            return false;
        }
        return false;
    }

}
