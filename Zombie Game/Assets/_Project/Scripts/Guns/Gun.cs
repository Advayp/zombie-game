using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private float destroyDelay;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit))
        {
            var impactGO = Instantiate(impactEffect, hit.point, Quaternion.identity);
            Destroy(impactGO, destroyDelay);
        }
    }
}
