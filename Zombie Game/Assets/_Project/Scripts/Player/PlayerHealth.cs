using System;
using UnityEngine;
using Zombie.Core;

namespace Zombie.Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private float playerMaxHealth;

        public event Action Death;

        public float Health { get; private set; }
        public float maxHealth { get; private set; }
        public bool IsDead { get; private set; }

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
