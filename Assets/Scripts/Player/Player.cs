using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeneralUtils.Core.Singleton;

public class Player : Singleton<Player>
{
    public GameObject respawn;

    public void RespawnPlayer()
    {
        gameObject.transform.position = respawn.transform.position;
    }



}
