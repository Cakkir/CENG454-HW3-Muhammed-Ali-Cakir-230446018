using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyPool pool;
    public Transform spawnpoint;
    public float spawninterval = 2f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawninterval);
    }

    void SpawnEnemy()
    {
        GameObject newEnemy = pool.GetEnemy();
        if (newEnemy != null && spawnpoint != null)
        {
            newEnemy.transform.position = spawnpoint.position;
        }
    }
}