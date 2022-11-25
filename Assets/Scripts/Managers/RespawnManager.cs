using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RespawnManager : MonoBehaviour
{
    public Animator animator;
    public GameObject flag;
    public Player player;
    public AudioSource audioSource;
    public TextMeshProUGUI textoCheckpoint;

    private bool _IsOn = false;

    private void sxasa(Collider collision)
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !_IsOn)
        {
            _IsOn = true;
            animator.SetBool("Checked",true);
            audioSource.Play();
            player.MoveSpawn(flag.transform.position);
            StartCoroutine(CheckPointUI());
        }

    }

    IEnumerator CheckPointUI()
    {
        textoCheckpoint.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        textoCheckpoint.gameObject.SetActive(false);
    }


}
