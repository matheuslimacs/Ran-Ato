public class PlayerStats
{
    public int Health;
    public float JumpPower;
    public int Ammo;

    public PlayerStats(int hp, float jPower, int ammo)
    {
        Health = hp;
        JumpPower = jPower;
        Ammo = ammo;
    }

    public void TakeDamage(int amnt)
    {
        Health -= amnt;
    }
}
