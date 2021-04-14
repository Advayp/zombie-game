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

        private IDamageable _damageable;
        private NavMeshAgent _agent;

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
            print(other.gameObject.tag);
            if (other.gameObject.CompareTag(bulletTag))
            {
                Destroy(gameObject);
            }
            else if (other.gameObject.name == target.gameObject.name)
            {
                _damageable.TakeDamage(damage);
            }

        }
    }
}