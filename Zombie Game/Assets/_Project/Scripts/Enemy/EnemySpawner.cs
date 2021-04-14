namespace Zombie.Enemy
{
    using UnityEngine;
    using System.Collections;
    using Random = UnityEngine.Random;
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnLocations;
        [SerializeField] private float enemySpawnDelay;
        [SerializeField] private GameObject enemyPrefab;

        private bool isSpawning = true;

        private void Start()
        {
            StartCoroutine(SpawnCoroutine(enemySpawnDelay));
        }

        private IEnumerator SpawnCoroutine(float delay)
        {
            while (isSpawning)
            {
                int index = Random.Range(0, spawnLocations.Length);
                Instantiate(enemyPrefab, spawnLocations[index].position, Quaternion.identity);
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
