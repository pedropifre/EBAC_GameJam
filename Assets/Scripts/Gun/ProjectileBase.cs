using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    
    public float timeToDestroy = 2f;
    public float speed = 50f;
    public int damageAmount = 1;

    public List<string> tagsToHit;

    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (var t in tagsToHit)
        {

            if (collision.transform.tag == t)
            {

                var damageable = collision.transform.GetComponent<IDamagable>();

                if (damageable != null)
                {
                    //Debug.Log("posição original = " + collision.transform.position
                      //  + " -- posição sub = " + transform.position);
                    Vector3 dir = collision.transform.position - transform.position;
                    dir = -dir.normalized;
                    
                    damageable.Damage(damageAmount,dir);

                }

                break;
            }

        }
        Destroy(gameObject);
    }
}
