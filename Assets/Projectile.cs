using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public GameObject Source;
    public float MaxLifetime;
    public float Damage;

    private float _lifetime;

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject != Source)
        {
            var health = col.gameObject.GetComponent<Health>();
            if(health != null)
            {
                health.DoDamage(Damage);
            }
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        _lifetime += Time.deltaTime;
        if(_lifetime > MaxLifetime)
        {
            Destroy(gameObject);
        }
    }
}
