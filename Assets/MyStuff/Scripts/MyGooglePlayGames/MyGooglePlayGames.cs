using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class MyGooglePlayGames : MonoBehaviour
{

    private static string achievement1ID = GPGSIds.achievement_hello_world;
    

    void Start()
    {
        Init();
    }
    private void Init()
    {
        PlayGamesPlatform.Instance.Authenticate((callback) => { });
        UnlockAchievement(achievement1ID);
    }

    static public void AddScoreToLeaderboard(int score)
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportScore(score, "...", success => { Debug.Log("Se subio al leaderboard"); });
        }
    }

    static public void ShowLeaderboard()
    {
        if (Social.Active.localUser.authenticated)
        {
            //platform.ShowLeaderboardUI();
        }
    }

    static public void ShowAchievements()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            PlayGamesPlatform.Instance.ShowAchievementsUI();
        }
    }

    static public void UnlockAchievement(string a)
    {
        
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            Debug.Log("LLamdo a desbloquear logro");
            PlayGamesPlatform.Instance.ReportProgress(a, 100f, success => { });
        }
    }
}
