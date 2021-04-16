namespace Zombie.Core
{
    public interface IAmmoCounter
    {
        int AmmoCount { get; set; }

        void UpdateText();
    }
}