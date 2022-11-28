using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GeneralUtils.Core.Singleton;
using DG.Tweening;

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

        [Header("UI")]
        public TextMeshProUGUI txtCorretas;

        [Header("Player damage")]
        public Player player;

        [Header("Objetos para esconder")]
        public List<GameObject> hideObjects;

        [Header("SpawnChave")]
        public Vector3 posicaoFinal;
        public GameObject keyFinal;

        private bool _feita = false;
        [SerializeField] private int perguntasFeitas = 0;
        [SerializeField] private int _perguntasCorretas =0;  


        

        private void OnTriggerEnter(Collider other)
        {
            foreach (var i in hideObjects)
            {
                i.SetActive(true);
            }
            if (other.gameObject.tag == "Player" && !_feita)
            {
                _feita = true;
                SortearPergunta();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            foreach (var i in hideObjects)
            {
                i.SetActive(false);
            }
        }

        private void SortearPergunta()
        {                      
            txtPergunta.text = classePerguntas[perguntasFeitas].pergunta;
            aOpcao.text = "A) " + classePerguntas[perguntasFeitas].a;
            bOpcao.text = "B) " + classePerguntas[perguntasFeitas].b;
            cOpcao.text = "C) " + classePerguntas[perguntasFeitas].c;
            dOpcao.text = "D) " + classePerguntas[perguntasFeitas].d;
            respostaSorteada = classePerguntas[perguntasFeitas].reposta;
            perguntasFeitas++;
            Debug.Log("a");
            if (perguntasFeitas >= classePerguntas.Count)
            {
                perguntasFeitas=0;
            }
        }

        public void verificarResposta(string opcao)
        {
            if (opcao == respostaSorteada)
            {
                Debug.Log("Resposta correta");
                _perguntasCorretas++;
                if (_perguntasCorretas >= 10)
                {
                    foreach (var i in hideObjects)
                    {
                        i.SetActive(false);
                    }
                    //tocar musica de vitoria
                    gameObject.GetComponent<AudioSource>().Play();
                    //spawnar key
                    keyFinal.transform.DOLocalMove(posicaoFinal, 4).SetEase(Ease.OutBack);
                }
                else
                {
                    _feita = false;
                    SortearPergunta();
                    txtCorretas.text =  _perguntasCorretas.ToString() + "/10 Respostas corretas" ;
                }
            }
            else
            {
                Debug.Log("Resposta errada");
                player.healthBase.Damage(1);
                _feita = false;
                SortearPergunta();
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