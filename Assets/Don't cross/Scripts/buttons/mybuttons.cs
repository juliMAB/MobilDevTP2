using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mybuttons : MonoBehaviour
{
    public GameObject settings;

    public Button btReset, btShop, btSettings;

    public void GoShop () => SceneManager.LoadScene("Shop");

    public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void Settings()
    {
        settings.SetActive(true);
    }
    private void Start()
    {
        btReset.onClick.AddListener(RestartGame);
        btShop.onClick.AddListener(GoShop);
        btSettings.onClick.AddListener(Settings);
    }
}

