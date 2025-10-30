using UnityEngine;

public class FailingObjectSpawner : MonoBehaviour
{
    public GameObject[] fallingObject;
    public float spawnInterval = 1.5f;
    public float spawnRangeX = 2.3f;
    public float spawnY = 6f;

    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }
    void SpawnObject()
    {
        int index = Random.Range(0, fallingObject.Length);

        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), spawnY);

        Instantiate(fallingObject[index], spawnPos, Quaternion.identity);
    }
}
