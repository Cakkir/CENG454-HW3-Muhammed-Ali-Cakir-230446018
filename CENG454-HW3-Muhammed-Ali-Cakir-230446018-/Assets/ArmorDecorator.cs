using UnityEngine;

public class ArmorDecorator :  IDamageable
{
    private readonly IDamageable _decoratedDamageable;
    private readonly float _damageReduction;

    public ArmorDecorator(IDamageable damageable, float reduction)
    {
        _decoratedDamageable = damageable;
        _damageReduction = reduction;
    }

    public void TakeDamage(int amount)
    {
        int reducedAmount = Mathf.RoundToInt(amount * (1 - _damageReduction));
        _decoratedDamageable.TakeDamage(reducedAmount);
    }
}