using System.Collections;
using UnityEngine;
using Zombie.Core;
using Random = UnityEngine.Random;

namespace Zombie.Enemy
{
    public class EnemySpawner : MonoBehaviour, ISpawner
    {
        [SerializeField] private Transform[] spawnLocations;
        [SerializeField] private float enemySpawnDelay;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private int multiplier;
        


        public bool IsSpawning { get; set; }

        private int currMultiplier = 1;

        private void Start()
        {
            IsSpawning = true;
            StartCoroutine(SpawnCoroutine());
            EnemyController.OnKill += UpdateSpawnRate;
        }

        
        private IEnumerator SpawnCoroutine()
        {
            while (IsSpawning)
            {
                var index = Random.Range(0, spawnLocations.Length);
                Instantiate(enemyPrefab, spawnLocations[index].position, Quaternion.identity); 
                yield return new WaitForSeconds(enemySpawnDelay);
            }
        }

        private void UpdateSpawnRate(int newCount)
        {
            var newMultiplier = (Mathf.RoundToInt(newCount / multiplier)) + 1;
            if (newMultiplier == currMultiplier) return;
            enemySpawnDelay /= newMultiplier;
            currMultiplier = newMultiplier;
        }

    }
}
