using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    [SerializeField]
    private float smoothInputSpeed = .2f;

    private Vector3 currentInputVector;

    private Vector3 smoothInputVelocity;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 accelerometroInput = Input.acceleration;
        currentInputVector = Vector3.SmoothDamp(currentInputVector, accelerometroInput, ref smoothInputVelocity, smoothInputSpeed);
        float result = currentInputVector.x;
        result =  (int)(result * 100f);
        result = result / 100f;
        Vector3 move = new Vector3(-result, 0, 0);
        //rb.angular = Quaternion.Euler(move*90);
    }
    
}
