using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalDoorOpen : MonoBehaviour
{
    public SOInt soKey;
    public TextMeshProUGUI textoPorta;
    public TextMeshProUGUI textoPortaLocked;

    [Header("SFX")]
    public AudioSource abrindo;
    public AudioSource caindo;
    public AudioSource Porta;



    private void OnTriggerStay(Collider other)
    {
        textoPorta.gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (soKey.value == 2)
            {
                textoPorta.gameObject.SetActive(false);
                gameObject.GetComponent<Animator>().SetTrigger("Final");
                gameObject.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(TelaFinal());
                
            }
            else
            {
                StartCoroutine(textoLoked());
            }
        }
    }

    IEnumerator textoLoked()
    {
        textoPortaLocked.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        textoPortaLocked.gameObject.SetActive(false);        
    }
    IEnumerator TelaFinal()
    {
        //Tela final
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(2);
    }
    private void OnTriggerExit(Collider other)
    {
        textoPorta.gameObject.SetActive(false);
        
    }

    public void CadeadoAbrindo()
    {
        abrindo.Play();
    }
    public void CadeadoCaindo()
    {
        caindo.Play();
    }
    public void PortaAbrindo()
    {
        Porta.Play();
    }
}
