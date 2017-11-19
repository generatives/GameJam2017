using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Projectile : NetworkBehaviour
{
    public GameObject Source;
    public float maxLifetime;
    public float damage;
    public float speed;

    private float _lifetime;

    void OnCollisionEnter(Collision col)
    {
        if (!isServer) return;

        if(col.gameObject != Source)
        {
            var health = col.gameObject.GetComponent<Health>();
            if(health != null)
            {
                health.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        _lifetime += Time.deltaTime;
        if(_lifetime > maxLifetime)
        {
            Destroy(gameObject);
        }
    }
}
