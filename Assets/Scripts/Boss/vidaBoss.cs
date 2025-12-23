using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class vidaBoss : MonoBehaviour
{
    public float life;
    private int dead = 0;

    
    public AudioSource deathScream;

    private GameObject player;
    public bool bossMorto = false;

    public Image lifeBarBoss;
    public GameObject BossLife;

    public GameObject agradecimento;

    //private GameObject player;

    //Pensamento
    public GameObject painelDialogoSozinho;
    public GameObject iconePlayer;
    public bool pensamentoTrueFalse = true;
    public GameObject _textPensamento;

    //Transição
    public Fade fadeScript;
    TransicaoParaODia transicaoParaODia;

    //Animacoes
    public GameObject modelBoss;
    private Animator animaBoss;
    private int contDeath = 0;

    Boss bossScript;

    //Player
    Movimentacao movScript;
    Combos combosScript;
    dashMove dashScript;
    PlayerJump jumpScript;

    private void Start()
    {
        _textPensamento.SetActive(true);

        animaBoss = modelBoss.GetComponent<Animator>();

        bossScript = FindObjectOfType<Boss>();

        BossLife.SetActive(true);

        //player = GameObject.FindGameObjectWithTag("Player");

        //CHAMAR TRANSIÇÃO
        transicaoParaODia = FindObjectOfType<TransicaoParaODia>();
        if (SceneManager.GetActiveScene().name == "SalaBoss")
        {
            GetComponent<Animator>().SetBool("bSalaBoss", true);

            if (GetComponent<Animator>().GetInteger("countStand") == 0)
            {
                StartCoroutine(waitStand());
            }

            GetComponent<Animator>().SetBool("bStretch", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("bSalaBoss", false);
        }
        fadeScript = FindObjectOfType<Fade>();

        //Scripts player
        movScript = FindObjectOfType<Movimentacao>();
        combosScript = FindObjectOfType<Combos>();
        dashScript = FindObjectOfType<dashMove>();
        jumpScript = FindObjectOfType<PlayerJump>();
    }

    void FixedUpdate()
    {
        if (life <= 0)
        {
            dead++;

            bossMorto = true;
            //StartCoroutine(aparecerPensamento());

        }
        if (bossMorto == true)
        {
            bossMorto = false;
            BossLife.SetActive(false);
            StartCoroutine(enemyDeath());
            movScript.enabled = false;
            combosScript.enabled = false;
            jumpScript.enabled = false;
            dashScript.enabled = false;

        }
    }

    void Update()
    {
        // Movimenta a barra de vida
        life = Mathf.Clamp(life, 0, life);
        lifeBarBoss.fillAmount = life / 500;
    }

    IEnumerator enemyDeath()
    {
        if(contDeath == 0)
        {
            animaBoss.SetBool("bDeath", true);
            contDeath++;
            StartCoroutine(animaDeath());
            //GetComponent<CapsuleCollider>().gameObject.
        }

        yield return new WaitForSecondsRealtime(0.5f);
        painelDialogoSozinho.SetActive(true);
        iconePlayer.SetActive(true);
        yield return new WaitForSecondsRealtime(7);
        //agradecimento.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        fadeScript.Transition("posBoss");
        //fadeScript.Transition("CreditosAvisos");

        yield return new WaitForSecondsRealtime(1);
        
        //audioSourceBoss.Play();
    }

    IEnumerator waitStand()
    {
        yield return new WaitForSeconds(1.0f);
        GetComponent<Animator>().SetInteger("countStand", 1);
    }

    IEnumerator animaDeath()
    {
        yield return new WaitForSecondsRealtime(0.02f);
        animaBoss.SetInteger("ContDeath", 1);
        deathScream.Play();
        bossScript.enabled = false;
        yield return new WaitForSecondsRealtime(4.3f);
        animaBoss.enabled = false;
    }

    /*IEnumerator aparecerPensamento()
    {
        yield return new WaitForSecondsRealtime(2);
        painelDialogoSozinho.SetActive(true);
        iconePlayer.SetActive(true);
        yield return new WaitForSecondsRealtime(4);
        painelDialogoSozinho.SetActive(false);
        iconePlayer.SetActive(false);
        pensamentoTrueFalse = false;
    }
    */
}
