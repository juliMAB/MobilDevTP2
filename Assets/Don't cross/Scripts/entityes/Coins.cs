using UnityEngine;

public class Coins : MonoBehaviour {
	void Update ()
	{
		transform.Rotate(0, 2, 0);
	}
    void OnTriggerEnter(Collider col)
    {
        if (!StateController.Get().InGame())
            return;
        if (col.tag != "Player")
            return;
        DataController.Get().Balance++;
        Destroy(gameObject);
    }
}
