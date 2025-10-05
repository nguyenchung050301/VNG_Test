using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;

    public Action<int, int> onHealthChanged;
    private void Awake()
    {
        currentHealth = maxHealth;  
    }
    
    public void TakeDamage(int value)
    {
        currentHealth = Mathf.Clamp(currentHealth - value, 0, maxHealth);
        onHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    public int GetCurrentHealth() => currentHealth;
}
