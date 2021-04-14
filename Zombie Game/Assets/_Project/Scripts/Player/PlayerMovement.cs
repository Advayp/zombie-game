namespace Zombie.Player
{
    using UnityEngine;
    using Zombie.Core;
    public class PlayerMovement : MonoBehaviour, IDamageable, IEnableable
    {
        [SerializeField] private float moveSpeed, maxSpeed, playerHealth;

        private Rigidbody _rb;
        private float _mag = 0f;
        private bool _isEnabled = true;

        public float Health { get; set; }
        public bool IsDead { get; set; }

        public void TakeDamage(float amount)
        {
            Health -= amount;
            if (Health <= 0) IsDead = true;
        }


        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            Health = playerHealth;
            IsDead = false;
        }

        private void Update()
        {
            _mag = _rb.velocity.magnitude;
            if (_mag >= maxSpeed || !_isEnabled) return;

            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            _rb.AddForce(transform.forward * z * moveSpeed * Time.deltaTime);
            _rb.AddForce(transform.right * x * moveSpeed * Time.deltaTime);
        }

        public void Enable()
        {
            _isEnabled = true;
        }

        public void Disable()
        {
            _isEnabled = false;
        }

    }
}