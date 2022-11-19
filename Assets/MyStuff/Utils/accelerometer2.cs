using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accelerometer2 : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] private float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tilt = Input.acceleration;

        tilt = Quaternion.Euler(90, 0, 0) * tilt;

        rb.AddForce(tilt*speed);
    }
}
