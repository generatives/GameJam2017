using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp {
    public float time = 3.0f;
    public bool active = true;

    public abstract void AddPowerUp(PlayerStats stats);
    public abstract void RemovePowerUp(PlayerStats stats);

}

public class SpeedPowerUp : PowerUp
{
    public float addedSpeed = 2.0f;

    public override void AddPowerUp(PlayerStats stats)
    {
        stats.moveSpeed += addedSpeed;
        Debug.Log("AddedSpeed");
        
    }

    public override void RemovePowerUp(PlayerStats stats)
    {
        stats.moveSpeed -= addedSpeed;
        active = false;
        Debug.Log("RemovedSpeed");
    }
}
