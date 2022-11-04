using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LavaFloat : MonoBehaviour
{
    public float AnimDuration = 2;
    public float floatLevel = 1;
    public Ease ease = Ease.OutBack;

    private bool _animEnded = true;
    private bool _collisison = false;

    // Update is called once per frame
    void Update()
    {
        if(_animEnded && !_collisison) StartCoroutine(FloatAnimation());
    }

    IEnumerator FloatAnimation()
    {
        _animEnded = false;
        float AnimDurationProvisory = AnimDuration * (float)Random.Range(0.8f, 1.2f);
        Vector3 position = gameObject.transform.position;
        Sequence sequencia = DOTween.Sequence();
        sequencia.Append(gameObject.transform.DOMoveY(position.y + floatLevel, AnimDurationProvisory).SetEase(ease));
        sequencia.Append(gameObject.transform.DOMoveY(position.y, AnimDurationProvisory).SetEase(ease));
        yield return new WaitForSeconds(AnimDurationProvisory * 2);
        _animEnded = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        _collisison = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        _collisison = false;
    }
}
