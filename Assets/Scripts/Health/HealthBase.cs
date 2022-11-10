using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using DG.Tweening;


public class HealthBase : MonoBehaviour, IDamagable
{
    public float StartLife = 10f;
    public bool destroyOnKill = false;
    public float _currentLife;

    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;

    public float damageMultiply = 1f;

    [Header("velocity Hit")]
    public float xForce;
    public float yForce;
    public float zForce;
    public float durationForce;
    public FirstPersonMovement firstPersonMovement;

    private void Awake()
    {
        Init();
    }
    public void Init()
    {
        ResetLife();
    }


    public void ResetLife()
    {
        _currentLife = StartLife;
        
    }

    protected virtual void Kill()
    {
        if(destroyOnKill)
            Destroy(gameObject, 3f);
        OnKill?.Invoke(this);
        Player.Instance.RespawnPlayer();
    }

    [NaughtyAttributes.Button]
    public void Damage()
    {
        Damage(5);
    }

 
    public void Damage(float f)
    {

        _currentLife -= f * damageMultiply;

        if (_currentLife <= 0)
        {
            Kill();
        }
        
        OnDamage?.Invoke(this);
    }

    public void Damage(float damage, Vector3 dir)
    {
        if (dir.y > 0) dir.y *= -1f;
        //gameObject.transform.DOMove(gameObject.transform.position - dir, durationHit);
        dir.y = gameObject.transform.position.y * yForce;
        dir.x = gameObject.transform.position.x + xForce;
        dir.z = gameObject.transform.position.z * zForce;

        Rigidbody corpo = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(unableWalk());
        corpo.AddRelativeForce(dir);
        

        Damage(damage); 
    }

    IEnumerator unableWalk()
    {
        Debug.Log("djnaijk");
        firstPersonMovement.CantRun(false);
        yield return new WaitForSeconds(durationForce);
        firstPersonMovement.CantRun(true);
    }

   

    
    public void ChangeDamageMultiply(float damageMultiply, float duration)
    {
        StartCoroutine(ChangeDamageMultiplyCourotine(damageMultiply, duration));
    }

    IEnumerator ChangeDamageMultiplyCourotine(float damageMultiply, float duration)
    {
        this.damageMultiply = damageMultiply;
        yield return new WaitForSeconds(duration);
        this.damageMultiply = 1;
    }
}
