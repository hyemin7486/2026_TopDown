using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform player;

    public float spawnInterval = 1f;

    private float timer;
    private float gameTime;

    private void Update()
    {
        gameTime += Time.deltaTime;

        spawnInterval = Mathf.Max(
            0.15f,
            1f - gameTime * 0.015f
        );

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnArrow();
        }
    }

    private void SpawnArrow()
    {
        int randomSide = Random.Range(0, 4);

        Vector2 spawnPos = Vector2.zero;

        switch (randomSide)
        {
            case 0: 
                spawnPos = new Vector2(Random.Range(-8f, 8f), 6f);
                break;

            case 1: 
                spawnPos = new Vector2(Random.Range(-8f, 8f), -6f);
                break;

            case 2: 
                spawnPos = new Vector2(-10f, Random.Range(-4f, 4f));
                break;

            case 3: 
                spawnPos = new Vector2(10f, Random.Range(-4f, 4f));
                break;
        }

        GameObject arrow = Instantiate(
            arrowPrefab,
            spawnPos,
            Quaternion.identity
        );

        Arrow arrowScript = arrow.GetComponent<Arrow>();

        arrowScript.speed = Mathf.Min(
            12f,
            5f + gameTime * 0.1f
        );

       
        Vector2 moveDir =
            ((Vector2)player.position - spawnPos).normalized;

        arrowScript.SetDirection(moveDir);
    }
}