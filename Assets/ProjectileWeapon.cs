using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ProjectileWeapon : NetworkBehaviour
{
    public GameObject Projectile;
    public float firingRate;
    public float speed;

    [SyncVar]
    public bool IsFiring;

    private float _lastShotTime;

	// Use this for initialization
	void Start () {
        _lastShotTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(isLocalPlayer)
        {
            bool isFiring = Input.GetMouseButton(0);
            if(isFiring != IsFiring)
            {
                CmdSetIsFiring(isFiring);
            }
            if (Input.GetMouseButtonDown(0))
            {
                CmdFire();
            }
        }

        if(isServer)
        {
            if (IsFiring || _lastShotTime != (1 / firingRate))
            {
                _lastShotTime += Time.deltaTime;
                if (_lastShotTime > (1 / firingRate))
                {
                    _lastShotTime = 0;
                    if (IsFiring)
                    {
                        var obj = Instantiate(Projectile, transform.position, transform.rotation);
                        var body = obj.GetComponent<Rigidbody>();
                        body.velocity = transform.forward * speed;

                        var projectile = obj.GetComponent<Projectile>();
                        projectile.Source = gameObject;

                        NetworkServer.Spawn(obj);
                    }
                }
            }
        }
	}

    [Command]
    private void CmdSetIsFiring(bool isFiring)
    {
        IsFiring = isFiring;
    }

    [Command]
    private void CmdFire()
    {
        var obj = Instantiate(Projectile, transform.position, transform.rotation);
        var body = obj.GetComponent<Rigidbody>();
        body.velocity = transform.forward * speed;

        var projectile = obj.GetComponent<Projectile>();
        projectile.Source = gameObject;

        NetworkServer.Spawn(obj);
    }

    public void UpdateStats(PlayerStats stats)
    {
        speed = stats.projectileSpeed;
        firingRate = stats.projectileRate;
    }
}
