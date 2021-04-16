using Zombie.Core;
using UnityEngine;

namespace Zombie.Guns
{
    public class Gun : MonoBehaviour, IEnableable
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform mainCamera, gunTip;
        [SerializeField] private GameObject ammoTracker;

        private IAmmoCounter ammoCounter;
        

        private bool isEnabled = true;

        private void Awake()
        {
            ammoCounter = ammoTracker.GetComponent<IAmmoCounter>();
        }

        private void Update()
        {
            if (!isEnabled) return;
            if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.E))
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            if (ammoCounter.AmmoCount <= 0) return;
            ammoCounter.AmmoCount -= 1;
            Instantiate(bullet, gunTip.position, mainCamera.localRotation);
        }
        

        public void Disable()
        {
            isEnabled = false;
        }
    }
}
