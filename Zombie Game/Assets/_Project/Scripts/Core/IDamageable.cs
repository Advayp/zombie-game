using System;

namespace Zombie.Core
{
    public interface IDamageable
    {
        float Health { get; }
        float maxHealth { get; }
        void TakeDamage(float amount);
        bool IsDead { get; }

        event Action Death;
    }
}