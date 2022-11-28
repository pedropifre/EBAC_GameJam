using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Question;
using TMPro;

public class QuestionSend : MonoBehaviour
{
    public QuestionsManager questionsManager;
    public string resp;
    public TextMeshProUGUI textoRespostaUI;

    private bool _enviada = false;

    private void OnTriggerStay(Collider other)
    {
        textoRespostaUI.gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E) && !_enviada)
        {
            _enviada = true;
            gameObject.GetComponent<Animator>().SetTrigger("Pressed");
            gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(EnviarReposta(resp));

        }
    }

    IEnumerator EnviarReposta(string answer)
    {
        questionsManager.verificarResposta(answer);
        yield return new WaitForSeconds(3f);
        _enviada = false;
    }

    private void OnTriggerExit(Collider other)
    {
        textoRespostaUI.gameObject.SetActive(false);
    }
}
