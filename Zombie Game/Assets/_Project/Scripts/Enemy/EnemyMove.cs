namespace Zombie.Enemy
{
    using UnityEngine;
    using UnityEngine.AI;
    using Zombie.Core;
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private string bulletTag, damageableName;
        [SerializeField] private float damage;

        private IDamageable damageable;
        private NavMeshAgent agent;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            damageable = target.gameObject.GetComponent<IDamageable>();
        }


        private void Update()
        {
            agent.SetDestination(target.position);
        }

        private void OnTriggerEnter(Collider other)
        {
            print(other.gameObject.tag);
            if (other.gameObject.CompareTag(bulletTag))
            {
                Destroy(gameObject);
            }
            else if (other.gameObject.name == target.gameObject.name)
            {
                damageable.TakeDamage(damage);
            }

        }
    }
}