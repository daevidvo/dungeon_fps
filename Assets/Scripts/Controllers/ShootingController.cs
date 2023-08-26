using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunBarrel;
    public float bulletSpeed = 30f;
    public Transform crosshairTransform;
    public LayerMask targetLayer; // Layer containing objects that can be hit by bullets


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleShooting();
    }

    public ShootingController(GameObject prefab, Transform barrel, float speed, Transform crosshair)
    {
        bulletPrefab = prefab;
        gunBarrel = barrel;
        bulletSpeed = speed;
        crosshairTransform = crosshair;
    }

    public void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        if (bulletRigidbody != null)
        {
            Vector3 shootDirection = (crosshairTransform.position - gunBarrel.position).normalized;
            bulletRigidbody.velocity = shootDirection * bulletSpeed;
        }
    }
}