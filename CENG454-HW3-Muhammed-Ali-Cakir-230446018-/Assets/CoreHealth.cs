using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class CoreHealth : MonoBehaviour, IDamageable
{
    public static event Action<int> OnCoreDamaged;

public int health = 100;


    public GameObject shieldvisual;

    private IDamageable currentdamagehandler;
    private IDamageable realdamageable;

    private class RealDamageReceiver : IDamageable
    {
        private CoreHealth _core;
        public RealDamageReceiver(CoreHealth core) => _core = core;
        
        public void TakeDamage(int amount)
        {
            _core.ApplyActualDamage(amount);
        }
    }

    void Awake()
    {
        realdamageable = new RealDamageReceiver(this);


        currentdamagehandler = realdamageable;

        if (shieldvisual != null)

        {
            shieldvisual.SetActive(false);
        }

    }

    void Update()
    {

        if (Keyboard.current != null && Keyboard.current.kKey.wasPressedThisFrame)// K tuşu Kalkan
        {
            ActivateShield(0.5f);
        }

    }

    public void ActivateShield(float reductionpercent)
    {
       
        currentdamagehandler = new Armor(realdamageable, reductionpercent);
        
        if (shieldvisual != null)
        {
            shieldvisual.SetActive(true);
        }

    }

    public void TakeDamage(int amount)
    {
        currentdamagehandler.TakeDamage(amount);
    }

    public void ApplyActualDamage(int amount)
    {

        health -= amount;
        Debug.Log($"Çekirdek Hasar aldı Kalan Can: {health}");

        OnCoreDamaged?.Invoke(health);



        if (health <= 0)
        {
            Debug.Log("Core Destroyed");
        }

    }
}