using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float speed;
    void Update()=> transform.Rotate(0, Time.deltaTime* speed, 0);
    
}
