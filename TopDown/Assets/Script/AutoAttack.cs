using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float attackRate = 1f;

    void Start()
    {
        InvokeRepeating(nameof(Attack), 0f, attackRate);
    }

    void Attack()
    {
        Enemy[] enemies = FindObjectsByType<Enemy>(
            FindObjectsSortMode.None);

        if (enemies.Length == 0) return;

        Enemy target = enemies[0];
        float minDist = Vector2.Distance(transform.position, target.transform.position);

        foreach (Enemy enemy in enemies)
        {
            float dist = Vector2.Distance(transform.position, enemy.transform.position);

            if (dist < minDist)
            {
                minDist = dist;
                target = enemy;
            }
        }

        GameObject bullet = Instantiate(
            bulletPrefab,
            transform.position,
            Quaternion.identity);

        bullet.GetComponent<Bullet>().target = target.transform;
    }
}