using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damageAmount = 10;
    public float attackRange = 1.2f;
    private Transform _target;

    void Start()
    {
        _target = GetComponent<Enemy>().target;
    }

    void Update()
    {
        if (_target != null && Vector3.Distance(transform.position, _target.position) < attackRange)
        {
            IDamageable damageable = _target.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damageAmount);
                GetComponent<Enemy>().Die();
            }
        }
    }
}