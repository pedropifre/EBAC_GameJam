using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProceessingManager : MonoBehaviour
{
    public GameObject postProcessingVolume;
    private bool _isOn = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && _isOn)
        {
            postProcessingVolume.SetActive(false);
            _isOn = false;
        }
        else if (Input.GetKeyDown(KeyCode.P) && !_isOn)
        {
            postProcessingVolume.SetActive(true);
            _isOn = true;
        }
        
    }
}
