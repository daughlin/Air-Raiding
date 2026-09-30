using UnityEngine;
using UnityEngine.InputSystem;

public class BasicEnemyShooting : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float bulletSpeed = 12f;
    [SerializeField] private float bulletLifetime = 2f;
    [SerializeField] private float fireCooldown = 0.75f;

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
        if (Time.time >= nextFireTime)
        {

            Rigidbody2D bullet = Instantiate(
                bulletPrefab,
                firePoint.position,
                firePoint.rotation
            );

            bullet.linearVelocity =
                (Vector2)firePoint.up * bulletSpeed * -1;

            Destroy(bullet.gameObject, bulletLifetime);

            nextFireTime = Time.time + fireCooldown;
        }
    }
}