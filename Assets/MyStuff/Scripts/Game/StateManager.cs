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

    public static bool InGame()
    {
        return currentState == STATE.GAME;
    }
}
