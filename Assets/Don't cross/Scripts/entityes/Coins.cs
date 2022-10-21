using UnityEngine;

public class Coins : MonoBehaviour {
	void Update ()
	{
		transform.Rotate(0, 2, 0);
	}
    void OnTriggerEnter(Collider col)
    {
        if (StateController.Get().InGame())
        {
            if (col.tag == "Player")
            {
                DataController.Get().Balance++;
                Destroy(gameObject);
            }
        }
    }
}
