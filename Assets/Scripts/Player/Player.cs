using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeneralUtils.Core.Singleton;

public class Player : Singleton<Player>
{
    public GameObject respawn;
    public HealthBase healthBase;

    public void RespawnPlayer()
    {
        gameObject.transform.position = respawn.transform.position;
        healthBase._currentLife = healthBase.StartLife;
    }

    public void MoveSpawn(Vector3 pos)
    {
        respawn.transform.position = pos;
    }



}
