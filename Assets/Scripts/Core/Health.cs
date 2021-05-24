using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxhealth = 50;
    int currentHealth;

    private void Start() 
    {
        currentHealth = maxhealth;    
    }

    public void Damage(int damage)
    {
        currentHealth = Mathf.Max(currentHealth -= damage, 0);
    }

    public int GetMaxHealth()
    {
        return maxhealth;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
