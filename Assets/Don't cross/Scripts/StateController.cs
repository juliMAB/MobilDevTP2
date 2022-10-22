using System;

public enum GAME_STATES
{
    INTRO_GAME,
    IN_GAME,
    END_GAME
}


public class StateController : MonoBehaviourSingleton<StateController>
{
    public Action OnGoGame = null;

    public Action OnEndGame = null;

    private GAME_STATES currentState = GAME_STATES.INTRO_GAME;

    

    public void StartGame() { OnGoGame?.Invoke(); currentState = GAME_STATES.IN_GAME; }
    public GAME_STATES CurrentState { get => currentState; set => currentState = value; }
    public bool InGame() => currentState == GAME_STATES.IN_GAME;
    
}
