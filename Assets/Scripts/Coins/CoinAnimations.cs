using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinAnimations : MonoBehaviour
{

    public float duaration;
   
    // Update is called once per frame
    void Start()
    {
        gameObject.transform.DORotate(new Vector3(0f, 360f, 0f), duaration, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart)
            .SetRelative()
            .SetEase(Ease.Linear);
        
    }


}
