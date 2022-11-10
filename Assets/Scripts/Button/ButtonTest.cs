using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Itens;

public class ButtonTest : ButtonBase
{

    public GameObject plataform;
    public Transform final_pos;
    public float duration = 5;

    public Camera cameraTarget;

    protected override void OnTriggerStay(Collider other)
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            int coins = ItemManager.Instance.ReturnCoins(ItemType.COIN);
            Debug.Log(coins);
            if (coins >= 20)
            {
                base.OnTriggerStay(other);
                plataform.transform.DOMove(final_pos.position, duration);
                StartCoroutine(ChangeCamera(cameraTarget));
            }
        }
    }

    IEnumerator ChangeCamera(Camera camera)
    {
        camera.depth = 6;
        yield return new WaitForSeconds(duration);
        camera.depth = 1; 
    }
}
