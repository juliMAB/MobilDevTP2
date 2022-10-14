using System;
using UnityEngine;

public class GamePlayController : MonoBehaviourSingleton<GamePlayController>
{
    public GameObject joystick = null;
    public GameObject gameoverpanel = null;
    public Action OnEndGame;


    private void Start()=> OnEndGame += EndGame;
    public void EndGame()
    {
        joystick.SetActive(false);
        gameoverpanel.SetActive(true);
    }
}
