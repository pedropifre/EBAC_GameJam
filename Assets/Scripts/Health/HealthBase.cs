using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class HealthBase : MonoBehaviour, IDamagable
{
    public float StartLife = 10f;
    public bool destroyOnKill = false;
    [SerializeField] private float _currentLife;

    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;


    public float damageMultiply = 1f;

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
        Damage(damage); 
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
