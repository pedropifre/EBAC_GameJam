using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

public class ControlRange : MonoBehaviour
{
    public EnemyShoot enemyShoot;

    private void OnTriggerEnter(Collider other)
    {
        enemyShoot.StartShooting();
        Debug.Log("entrou");
    }

    private void OnTriggerExit(Collider other)
    {
        enemyShoot.StopShooting();
        Debug.Log("saiu");
        
    }
}
