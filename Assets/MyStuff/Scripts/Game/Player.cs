using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        if (ShopData.material)
        {
            GetComponent<Renderer>().material.color = ShopData.material.color;
        }
    }
}
