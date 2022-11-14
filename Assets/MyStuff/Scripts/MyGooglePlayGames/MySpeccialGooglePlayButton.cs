using UnityEngine;
using UnityEngine.UI;

public class MySpeccialGooglePlayButton : MonoBehaviour
{
    public Button specialButton;
    public Button ShwButton;
    private static string achievement2ID = GPGSIds.achievement_press_special_button;

    void Start()
    {
        specialButton.onClick.AddListener(() => { MyGooglePlayGames.UnlockAchievement(achievement2ID); });
        ShwButton.onClick.AddListener(() => { MyGooglePlayGames.ShowAchievements(); });
    }
}
