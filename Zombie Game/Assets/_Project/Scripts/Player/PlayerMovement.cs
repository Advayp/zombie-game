namespace Zombie.Player
{
    using UnityEngine;
    using Zombie.Core;
    public class PlayerMovement : MonoBehaviour, IDamageable
    {
        [SerializeField] private float moveSpeed, maxSpeed, playerHealth;

        private Rigidbody rb;
        private float mag;

        public float Health { get; set; }

        public void TakeDamage(float amount)
        {
            Health -= amount;
            if (Health <= 0) Die();
        }

        public void Die()
        {
            gameObject.SetActive(false);
        }

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            Health = playerHealth;
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
}