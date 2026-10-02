using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float bulletSpeed = 12f;
    [SerializeField] private float bulletLifetime = 2f;
    [SerializeField] private float fireCooldown = 0.2f;


    

    private float nextFireTime;

    void Update()
    {
        //if (Keyboard.current != null &&
        //    Keyboard.current.spaceKey.wasPressedThisFrame &&
        //    Time.time >= nextFireTime)
        //{
        //    Shoot();
        //}
    }

    public void Shoot()
    {

        Rigidbody2D bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation
        );

        bullet.linearVelocity =
            (Vector2)firePoint.up * bulletSpeed;

        Destroy(bullet.gameObject, bulletLifetime);

        nextFireTime = Time.time + fireCooldown;
    }
}