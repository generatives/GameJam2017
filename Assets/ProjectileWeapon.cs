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
        }

        if(isServer)
        {
            if (IsFiring || _lastShotTime != (1 / firingRate))
            {
                Debug.Log("1");
                _lastShotTime += Time.deltaTime;

                Debug.Log(_lastShotTime);
                Debug.Log((1 / firingRate));
                if (_lastShotTime > (1 / firingRate))
                {
                    Debug.Log("3fesfe");
                    _lastShotTime = 0;
                    if (IsFiring)
                    {
                        Debug.Log("4fesfe");
                        var obj = Instantiate(Projectile, transform.position, transform.rotation);
                        Debug.Log("5fesfe");
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

    public void UpdateStats(PlayerStats stats)
    {
        speed = stats.projectileSpeed;
        firingRate = stats.projectileRate;
    }
}
