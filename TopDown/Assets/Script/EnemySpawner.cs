using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime = 1f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnTime);
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos =
            (Vector2)Random.insideUnitCircle.normalized * 10f;

        Instantiate(
            enemyPrefab,
            spawnPos,
            Quaternion.identity
        );
    }
}