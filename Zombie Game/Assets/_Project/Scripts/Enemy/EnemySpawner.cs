using System;
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


        public bool IsSpawning { get; set; }

        private void Start()
        {
            IsSpawning = true;
            StartCoroutine(SpawnCoroutine());
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

    }
}
