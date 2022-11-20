using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] GameObject[] tutoBloq;

    [SerializeField] GameObject EndPanel;

    private void Start()
    {
        Debug.Log("start GplayM");
        StateManager.currentState = STATE.INTRO;
        for (int i = 0; i < tutoBloq.Length; i++)
        {
            tutoBloq[i].SetActive(true);
        }
        GameTutorial.onEndTutorial += IntroToGame;
        GameEnd.onEndGame += GameToEnd;
    }


    public void ChangeToPause()
    {
        StateManager.TooglePause();
    }
    private void IntroToGame()
    {
        StateManager.currentState = STATE.GAME;
    }
    private void GameToEnd()
    {
        StateManager.currentState = STATE.END;
        EndPanel.gameObject.SetActive(true);
        if (Data.currentTimer>Data.maxSeconds)
            Data.maxSeconds = Data.currentTimer;
        DataManager.SaveData();
    }

    private void OnDestroy()
    {
        GameTutorial.onEndTutorial -= IntroToGame;
        GameEnd.onEndGame -= GameToEnd;
    }
}
