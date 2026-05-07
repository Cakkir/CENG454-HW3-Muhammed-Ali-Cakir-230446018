using UnityEngine;


public interface IMovementStrategy
{
    void Move(UnityEngine.AI.NavMeshAgent agent, UnityEngine.Transform target);
}

public class AggressiveMove : IMovementStrategy
{
    public void Move(UnityEngine.AI.NavMeshAgent agent, UnityEngine.Transform target)
    {
        agent.speed = 3.5f;
        agent.SetDestination(target.position);
    }
}

public class SneakyMove : IMovementStrategy
{
    public void Move(UnityEngine.AI.NavMeshAgent agent, UnityEngine.Transform target)
    {
        agent.speed = 1.5f;
        agent.SetDestination(target.position);
    }
}