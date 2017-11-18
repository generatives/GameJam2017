using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public GameObject Source;
    public float MaxLifetime;

    private float _lifetime;

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject != Source)
        {
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
