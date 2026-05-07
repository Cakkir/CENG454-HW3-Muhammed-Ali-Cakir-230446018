using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    private IMovementStrategy _strategy;
    public Transform target;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void OnEnable()
    {
        if (_strategy == null) SetStrategy(new AggressiveMove());
        
        if (_agent != null && target != null)
        {
            _agent.enabled = true;
            _agent.SetDestination(target.position);
        }
    }

    public void SetStrategy(IMovementStrategy strategy)
    {
        _strategy = strategy;
    }

    void Update()
    {
        if (_strategy != null && target != null && _agent.isOnNavMesh)
        {
            _strategy.Move(_agent, target);
        }
    }
}