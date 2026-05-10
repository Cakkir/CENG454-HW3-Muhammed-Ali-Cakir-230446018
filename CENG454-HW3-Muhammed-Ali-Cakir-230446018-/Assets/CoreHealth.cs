using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class CoreHealth : MonoBehaviour, IDamageable
{
    public static event Action<int> OnCoreDamaged;

    public int health = 100;
    public GameObject shieldVisual;

    private IDamageable _currentDamageHandler;

    void Awake()
    {
        _currentDamageHandler = this;

        if (shieldVisual != null)
        {
            shieldVisual.SetActive(false);
        }
    }

    void Update()
    {
        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            ActivateShield(0.5f);
        }

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            OnCoreDamaged?.Invoke(health);
        }
    }

    public void ActivateShield(float reductionPercent)
    {
        _currentDamageHandler = new ArmorDecorator(this, reductionPercent);
        
        if (shieldVisual != null)
        {
            shieldVisual.SetActive(true);
        }
    }

    public void TakeDamage(int amount)
    {
        if (ReferenceEquals(_currentDamageHandler, this))
        {
            ApplyActualDamage(amount);
        }
        else
        {
            _currentDamageHandler.TakeDamage(amount);
        }
    }

    public void ApplyActualDamage(int amount)
    {
        health -= amount;
        OnCoreDamaged?.Invoke(health);

        if (health <= 0)
        {
            Debug.Log("Core Destroyed!");
        }
    }
}