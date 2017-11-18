using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour {

    public GameObject Projectile;
    public float FiringRate;
    public float Speed;
    public bool IsFiring;

    private float _lastShotTime;

	// Use this for initialization
	void Start () {
        _lastShotTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        IsFiring = Input.GetMouseButton(0);

        if(IsFiring || _lastShotTime != (1 / FiringRate))
        {
            _lastShotTime += Time.deltaTime;
            if (_lastShotTime > (1 / FiringRate))
            {
                _lastShotTime = 0;
                if(IsFiring)
                {
                    var obj = Instantiate(Projectile);

                    obj.transform.position = transform.position;

                    var body = obj.GetComponent<Rigidbody>();
                    body.velocity = transform.forward * Speed;

                    var projectile = obj.GetComponent<Projectile>();
                    projectile.Source = gameObject;
                }
            }
        }
	}
}
