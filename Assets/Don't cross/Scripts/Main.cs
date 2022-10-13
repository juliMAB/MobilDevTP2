using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

	public Canvas settings, shop;
	public Image gamename;
	public Text score, yourscore, bestscore, balancetext;
	public GameObject buttons, /*enemy*/ joystick, gameoverpanel, balance /*coin*/;
	//public bool /*isGameStarted,*/ isCoinInstance;
	private RectTransform rect;
	//private int scoreint;
	//private static int currentlevel;
	public LayerMask enemyLayer;
    void Start()
	{
		rect = buttons.GetComponent<RectTransform>();
		StateController.Get().CurrentState = GAME_STATES.OUT_GAME; // llamar en el gm.

		//scoreint = 0;
        StateController.Get().CurrentLevel = 1;
		
	}

	void Update()
	{
		if(StateController.Get().InGame())
		{
			if(gamename.rectTransform.offsetMax.y < 200 && gamename.rectTransform.offsetMin.y > -200)
			{
				gamename.rectTransform.offsetMin = new Vector2(gamename.rectTransform.offsetMin.x, gamename.rectTransform.offsetMin.y + 200f * Time.deltaTime);
				gamename.rectTransform.offsetMax = new Vector2(gamename.rectTransform.offsetMax.x, gamename.rectTransform.offsetMax.y + 200f * Time.deltaTime);
				rect.offsetMin = new Vector2(rect.offsetMin.x, rect.offsetMin.y - 300f * Time.deltaTime);
				rect.offsetMax = new Vector2(rect.offsetMax.x, rect.offsetMax.y - 300f * Time.deltaTime);
			}
			balancetext.text = PlayerPrefs.GetInt("balance") + "";
		}
	}
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
