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
        SetStrategy(new AggressiveMove()); 

        CoreHealth.OnCoreDamaged += ReactToCoreDamage;
    }

    void OnDisable()
    {
        CoreHealth.OnCoreDamaged -= ReactToCoreDamage;
    }

    public void SetStrategy(IMovementStrategy strategy)
    {
        _strategy = strategy;
    }

    private void ReactToCoreDamage(int currentHealth)
    {
        Renderer rend = GetComponentInChildren<Renderer>();
        if (rend != null)
        {
            float healthRatio = (float)currentHealth / 100f;
            Color rageColor = Color.Lerp(Color.red, Color.white, healthRatio);

            rend.material.SetColor("_BaseColor", rageColor);
            
            rend.material.color = rageColor;
        Debug.Log("Zombi Kızarıyor: " + rageColor);}
        

        if (_agent != null) _agent.speed += 0.2f;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

void Update()
{
    if (_strategy != null && target != null && _agent != null)
    {
        if (_agent.isOnNavMesh) 
        {
            _strategy.Move(_agent, target);
        }
        else
        {
            Debug.LogWarning(gameObject.name + "Ariza!!!");
        }
    }
}}