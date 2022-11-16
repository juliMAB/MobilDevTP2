using UnityEngine;

public class Player : MonoBehaviour {

    private void Start()
    {
        if (ShopData.material)
            GetComponent<Renderer>().material.color = ShopData.material.color;
    }


    void OnTriggerEnter(Collider col)
	{
		if (!StateController.Get().InGame())
			return;
        if (col.tag != "Enemy")
            return;
        StateController.Get().OnEndGame?.Invoke();
    }
}
