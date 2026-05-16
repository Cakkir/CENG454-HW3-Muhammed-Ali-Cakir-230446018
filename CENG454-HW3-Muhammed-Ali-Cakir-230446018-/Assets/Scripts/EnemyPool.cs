using UnityEngine;

using System.Collections.Generic;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int poolsize = 10;
    private Queue<GameObject> _pool = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < poolsize; i++)
        {
            GameObject obj = Instantiate(enemyPrefab);

            obj.SetActive(false);

            _pool.Enqueue(obj);
        }
    }

    public GameObject GetEnemy(){
    
        if (_pool.Count > 0)
        {
            GameObject obj = _pool.Dequeue();

            obj.SetActive(true);

            return obj;
        }
        return Instantiate(enemyPrefab);}
    public void ReturnEnemy(GameObject obj)
    {
        obj.SetActive(false);
        
        _pool.Enqueue(obj);
    }
}