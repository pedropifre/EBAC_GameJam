using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GeneralUtils.Core.Singleton;

namespace Question
{

    public class QuestionsManager : Singleton<QuestionsManager>
    {
        public List<ClassePerguntas> classePerguntas;
        public TextMeshPro txtPergunta;
        public TextMeshPro aOpcao;
        public TextMeshPro bOpcao;
        public TextMeshPro cOpcao;
        public TextMeshPro dOpcao;
        [SerializeField]private string respostaSorteada;

        [Header("Player damage")]
        public Player player;

        private bool _feita = false; 

        private void OnTriggerStay(Collider other)
        {
            txtPergunta.gameObject.SetActive(true);
            aOpcao.gameObject.SetActive(true);
            bOpcao.gameObject.SetActive(true);
            cOpcao.gameObject.SetActive(true);
            dOpcao.gameObject.SetActive(true);
            if (other.gameObject.tag == "Player" && !_feita)
            {
                _feita = true;
                SortearPergunta();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            txtPergunta.gameObject.SetActive(false);
            aOpcao.gameObject.SetActive(false);
            bOpcao.gameObject.SetActive(false);
            cOpcao.gameObject.SetActive(false);
            dOpcao.gameObject.SetActive(false);
    }

        private void SortearPergunta()
        {
            var numero = Random.Range(0, classePerguntas.Count);
            txtPergunta.text = classePerguntas[numero].pergunta;
            aOpcao.text = "A) " + classePerguntas[numero].a;
            bOpcao.text = "B) " + classePerguntas[numero].b;
            cOpcao.text = "C) " + classePerguntas[numero].c;
            dOpcao.text = "D) " + classePerguntas[numero].d;
            respostaSorteada = classePerguntas[numero].reposta;
        }

        public void verificarResposta(string opcao)
        {
            if (opcao == respostaSorteada)
            {
                Debug.Log("Resposta correta");
                _feita = false;
                SortearPergunta();
            }
            else
            {
                Debug.Log("Resposta errada");
                player.healthBase.Damage(1);
            }
        }
    }




    [System.Serializable]
    public class ClassePerguntas
    {
        public string pergunta;
        public string a;
        public string b;
        public string c;
        public string d;
        public string reposta;

    }
}