namespace Zombie.Core
{
    public interface IDamageable
    {
        float Health { get; set; }
        void TakeDamage(float amount);
        bool IsDead { get; set; }
    }
}