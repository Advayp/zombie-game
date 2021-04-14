using UnityEngine;

namespace Zombie.Guns
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed, maxDistance = 20;
        [SerializeField] private Transform player;

        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            // Stops the original bullet prefab from destroying
            if (gameObject.name == "Bullet") return;

            rb.AddForce(transform.forward * bulletSpeed * Time.deltaTime);
            if ((transform.position - player.position).sqrMagnitude >= maxDistance * maxDistance)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            Destroy(gameObject);
        }
    }

}
