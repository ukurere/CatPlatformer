using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bubblePrefab;
    [SerializeField] private float spawnInterval = 0.9f;
    [SerializeField] private float spawnWidthRadius = 2f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnBubble();
        }
    }

    void SpawnBubble()
    {
        if (bubblePrefab == null) return;

        float randomX = transform.position.x + Random.Range(-spawnWidthRadius, spawnWidthRadius);
        float randomY = transform.position.y + Random.Range(-0.5f, 0.2f);
        Vector3 spawnPos = new Vector3(randomX, randomY, 0);

        Instantiate(bubblePrefab, spawnPos, Quaternion.identity);
    }
}