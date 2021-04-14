namespace Zombie.Core
{
    public interface IDamageable
    {
        float Health { get; set; }
        void TakeDamage(float amount);

        void Die();
    }
}