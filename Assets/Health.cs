using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{
    public float MaxHealth;
    public float CurrentHealth;

    void OnEnable()
    {
        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        if(isServer)
        {
            if (CurrentHealth <= 0)
            {
                var gameManager = GameObject.FindObjectOfType<GameManager>();
                if (gameManager != null)
                {
                    gameManager.GameObjectDied(gameObject);
                }
            }
        }
    }

    public void DoDamage(float damage)
    {
        CurrentHealth -= damage;
    }
}
