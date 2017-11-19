using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{
    public float MaxHealth;
    public float healthPerFive;

    [SyncVar]
    public float currentHealth;

    void OnEnable()
    {
        currentHealth = MaxHealth;
    }

    void Update()
    {
        if(isServer)
        {
            if (currentHealth <= 0)
            {
                var gameManager = GameObject.FindObjectOfType<GameManager>();
                if (gameManager != null)
                {
                    gameManager.GameObjectDied(gameObject);
                }
            }
            else {
                currentHealth += healthPerFive * Time.deltaTime / 5f;
                if (currentHealth >= MaxHealth)
                {
                    currentHealth = MaxHealth;
                }
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    public void UpdateStats(PlayerStats stats)
    {
        MaxHealth = stats.maxHealth;
        healthPerFive = stats.healRatePerFive;
    }
}
