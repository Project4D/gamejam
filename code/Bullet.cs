using UnityEngine;

public class Bullet: MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint, firePoint1;
    public float bulletSpeed = 20f;
    public float fireRate = 0.5f;

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject bullet1 = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        bullet.transform.Rotate(0, 0, 310);
        bullet1.transform.Rotate(0, 0, 310);
        bullet.AddComponent<ManualBullet>().Initialize(bulletSpeed, 5);
        bullet1.AddComponent<ManualBullet>().Initialize(bulletSpeed, 5);
    }
    private class ManualBullet : MonoBehaviour
    {
        private float speed;
        private float lifetime;

        public void Initialize(float bulletSpeed, float bulletLifetime)
        {
            speed = bulletSpeed;
            lifetime = bulletLifetime;

            Destroy(gameObject, lifetime);
        }

        void Update()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}