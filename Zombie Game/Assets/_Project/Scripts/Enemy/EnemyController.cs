namespace Zombie.Enemy
{
    using UnityEngine;
    using UnityEngine.AI;
    using Zombie.Core;
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private string bulletTag;
        [SerializeField] private float damage;

        private IDamageable _damageable;
        private NavMeshAgent _agent;

        public static int killCount = 0;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            if (target == null)
                target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            _damageable = target.gameObject.GetComponent<IDamageable>();
        }

        private void Update()
        {
            if (_damageable.IsDead) return;
            _agent.SetDestination(target.position);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(bulletTag))
            {
                killCount++;
                Destroy(gameObject);
            }
            else if (other.gameObject.name == target.gameObject.name)
            {
                _damageable.TakeDamage(damage);
            }

        }
    }
}