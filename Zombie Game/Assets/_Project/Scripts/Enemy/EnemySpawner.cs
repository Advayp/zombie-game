namespace Zombie.Enemy
{
    using UnityEngine;
    using Zombie.Core;
    using System.Collections;
    using Random = UnityEngine.Random;
    public class EnemySpawner : MonoBehaviour, ISpawner
    {
        [SerializeField] private Transform[] spawnLocations;
        [SerializeField] private float enemySpawnDelay;
        [SerializeField] private GameObject enemyPrefab;
        public bool IsSpawning { get; set; }

        private void Start()
        {
            IsSpawning = true;
            StartCoroutine(SpawnCoroutine(enemySpawnDelay));
        }

        public IEnumerator SpawnCoroutine(float delay)
        {
            while (IsSpawning)
            {
                int index = Random.Range(0, spawnLocations.Length);
                Instantiate(enemyPrefab, spawnLocations[index].position, Quaternion.identity);
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
