using System;
using UnityEngine;

public class MoveSideToSide : MonoBehaviour
{
    public float dir = -1;
    public float speed = 100;
    void Update()
    {
        transform.Rotate(0, 0, dir * Time.deltaTime * speed);
        if (transform.rotation.z < 0 && transform.rotation.z < -0.3f)
            dir = 1;
        if (transform.rotation.z > 0 && transform.rotation.z > 0.3f)
            dir = -1;
        
    }
}
