using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyLavaRod : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                var damageable = collision.transform.GetComponent<IDamagable>();
                if (damageable != null)
                {
                    Vector3 dir = collision.transform.position - transform.position;
                    dir = -dir.normalized;

                    damageable.Damage(1, dir);

                }
            }
        }
    }
}
