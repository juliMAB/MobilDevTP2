public enum GAME_STATES
{
    OUT_GAME,
    IN_GAME
}

public class StateController : MonoBehaviourSingleton<StateController>
{
    private GAME_STATES currentState = GAME_STATES.OUT_GAME;

    public GAME_STATES CurrentState { get => currentState; set => currentState = value; }

    public bool InGame()
    {
        return currentState == GAME_STATES.IN_GAME;
    }
}
