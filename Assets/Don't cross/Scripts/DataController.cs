
using UnityEngine;

public class DataController : MonoBehaviourSingleton<DataController>
{
    private int currentLevel = 0;

    private int currentScore = 0;

    private int balance = 0;


    private int maxScore = 0;

    public int CurrentLevel { get => currentLevel; set => currentLevel = value; }
    public int CurrentScore
    {
        get => currentScore;
        set
        {
            currentScore = value;
            UpdateLevel();
            CanvasAnim.Get().UpdateScore();
        }
    }
    private void UpdateLevel()
    {
        if (CurrentScore < 7) return;
        if (CurrentScore > 18)
        {
            currentLevel = 3;
            return;
        }
        if (CurrentScore > 7)
        {
            currentLevel = 2;
            return;
        }
    }

    public int Balance { get  => balance; set { balance = value; CanvasAnim.Get().UpdateBalance(); } }
    public int MaxScore { get => maxScore; set => maxScore = value; }

    private void Start()
    {
        CurrentLevel = 1;
        maxScore = PlayerPrefs.GetInt("bestscore");
        balance = PlayerPrefs.GetInt("balance");
        StateController.Get().OnEndGame += Savebalance;
        StateController.Get().OnEndGame += SaveMaxScore;
    }
    public void Savebalance()
    {
        PlayerPrefs.SetInt("balance", balance);
    }
    public void SaveMaxScore()
    {
        if (currentScore> maxScore)
        {
            PlayerPrefs.SetInt("bestscore", currentScore);
        }
    }
}
