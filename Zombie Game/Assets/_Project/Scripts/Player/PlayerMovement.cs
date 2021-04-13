using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed, maxSpeed;

    private Rigidbody rb;
    private float mag;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        mag = rb.velocity.magnitude;

        if (mag >= maxSpeed) return;

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * moveSpeed * Time.deltaTime);
        }
    }
}
