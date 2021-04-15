namespace Zombie.Player
{
    using UnityEngine;
    using System;
    using Zombie.Core;
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private string dividerTag;
        [SerializeField] private float playerMaxHealth;

        public event Action Death;

        public float Health { get; set; }
        public float maxHealth { get; set; }
        public bool IsDead { get; set; }

        private void Awake()
        {
            maxHealth = playerMaxHealth;
            Health = maxHealth;
            IsDead = false;
            Death += Die;
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
