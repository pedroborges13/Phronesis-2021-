using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VelhoController : MonoBehaviour
{
    public GameObject painelDeDialogoVelho;

    public Text falaVelhoNPC; //public Text falaNPC;

    public GameObject resposta;

    private bool falaAtiva = false;

    Movimentacao movScript;
    Combos combosScript;
    dashMove dashScript;
    PlayerJump jumpScript;
    pauseInGame pauseScript;

    FalaVelho falona;

    public Animator animator;

    public AudioSource runSound;

    public GameObject textoNPC, IconeVelho, IconePlayer;

    public GameObject hudVida, hudDash, hudArmas;

    void Start()
    {
        movScript = FindObjectOfType<Movimentacao>();
        combosScript = FindObjectOfType<Combos>();
        dashScript = FindObjectOfType<dashMove>();
        jumpScript = FindObjectOfType<PlayerJump>();
        pauseScript = FindObjectOfType<pauseInGame>();
    }

    void Update()
    {
        if (!painelDeDialogoVelho.activeInHierarchy)
        {
            IconeVelho.SetActive(false);
            IconePlayer.SetActive(false);
            hudVida.SetActive(true);
            hudArmas.SetActive(true);
            hudDash.SetActive(true);
        }
        if (textoNPC.activeInHierarchy)
        {
            IconeVelho.SetActive(true);
            IconePlayer.SetActive(false);
            hudVida.SetActive(false);
            hudArmas.SetActive(false);
            hudDash.SetActive(false);
        }
        else if (!textoNPC.activeInHierarchy && painelDeDialogoVelho.activeInHierarchy)
        {
            IconeVelho.SetActive(false);
            IconePlayer.SetActive(true);
            hudVida.SetActive(false);
            hudArmas.SetActive(false);
            hudDash.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) && falaAtiva)
        {
            if (falona.respostinha.Length > 0)
            {
                MostrarRespostas();
            }
            else
            {
                falaAtiva = false;
                painelDeDialogoVelho.SetActive(false);
                falaVelhoNPC.gameObject.SetActive(false);
                movScript.enabled = true;
                combosScript.enabled = true;
                jumpScript.enabled = true;
                dashScript.enabled = true;
                pauseScript.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    void MostrarRespostas()
    {
        falaVelhoNPC.gameObject.SetActive(false);
        falaAtiva = false;

        for (int i = 0; i < falona.respostinha.Length; i++)
        {
            GameObject tempRespostaa = Instantiate(resposta, painelDeDialogoVelho.transform) as GameObject;
            tempRespostaa.GetComponent<Text>().text = falona.respostinha[i].respostaaa; //respostaaa é a string do script "RespostaVelho"
            tempRespostaa.GetComponent<AnswerButtonVelho>().Setup(falona.respostinha[i]); //script AnwserButtonVelho
        }
    }
    public void ProximaFalaVelho(FalaVelho falinha)
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
        falona = falinha;

        LimparRespostas();

        falaAtiva = true;
        painelDeDialogoVelho.SetActive(true);
        falaVelhoNPC.gameObject.SetActive(true);

        falaVelhoNPC.text = falona.falinha;
    }

    void LimparRespostas()
    {
        AnswerButtonVelho[] buttons = FindObjectsOfType<AnswerButtonVelho>();
        foreach (AnswerButtonVelho button in buttons)
        {
            Destroy(button.gameObject);
        }
    }
}
