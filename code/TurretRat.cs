using UnityEngine;

public class TurretRat
{
    public int health = 100;
    public int detectionRadius = 20;
    public float bulletSpeed = 20f;
    public float fireRate = 0.5f;
    public float nextFire = 0f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform firePoint1;
    public Transform player;
    
    void Update()
    {
        if (PlayerInRange())
        {
            AimAtPlayer(); 
            if (Time.time >= nextFire)
            { 
                Shoot();
                nextFire = Time.time + fireRate;
            }
        }
    }

    bool PlayerInRange()
    {
        if (player == null)
        {
            return false;
        }

        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;
        if (distanceToPlayer > detectionRadius)
        {
            return false;
        }
        
        return true;
    }

    void AimAtPlayer()
    {
        Vector3 directionToPlayer = (player.position - tramsform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        tramsform.rotation = Quaternion.Slerp
            (tramsform.rotation, target.rotation, 5f * Time.deltaTime);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, 
            firePoint.position, firePoint.rotation);
        GameObject bullet1 = Instantiate(bulletPrefab, 
            firePoint1.position, firePoint1.rotation);
        
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

    public void takeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Die();
        }        
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
