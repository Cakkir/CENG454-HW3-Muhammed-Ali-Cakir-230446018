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
    {_strategy = strategy;}

    private void ReactToCoreDamage(int currentHealth)
    {
        Renderer rend = GetComponentInChildren<Renderer>();
        if (rend != null)
        {
            float healthratio = (float)currentHealth / 100f;
            Color ragecolor = Color.Lerp(Color.red, Color.white, healthratio);

            rend.material.SetColor("_Basecolor", ragecolor);
            
            rend.material.color = ragecolor;
        Debug.Log("Zombi Kızarıyor: " + ragecolor);}  //Çalışmıyor
        

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