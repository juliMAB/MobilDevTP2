using UnityEngine.SceneManagement;
using UnityEngine;

public static class SceneController
{
    public static void goToGame() { Debug.Log("Cambiar a escena game"); SceneManager.LoadScene("Game"); }

    public static void goToMenu() { Debug.Log("Cambiar a escena Menu"); SceneManager.LoadScene("Menu"); }
}
