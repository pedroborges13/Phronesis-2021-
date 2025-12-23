using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MendigoController : MonoBehaviour
{
    public GameObject painelDeDialogoMendigo;

    public Text falaMendigo;

    public GameObject respostaMendigo;

    private bool falaAtivaMendigo = false;

    Movimentacao movScript;
    Combos combosScript;
    dashMove dashScript;
    PlayerJump jumpScript;
    pauseInGame pauseScript;

    FalaMendigo falasMendigo;

    public Animator animator;

    public AudioSource runSound;

    public GameObject textoMendigo, IconePlayer, IconeMendigo;

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
        if (!painelDeDialogoMendigo.activeInHierarchy)
        {
            IconeMendigo.SetActive(false);
            IconePlayer.SetActive(false);
            hudVida.SetActive(true);
            hudArmas.SetActive(true);
            hudDash.SetActive(true);
        }
        if (textoMendigo.activeInHierarchy)
        {
            IconeMendigo.SetActive(true);
            IconePlayer.SetActive(false);
            hudVida.SetActive(false);
            hudArmas.SetActive(false);
            hudDash.SetActive(false);
        }
        else if (!textoMendigo.activeInHierarchy && painelDeDialogoMendigo.activeInHierarchy)
        {
            IconeMendigo.SetActive(false);
            IconePlayer.SetActive(true);
            hudVida.SetActive(false);
            hudArmas.SetActive(false);
            hudDash.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) && falaAtivaMendigo)
        {
            if (falasMendigo.respostasMendigo.Length > 0)
            {
                MostrarRespostas();
            }
            else
            {
                falaAtivaMendigo = false;
                painelDeDialogoMendigo.SetActive(false);
                falaMendigo.gameObject.SetActive(false);
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
        falaMendigo.gameObject.SetActive(false);
        falaAtivaMendigo = false;

        for (int i = 0; i < falasMendigo.respostasMendigo.Length; i++)
        {
            GameObject tempResposta = Instantiate(respostaMendigo, painelDeDialogoMendigo.transform) as GameObject;
            tempResposta.GetComponent<Text>().text = falasMendigo.respostasMendigo[i].respostaMendigo;
            tempResposta.GetComponent<AnswerButtonMendigo>().Setup(falasMendigo.respostasMendigo[i]);
        }
    }
    public void ProximaFalaMendigo(FalaMendigo falinhaMendigo)
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
        falasMendigo = falinhaMendigo;

        LimparRespostas();

        falaAtivaMendigo = true;
        painelDeDialogoMendigo.SetActive(true);
        falaMendigo.gameObject.SetActive(true);

        falaMendigo.text = falasMendigo.falaMendigo;
    }

    void LimparRespostas()
    {
        AnswerButtonMendigo[] buttons = FindObjectsOfType<AnswerButtonMendigo>();
        foreach (AnswerButtonMendigo button in buttons)
        {
            Destroy(button.gameObject);
        }
    }
}
