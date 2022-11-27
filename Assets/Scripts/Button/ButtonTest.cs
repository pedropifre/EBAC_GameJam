using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Itens;
using TMPro;

public class ButtonTest : ButtonBase
{

    public GameObject plataform;
    public Transform final_pos;
    public float duration = 5;

    public Camera cameraTarget;

    public TextMeshProUGUI textTip;
    public TextMeshProUGUI noCoins;
    public AudioSource audioWrong;

    [Header("Coins necessary")]
    public int coinsNecessary;

    [Header("Spwn Atualizaiton")]
    public bool needSpawn;
    public GameObject spawnPosition;
    public GameObject spawnObject;



    protected override void OnTriggerStay(Collider other)
    {
        textTip.gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E))
        {
            textTip.gameObject.SetActive(false); 
            int coins = ItemManager.Instance.ReturnCoins(ItemType.COIN);
            Debug.Log(coins);
            if (coins >= coinsNecessary)
            {
                base.OnTriggerStay(other);
                plataform.transform.DOMove(final_pos.position, duration);
                StartCoroutine(ChangeCamera(cameraTarget));
                if (needSpawn)
                {
                    spawnObject.transform.position = spawnPosition.transform.position; 
                }
            }
            else
            {
                StartCoroutine(NoCoins());
                audioWrong.Play();
            }
        }
    }
    IEnumerator ChangeCamera(Camera camera)
    {
        camera.depth = 6;
        yield return new WaitForSeconds(duration);
        camera.depth = 1; 
    }
    IEnumerator NoCoins()
    {
        noCoins.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        noCoins.gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        textTip.gameObject.SetActive(false);
    }
}
