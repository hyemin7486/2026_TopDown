using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;

    public float spawnInterval = 5f;

    public float mapSize = 8f;

    private void Start()
    {
        InvokeRepeating
        (
            nameof(SpawnCoin),
            1f,
            spawnInterval
        );
    }

    void SpawnCoin()
    {
        Vector3 pos = new Vector3
        (
            Random.Range(-mapSize, mapSize),
            Random.Range(-mapSize, mapSize),
            0
        );

        Instantiate
        (
            coinPrefab,
            pos,
            Quaternion.identity
        );
    }
}