using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KidController : MonoBehaviour
{
    public GameObject painelDeDialogo;

    public Text falaNPC;

    public GameObject resposta;

    private bool falaAtiva = false;

    Movimentacao movScript;
    Combos combosScript;
    dashMove dashScript;
    PlayerJump jumpScript;
    pauseInGame pauseScript;

    //CHAMAR TRANSIÇÃO
    TransicaoParaODia transicaoParaODia;
    public Fade fadeScript;

    FalaNPC falas;

    public Animator animator;

    public AudioSource runSound;

    public GameObject textoNPC, IconeCrianca, IconePlayer;

    public GameObject hudVida, hudDash, hudArmas;

    //Teste
    RespostaKid respostaData;


    void Start()
    {
        //DECLAÇÃO DE VARIÁVEIS P/ DIÁLOGO
        movScript = FindObjectOfType<Movimentacao>();
        combosScript = FindObjectOfType<Combos>();
        dashScript = FindObjectOfType<dashMove>();
        jumpScript = FindObjectOfType<PlayerJump>();
        pauseScript = FindObjectOfType<pauseInGame>();


        //CHAMAR TRANSIÇÃO
        transicaoParaODia = FindObjectOfType<TransicaoParaODia>();
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            GetComponent<Animator>().SetBool("bTutorial", true);

            if (GetComponent<Animator>().GetInteger("countStand") == 0)
            {
                StartCoroutine(waitStand());
            }

            GetComponent<Animator>().SetBool("bStretch", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("bTutorial", false);
        }
        fadeScript = FindObjectOfType<Fade>();

    }

    void Update()
    {
        if (!painelDeDialogo.activeInHierarchy)
        {
            IconeCrianca.SetActive(false);
            IconePlayer.SetActive(false);
            hudVida.SetActive(true);
            hudArmas.SetActive(true);
            hudDash.SetActive(true);
        }
        if (textoNPC.activeInHierarchy)
        {
            IconeCrianca.SetActive(true);
            IconePlayer.SetActive(false);
            hudVida.SetActive(false);
            hudArmas.SetActive(false);
            hudDash.SetActive(false);
        }
        else if (!textoNPC.activeInHierarchy && painelDeDialogo.activeInHierarchy)
        {
            IconeCrianca.SetActive(false);
            IconePlayer.SetActive(true);
            hudVida.SetActive(false);
            hudArmas.SetActive(false);
            hudDash.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) && falaAtiva)
        {
            if (falas.respostas.Length > 0)
            {
                MostrarRespostas();
            }
            else
            {
                falaAtiva = false;
                painelDeDialogo.SetActive(false);
                falaNPC.gameObject.SetActive(false);
                movScript.enabled = true;
                combosScript.enabled = true;
                jumpScript.enabled = true;
                dashScript.enabled = true;
                pauseScript.enabled = true;

                Cursor.lockState = CursorLockMode.Locked;

                if (transicaoParaODia.ganchoTransicao >= 2)
                {
                    StartCoroutine(transicaoCorrotina());
                }
            }
        }
    }

    void MostrarRespostas()
    {
        falaNPC.gameObject.SetActive(false);
        falaAtiva = false;

       for (int i = 0; i < falas.respostas.Length; i++)
        {
            GameObject tempResposta = Instantiate(resposta, painelDeDialogo.transform) as GameObject;
            tempResposta.GetComponent<Text>().text = falas.respostas[i].resposta;
            //tempResposta.GetComponent<AnswerButtonKid>().Setup(falas.respostas[i]);
            tempResposta.GetComponent<AnswerButtonKid>().Setup(falas.respostas[i]);
        }

        
    }
    public void ProximaFala(FalaNPC fala)
    {
        Cursor.lockState = CursorLockMode.None;
        movScript.enabled = false;
        combosScript.enabled = false;
        jumpScript.enabled = false;
        dashScript.enabled = false;
        pauseScript.enabled = false;
        runSound.Stop();
        animator.SetBool("bIdle", true);
        animator.SetBool("bRun", false);
        animator.SetBool("bDash", false);
        animator.SetBool("bJump", false);
        animator.SetBool("bFall", false);
        falas = fala;

        LimparRespostas();

        falaAtiva = true;
        painelDeDialogo.SetActive(true);
        falaNPC.gameObject.SetActive(true);

        falaNPC.text = falas.fala;
    }

    
    void LimparRespostas()
    {
        AnswerButtonKid[] buttons = FindObjectsOfType<AnswerButtonKid>();
        foreach (AnswerButtonKid button in buttons)
        {
            Destroy(button.gameObject);
        }
    }
    
    //CHAMAR TRANSIÇÃO
    IEnumerator waitStand()
    {
        yield return new WaitForSeconds(1.0f);
        GetComponent<Animator>().SetInteger("countStand", 1);
    }

    IEnumerator transicaoCorrotina()
    {
        yield return new WaitForSeconds(0.5f);
        fadeScript.Transition("TutorialDia");
    }

    //TESTE
    /*public void Setup(RespostaKid resposta)
    {
        respostaData = resposta;
    }
    */
}
