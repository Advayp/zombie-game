using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform mainCamera, gunTip;


    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var shotBullet = Instantiate(bullet, gunTip.position, mainCamera.localRotation);
    }
}
