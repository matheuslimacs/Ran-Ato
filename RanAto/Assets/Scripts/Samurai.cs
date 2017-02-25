using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samurai : PlayerStats {

    private PlayerStats myStats;

    private void Awake()
    {
        myStats = GameObject.Find("_GM").GetComponent<PlayerStats>();
    }

    private void Update()
    {

    }

}
