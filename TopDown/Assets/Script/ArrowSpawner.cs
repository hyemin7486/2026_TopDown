using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrowPrefab;

    public float spawnInterval = 1f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0;
            SpawnArrow();
        }
    }

    private void SpawnArrow()
    {
        int randomSide = Random.Range(0, 4);

        Vector2 spawnPos = Vector2.zero;
        Vector2 moveDir = Vector2.zero;

        switch (randomSide)
        {
            case 0: 
                spawnPos = new Vector2(Random.Range(-8f, 8f), 6f);
                moveDir = Vector2.down;
                break;

            case 1: 
                spawnPos = new Vector2(Random.Range(-8f, 8f), -6f);
                moveDir = Vector2.up;
                break;

            case 2: 
                spawnPos = new Vector2(-10f, Random.Range(-4f, 4f));
                moveDir = Vector2.right;
                break;

            case 3: 
                spawnPos = new Vector2(10f, Random.Range(-4f, 4f));
                moveDir = Vector2.left;
                break;
        }

        GameObject arrow =
            Instantiate(arrowPrefab, spawnPos, Quaternion.identity);

        arrow.GetComponent<Arrow>().SetDirection(moveDir);
    }
}