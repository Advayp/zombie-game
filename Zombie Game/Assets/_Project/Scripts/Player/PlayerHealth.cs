namespace Zombie.Player
{
    using UnityEngine;
    using System;
    using Zombie.Core;
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private float playerHealth;

        public event Action Death;

        public float Health { get; set; }
        public bool IsDead { get; set; }

        private void Start()
        {
            Health = playerHealth;
            IsDead = false;
        }

        private void Die()
        {
            IsDead = true;
            Death -= Die;
        }
        public void TakeDamage(float amount)
        {
            Health -= amount;
            if (Health <= 0) Death?.Invoke();
        }
    }

}
