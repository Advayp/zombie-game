using UnityEngine;
using Zombie.Core;

namespace Zombie.Player
{
    public class PlayerMovement : MonoBehaviour, IEnableable
    {
        [SerializeField] private float moveSpeed, maxSpeed;

        private Rigidbody rb;
        private IDamageable health;
        private float mag;
        private bool isEnabled = true;


        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            health = GetComponent<IDamageable>();
        }

        private void Update()
        {
            if (health.IsDead) return;
            mag = rb.velocity.magnitude;
            if (mag >= maxSpeed || !isEnabled) return;

            var x = Input.GetAxisRaw("Horizontal");
            var z = Input.GetAxisRaw("Vertical");

            rb.AddForce(transform.forward * (z * (moveSpeed * Time.deltaTime)));
            rb.AddForce(transform.right * (x * (moveSpeed * Time.deltaTime)));
        }

        public void Disable()
        {
            isEnabled = false;
        }
    }
}