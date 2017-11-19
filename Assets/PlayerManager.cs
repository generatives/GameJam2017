using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public PlayerStats stats;
    public PlayerStats baseStats;
    public List<PowerUp> currentPowerUps;

    public PlayerMovement playerMovement;
    public ProjectileWeapon projectileWeapon;
    public Health health;



    // Use this for initialization
    void Start () {
        baseStats = stats.GetCopy();
        currentPowerUps = new List<PowerUp>();
        UpdateAllStats();
	}
	
	// Update is called once per frame
	void Update () {
        
        //Changing this to an array so we can delete stuff while looping
        foreach (PowerUp p in currentPowerUps.ToArray())
        {
            p.time -= Time.deltaTime;
            if (p.time <= 0)
            {
                p.RemovePowerUp(stats);
                UpdateAllStats();
                currentPowerUps.Remove(p);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PowerUp p = new SpeedPowerUp();
            p.AddPowerUp(stats);
            Debug.Log(stats.moveSpeed);
            currentPowerUps.Add(p);
        }
	}

    public void UpdateAllStats()
    {
        playerMovement.UpdateStats(stats);
        //DOES NOT account for projectile time and stuff yet, soon(tm)
        projectileWeapon.UpdateStats(stats);
        health.UpdateStats(stats);
    }


}
