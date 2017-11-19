

[System.Serializable]
public class PlayerStats {
    //projectile
    public float projectileRate;
    public float projectileSpeed;
    public float projectileDamage;
    public float projectileLife;
    public float projectileSize;

    //movement
    public float moveSpeed;
    public float jumpHeight;

    //player
    public float maxHealth;
    public float healRatePerFive;

    public PlayerStats GetCopy()
    {
        return (PlayerStats)this.MemberwiseClone();
    }

}
