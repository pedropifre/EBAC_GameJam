using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneHelper : MonoBehaviour
{
    public void LoadLevel(int Level)
    {
        SceneManager.LoadScene(Level);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
