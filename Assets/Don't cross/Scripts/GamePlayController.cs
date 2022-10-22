using System;
using UnityEngine;

public class GamePlayController : MonoBehaviourSingleton<GamePlayController>
{
    public VariableJoystick variableJoystick;
    public GameObject gameoverpanel = null;
    


    private void Start()=> StateController.Get().OnEndGame += EndGame;
    public void EndGame()
    {
        variableJoystick.gameObject.SetActive(false);
        gameoverpanel.SetActive(true);
    }
    public void Update()
    {
        if (!StateController.Get().InGame() && (new Vector3(variableJoystick.Vertical, variableJoystick.Horizontal, 0f) != Vector3.zero))
            StateController.Get().StartGame();
    }
}
