using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

	public Canvas settings, shop;
	public Image gamename;
	public Text score, yourscore, bestscore, balancetext;
	public GameObject buttons, enemy, joystick, gameoverpanel, balance, coin;
	public bool /*isGameStarted,*/ isCoinInstance;
	private RectTransform rect;
	private int scoreint;
	private static int currentlevel;
	public LayerMask enemyLayer;
    void Start()
	{
		rect = buttons.GetComponent<RectTransform>();
		StateController.Get().CurrentState = GAME_STATES.OUT_GAME; // llamar en el gm.
		System.Action lvlRef = this.Level1;

		InvokeRepeating(lvlRef.Method.Name, 0, 3f);
        lvlRef = this.Level2;
        InvokeRepeating(lvlRef.Method.Name, 0, 2f);
        lvlRef = this.Level3;
        InvokeRepeating(lvlRef.Method.Name, 0, 1.25f);
        lvlRef = this.Coins;
        InvokeRepeating(lvlRef.Method.Name, 0, 9f);
		scoreint = 0;
		currentlevel = 1;
		isCoinInstance = false;
	}
	void Level1() // INCLUDES SCORE CONTROLLER
	{
		if(StateController.Get().InGame() && currentlevel == 1) EnemySpawn();
		if(StateController.Get().InGame())
		{
			score.text = (scoreint++) + "";
			if(scoreint > PlayerPrefs.GetInt("bestscore")) PlayerPrefs.SetInt("bestscore", scoreint - 1);
		}
	}
	void Level2()
	{
		if(StateController.Get().InGame() && currentlevel == 2) EnemySpawn();
	}
	void Level3()
	{
		if(StateController.Get().InGame() && currentlevel == 3) EnemySpawn();
	}
	void Coins()
	{
		if(StateController.Get().InGame())
		{
			if(isCoinInstance == false)
			{
				Instantiate(coin, new Vector3(Random.Range(-3.8f, 3.8f), 11.15f, Random.Range(-5f, 5f)), Quaternion.identity);
				isCoinInstance = true;
			}
		} 
	}
	void EnemySpawn()
	{
		Instantiate(enemy, new Vector3(Random.Range(-6f, 6f), 11, 27), Quaternion.identity);
		Instantiate(enemy, new Vector3(27, 11, Random.Range(-6f, 6f)), Quaternion.identity);
		Instantiate(enemy, new Vector3(Random.Range(-6f, 6f), 11, -27), Quaternion.identity);
		Instantiate(enemy, new Vector3(-27, 11, Random.Range(-6f, 6f)), Quaternion.identity);
	}
	void Update()
	{
		if(StateController.Get().InGame())
		{
			if(scoreint > 7) currentlevel = 2;
			if(scoreint > 18) currentlevel = 3;
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
				yourscore.text = "your score: " + (scoreint - 1);
				bestscore.text = "your best: " + PlayerPrefs.GetInt("bestscore");
			}
			if(col.tag == "Coin")
			{
				PlayerPrefs.SetInt("balance", PlayerPrefs.GetInt("balance") + 1);
				Destroy(col.gameObject);
				isCoinInstance = false;
			} 
		}
	}
	public void RestartGame()
	{
		SceneManager.LoadScene("Main");
	}
}
