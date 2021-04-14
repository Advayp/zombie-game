namespace Zombie.Guns
{
    using UnityEngine;
    public class Gun : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform mainCamera, gunTip;

        private void Update()
        {
            if (Input.GetButtonDown("Fire1") || Input.GetKey(KeyCode.E))
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            Instantiate(bullet, gunTip.position, mainCamera.localRotation);
        }
    }
}
