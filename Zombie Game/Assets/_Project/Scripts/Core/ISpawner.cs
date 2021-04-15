namespace Zombie.Core
{
    using System.Collections;
    public interface ISpawner
    {
        bool IsSpawning { get; set; }

        IEnumerator SpawnCoroutine(float delay);
    }
}