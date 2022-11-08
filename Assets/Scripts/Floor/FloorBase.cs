using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBase : MonoBehaviour
{
 
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            other.gameObject.GetComponent<HealthBase>().Damage(100);
            Debug.Log("Dano");
        }
    }
}
