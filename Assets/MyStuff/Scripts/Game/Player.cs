using System.Collections;
using System.Collections.Generic;
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
