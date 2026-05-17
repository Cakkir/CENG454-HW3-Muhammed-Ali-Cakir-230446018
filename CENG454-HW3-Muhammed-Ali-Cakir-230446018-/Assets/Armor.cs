using UnityEngine;

public class Armor:  IDamageable // Decorator design
{
    private readonly IDamageable decorateddamageable;
    private readonly float damagereduction;

    public Armor(IDamageable damageable, float reduction)
    {
        decorateddamageable = damageable;
        damagereduction = reduction;
    }

    public void TakeDamage(int amount)
    {
        int reducedAmount = Mathf.RoundToInt(amount * (1 - damagereduction));
        decorateddamageable.TakeDamage(reducedAmount);
    }
}