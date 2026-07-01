using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [Header("Projectile")]
    public GameObject projectilePrefab;
    public Transform firePoint;

    [Header("Shoot Settings")]
    public float shootInterval = 2f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= shootInterval)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}