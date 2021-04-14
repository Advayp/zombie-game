namespace Zombie.Core
{
    using System;
    public interface IDamageable
    {
        float Health { get; set; }
        void TakeDamage(float amount);
        bool IsDead { get; set; }

        event Action Death;
    }
}