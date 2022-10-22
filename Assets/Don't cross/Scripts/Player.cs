using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {


	void OnTriggerEnter(Collider col)
	{
		if (!StateController.Get().InGame())
			return;
        if (col.tag != "Enemy")
            return;
        GamePlayController.Get().EndGame();
    }
}
