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

        [HideInInspector]
        public bool IsSpawning = true;

        private void Start()
        {
            StartCoroutine(SpawnCoroutine(enemySpawnDelay));
        }

        private IEnumerator SpawnCoroutine(float delay)
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
