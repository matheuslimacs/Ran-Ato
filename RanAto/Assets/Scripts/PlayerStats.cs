using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public class Player
    {
        public int Health;
        public float JumpPower;
        public int Ammo;

        public Player(int hp, float jPower, int ammo)
        {
            Health = hp;
            JumpPower = jPower;
            Ammo = ammo;
        }

        public Player()
        {
            Health = 100;
            JumpPower = 7f;
            Ammo = 2;
        }

        public void TakeDamage(int amnt)
        {
            Health -= amnt;
        }
    }

    public Player Samurai = new Player(150, 8f, 5);

    private void Update()
    {
        Samurai.TakeDamage(10);
        Debug.Log(Samurai.Health);
    }
}
