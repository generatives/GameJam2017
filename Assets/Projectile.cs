using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public GameObject Source;

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject != Source)
        {
            Destroy(gameObject);
        }
    }
}
