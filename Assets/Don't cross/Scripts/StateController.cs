public enum GAME_STATES
{
    OUT_GAME,
    IN_GAME
}


public class StateController : MonoBehaviourSingleton<StateController>
{
    private GAME_STATES currentState = GAME_STATES.OUT_GAME;

    private int currentLevel = 0;

    private int currentScore = 0;

    public GAME_STATES CurrentState { get => currentState; set => currentState = value; }
    public int CurrentLevel { get => currentLevel; set => currentLevel = value; }
    public int CurrentScore { 
        get => currentScore;
        set 
        {
            currentScore = value;
            if (currentLevel < 7) return;
            if (currentLevel > 18) {
                currentLevel = 3; 
                return; 
            }
            if (currentLevel > 7)
            {
                currentLevel = 2;
                return;
            }
        } 
    }

    public bool InGame()
    {
        return currentState == GAME_STATES.IN_GAME;
    }
}
