using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Question;

public class QuestionSend : MonoBehaviour
{
    public QuestionsManager questionsManager;
    public string resp;

    private bool _enviada = false;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && !_enviada)
        {
            _enviada = true;
            StartCoroutine(EnviarReposta(resp));
        }
    }
    IEnumerator EnviarReposta(string answer)
    {
        questionsManager.verificarResposta(answer);
        yield return new WaitForSeconds(3f);
        _enviada = false;
    }
}
