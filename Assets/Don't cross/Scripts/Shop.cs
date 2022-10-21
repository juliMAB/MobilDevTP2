using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour {

	public Text balance;

	[Header("Characters amount")]
	[Range(1, 20)]
	public int amount;

	[Header("Distance between panels")]
	[Range(250, 400)]
	public int distance;

	[Header("Smoothness of movement (3-recommended)")]
	[Range(1, 5)]
	public float smoothness;

	private GameObject[] characters;
	public GameObject charactersPan, center;

	[Header("Select amount, drag here panels prefabs")]
	public GameObject[] charactersPanels;
	private Vector3 spawnPos = new Vector3(270f, 0, 0);
	private Vector3 newvector;
	private Vector3[] pointsReturn;
	private float lenght, distContrl;
	void Start () 
	{
		pointsReturn = new Vector3[amount];
		InvokeRepeating("Ev3sec", 0, 3);
		for(int i = 0; i < charactersPanels.Length; i++)
		{
			if(i == 0) charactersPanels[i].transform.position = new Vector3(0, charactersPanels[i].transform.position.y, charactersPanels[i].transform.position.z);
    		else charactersPanels[i].transform.localPosition = new Vector2(charactersPanels[i-1].transform.localPosition.x + distance, center.transform.localPosition.y);
		}
		distContrl = charactersPanels[1].transform.position.x - charactersPanels[0].transform.position.x;
		for(int i = 0; i < charactersPanels.Length; i++)
		{
			if(i == 0) pointsReturn[i].x = charactersPan.transform.position.x - (distContrl / 2);
			else pointsReturn[i].x = pointsReturn[i-1].x - distContrl;
		}
		
	}

	void Ev3sec()
	{	
		balance.text = PlayerPrefs.GetInt("balance") + "";
	}
	void FixedUpdate ()
	{
		for(int i = 0; i < charactersPanels.Length; i++)
		{
			if(i == 0) if(charactersPan.transform.position.x > pointsReturn[i].x) newvector.x = Mathf.SmoothStep(charactersPan.transform.position.x, pointsReturn[i].x + (distContrl / 2), smoothness * Time.deltaTime);
			if(i != 0)
			{
				if(charactersPan.transform.position.x > pointsReturn[i].x && charactersPan.transform.position.x < pointsReturn[i-1].x) newvector.x =
					Mathf.SmoothStep(charactersPan.transform.position.x, pointsReturn[i].x + (distContrl / 2), smoothness * Time.deltaTime);
				
			} 	
			
		}
		if(lenght < 0.8)
		{
			//newvector.x = Mathf.SmoothStep(charactersPanels[i].transform.position.x, center.transform.position.x, 5 * Time.deltaTime);
			//charactersPanels[i].transform.position = new Vector3(newvector.x, charactersPanels[i].transform.position.y, charactersPanels[i].transform.position.z);
		}
		if(Input.GetKeyDown(KeyCode.W))
		{
			Debug.Log(charactersPan.transform.position.x);
			Debug.Log(pointsReturn[0].x);
			Debug.Log("hi");
		}
		//newvector.x = Mathf.SmoothStep(charactersPanels[i].transform.position.x, center.transform.position.x, 5 * Time.deltaTime);
		charactersPan.transform.position = new Vector3(newvector.x, charactersPan.transform.position.y, charactersPan.transform.position.z);
	}

	public void Close()
	{
		Debug.Log("load");
		SceneManager.LoadScene("Main");
	}
}
