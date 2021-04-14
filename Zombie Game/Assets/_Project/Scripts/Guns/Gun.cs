namespace Zombie.Guns
{
    using UnityEngine;
    using Zombie.Core;
    public class Gun : MonoBehaviour, IEnableable
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform mainCamera, gunTip;

        private bool _isEnabled = true;

        private void Update()
        {
            if (!_isEnabled) return;
            if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.E))
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            Instantiate(bullet, gunTip.position, mainCamera.localRotation);
        }

        public void Enable()
        {
            _isEnabled = true;
        }

        public void Disable()
        {
            _isEnabled = false;
        }
    }
}
