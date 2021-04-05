using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int maxHealth;
    float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageValue)
    {
        currentHealth -= damageValue;
    }

    void Update()
    {
        if(currentHealth <= 0) Destroy(gameObject);
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }
}
