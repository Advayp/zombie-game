using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed, maxSpeed;

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

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        rb.AddForce(transform.forward * z * moveSpeed * Time.deltaTime);
        rb.AddForce(transform.right * x * moveSpeed * Time.deltaTime);
    }
}
