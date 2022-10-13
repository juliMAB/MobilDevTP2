using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 camdistance = new Vector3(0f, 13f, -14f);
    public Transform target;
    private float cameraSmoothSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        if (!StateController.Get().InGame())
            camdistance = new Vector3(0f, 9f, -8f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = target.position + camdistance;
        transform.position = Vector3.Lerp(transform.position, distance, cameraSmoothSpeed * Time.deltaTime);
        transform.LookAt(target.position);
    }
}
