using UnityEngine;
using System;

public class CoreHealth : MonoBehaviour, IDamageable
{
    public static event Action<int> OnCoreDamaged;
    public int health = 100;

    public void TakeDamage(int amount)
    {
        health -= amount;
        OnCoreDamaged?.Invoke(health);

        if (health <= 0)
        {
            Debug.Log("Core Destroyed!");
        }
    }
}