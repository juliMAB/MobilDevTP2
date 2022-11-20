using UnityEngine;

public class TiltController : MonoBehaviour
{
    Rigidbody rb;
    float dx;
    float moveSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StateManager.currentState == STATE.INTRO || StateManager.currentState == STATE.GAME)
        {
            dx = Input.acceleration.x * moveSpeed;
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7.5f, 7.5f), transform.position.y, transform.position.z);
    }
    private void FixedUpdate()
    {
        if (StateManager.currentState == STATE.INTRO || StateManager.currentState == STATE.GAME)
        {
            rb.velocity = new Vector3(dx, rb.velocity.y,0);
        }
    }
}
