using UnityEngine;

public class EliteEnemyShooting : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private Transform[] firePoints;

    [SerializeField] private float bulletSpeed = 12f;
    [SerializeField] private float bulletLifetime = 2f;
    [SerializeField] private float fireCooldown = 0.75f;

    private float nextFireTime;

    public void Shoot()
    {
        if (Time.time < nextFireTime)
        {
            return;
        }

        foreach (Transform firePoint in firePoints)
        {
            Rigidbody2D bullet = Instantiate(
                bulletPrefab,
                firePoint.position,
                firePoint.rotation
            );

            bullet.linearVelocity =
                (Vector2)firePoint.up * bulletSpeed;

            Destroy(bullet.gameObject, bulletLifetime);
        }

        nextFireTime = Time.time + fireCooldown;
    }
}