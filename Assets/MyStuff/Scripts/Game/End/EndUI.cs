using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndUI : MonoBehaviour
{
    [SerializeField] Button ResetButton;
    [SerializeField] Button MenuButton;

    private void Start()
    {
        ResetButton.onClick.AddListener(()=>SceneManager.LoadScene(1));
        MenuButton.onClick.AddListener(()=>SceneManager.LoadScene(0));
    }
}
