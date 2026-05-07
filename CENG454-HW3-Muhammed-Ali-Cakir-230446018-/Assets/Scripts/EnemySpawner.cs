using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyPool pool;
    public Transform spawnPoint;
    public float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        GameObject newEnemy = pool.GetEnemy();
        if (newEnemy != null && spawnPoint != null)
        {
            newEnemy.transform.position = spawnPoint.position;
        }
    }
}