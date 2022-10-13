using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

	public Canvas settings, shop;
	public Text score, yourscore, bestscore;
	public GameObject joystick, gameoverpanel, balance;

	public void Settings()
	{
		settings.gameObject.SetActive(true);
	}

	public void Shop()
	{
		SceneManager.LoadScene("Shop");
	}
	void OnTriggerEnter(Collider col)
	{
        if (StateController.Get().InGame())
		{
			if(col.tag == "Enemy")
			{
				joystick.gameObject.SetActive(false);
                StateController.Get().CurrentState = GAME_STATES.OUT_GAME;
				gameoverpanel.gameObject.SetActive(true);
				yourscore.text = "your score: " + (StateController.Get().CurrentScore - 1);
				bestscore.text = "your best: " + PlayerPrefs.GetInt("bestscore");
			}
			if(col.tag == "Coin")
			{
				PlayerPrefs.SetInt("balance", PlayerPrefs.GetInt("balance") + 1);
				Destroy(col.gameObject);
			} 
		}
	}
	public void RestartGame()
	{
		SceneManager.LoadScene("Main");
	}
}
