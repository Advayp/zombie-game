using System;

namespace Zombie.Core
{
    public interface IDamageable
    {
        float Health { get; set; }
        float maxHealth { get; set; }
        void TakeDamage(float amount);
        bool IsDead { get; set; }

        event Action Death;
    }
}