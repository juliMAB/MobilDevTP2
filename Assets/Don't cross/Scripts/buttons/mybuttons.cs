using UnityEngine;
using UnityEngine.SceneManagement;

public class mybuttons : MonoBehaviour
{
    public GameObject settings;

    public void Shop () => SceneManager.LoadScene("Shop");

    public void RestartGame() => SceneManager.LoadScene("Main");

    public void Settings()
    {
        settings.SetActive(true);
    }
}
