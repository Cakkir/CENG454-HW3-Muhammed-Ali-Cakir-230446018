using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent _agent;

    private IMovementStrategy _strategy;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void SetStrategy(IMovementStrategy strategy)
    {_strategy = strategy;}


    void Update(){
    
        if (_strategy != null && _agent.isOnNavMesh)
        {
            _strategy.Move(_agent, transform);
        }

    }
}