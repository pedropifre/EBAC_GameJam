using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyCollect : MonoBehaviour
{
    public SOInt soKey;
    public TextMeshProUGUI textoPressE;


    private void OnTriggerStay(Collider other)
    {
        textoPressE.gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E))
        {
            soKey.value++;
            gameObject.SetActive(false);
            textoPressE.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textoPressE.gameObject.SetActive(false);
        
    }
}
