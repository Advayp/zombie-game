using UnityEngine;
using UnityEngine.AI;
using Zombie.Core;
using System;
using Zombie.Core;

namespace Zombie.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private string bulletTag;
        [SerializeField] private float damage;
        
        [SerializeField] private int ammoToGive;
        
        private GameObject ammoTracker;
        private IAmmoCounter ammoCounter;
        

        private IDamageable damageable;
        private NavMeshAgent agent;

        public static int KillCount;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            if (target == null)
                target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            damageable = target.gameObject.GetComponent<IDamageable>();
            ammoTracker = GameObject.FindGameObjectWithTag("Ammo");
            ammoCounter = ammoTracker.GetComponent<IAmmoCounter>();
        }
        

        private void Update()
        {
            if (damageable.IsDead) return;
            agent.SetDestination(target.position);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(bulletTag))
            {
                KillCount++;
                ammoCounter.AmmoCount += ammoToGive;
                ammoCounter.UpdateText();
                Destroy(gameObject);
            }
            else if (other.gameObject.name == target.gameObject.name)
            {
                damageable.TakeDamage(damage);
            }
        }
    }
}