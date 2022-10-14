using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {


	void OnTriggerEnter(Collider col)
	{
        if (StateController.Get().InGame())
		{
			if(col.tag == "Enemy")
			{
				GamePlayController.Get().EndGame();
			}
			if(col.tag == "Coin")
			{
				DataController.Get().Balance++;
				Destroy(col.gameObject);
			} 
		}
	}
}
