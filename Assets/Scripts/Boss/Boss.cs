using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    vidaPlayer vidaPlayerScript;
    feedbackPlayer fbPlayerScript;
    KnockBack kbScript;
    vidaBoss vidaDoBoss;
    Movimentacao scriptMovimentacao;
    dashMove scriptDash;
    private Transform posicaoDoJogador;
    private Transform posicaoDoBoss;

    //Controle de pulo
    public float jumpSpeedUp;
    public float jumpSpeedRight;
    public float jumpSpeedLeft;
    public float jumpSpeedDown;
    public float speedCorte;
    public float speedDashCorte;
    public float sugada;
    public Rigidbody rigidBodyBoss;
    public Rigidbody rigidBodyPlayer;
    public GameObject effectL;
    public GameObject effectR;
    

    //Permissões
    public bool podePular = true;
    public bool podeCortar = true;
    public bool estaSugando = false;
    public bool liberaAtaques = false;
    public bool pausaBoss = true;
    public bool halfLife = false;

    //Sons
    public GameObject musicPT1;
    public GameObject musicPT2;
    public GameObject middleFightScream;
    //Dano
    public float danoDoCorteLeve;
    public float danoDoCortePesado;
    public float danoDoCorteDuplo;
    public float danoDaInvestida;
    private int chanceDeAtaque;

    //Animacoes
    public GameObject modelBoss;
    private Animator animaBoss;
    private int contAnimLife = 0;

    void Start()
    {
        //scriptMovimentacao.enabled = false;
        //Pegar posição do Player e Boss
        posicaoDoJogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        posicaoDoBoss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Transform>();

        animaBoss = modelBoss.GetComponent<Animator>();

        //Invocar Scripts
        vidaPlayerScript = FindObjectOfType<vidaPlayer>();
        fbPlayerScript = FindObjectOfType<feedbackPlayer>();
        kbScript = GetComponent<KnockBack>();
        vidaDoBoss = FindObjectOfType<vidaBoss>();
        scriptMovimentacao = FindObjectOfType<Movimentacao>();
        scriptDash = FindObjectOfType<dashMove>();
    }

    void Update()
    {
       
        Debug.Log("Distância do Boss: " + Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position));

        if (pausaBoss == true)
        {
            StartCoroutine(ativaMovimentos());
            Debug.Log("Esperando...");
        }

        /*if(liberaAtaques == true)
        {
            if(animaBoss.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            StartCoroutine(cooldownPulo());
        }
        */
        if(liberaAtaques == true)
        {
            if ((posicaoDoJogador.transform.position.x < posicaoDoBoss.transform.position.x) && !animaBoss.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }

            if ((posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x) && !animaBoss.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }

            //Sugada
            if (estaSugando == true)
            {
                animaBoss.SetBool("bPull", true);
                if (posicaoDoJogador.transform.position.x < posicaoDoBoss.transform.position.x)
                {
                    rigidBodyPlayer.AddForce(Vector3.right * sugada, ForceMode.Acceleration);
                    scriptMovimentacao.speed = 1;
                    Debug.Log("sugandoCorrotinaEsquerda");
                    scriptDash.enabled = false;
                    effectR.SetActive(true);
                }
                else
                {
                    rigidBodyPlayer.AddForce(Vector3.left * sugada, ForceMode.Acceleration);
                    scriptMovimentacao.speed = 1;
                    Debug.Log("sugandoCorrotinaDireita");
                    scriptDash.enabled = false;
                    effectL.SetActive(true);
                }
            }
            else
            {
                scriptDash.enabled = true;
                scriptMovimentacao.speed = 5;
                effectL.SetActive(false);
                effectR.SetActive(false);
            }

            //ATAQUES

            //Pular para a direita
            if (podePular == true)
            {
                if (Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) > 7.5f && posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x)
                {
                    StartCoroutine(puloDireita());
                    Debug.Log("Pulou p/ Direita");
                }

                //Pular para a esquerda
                if (Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) > 7.5f && posicaoDoJogador.transform.position.x < posicaoDoBoss.transform.position.x)
                {
                    StartCoroutine(puloEsquerda());
                    Debug.Log("Pulou p/ Esquerda");
                }
            }

            //Cortar
            if (podeCortar == true)
            {
                if (vidaDoBoss.life > 300)
                {
                    if (Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) < 4.1f)
                    {
                        StartCoroutine(cooldownCorte());
                        corteRapido();
                        Debug.Log("cortou Leve!");
                    }
                }
                else
                {
                    animaBoss.SetInteger("HalfLife", 1);
                    
                    if (contAnimLife < 5)
                    {
                        contAnimLife++;
                    }
                    musicPT1.SetActive(false);
                    musicPT2.SetActive(true);
                    StartCoroutine(animaHalfLife());
                    //halfLife = true;

                    
                    //Chamar Som
                    if (Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) < 4.1f) // Só funciona se pular(???)
                    {
                        StartCoroutine(cooldownCorte());
                        cortePesado();
                        Debug.Log("cortou Pesado!");
                    }
                }

            }
        }
    }

    //Controlar direção dos pulos
    IEnumerator puloDireita()
    {
        podePular = false;
        if (podePular == false)
        {
            animaBoss.SetBool("bJump", true);

            rigidBodyBoss.AddForce(Vector3.up * jumpSpeedUp, ForceMode.VelocityChange);
            yield return new WaitForSecondsRealtime(0.3f);
            rigidBodyBoss.AddForce(Vector3.right * jumpSpeedRight, ForceMode.VelocityChange);
            yield return new WaitForSecondsRealtime(0.6f);
            rigidBodyBoss.AddForce(Vector3.down * jumpSpeedDown, ForceMode.VelocityChange);
            yield return new WaitForSecondsRealtime(0.6f);
            animaBoss.SetBool("bJump", false);
            //yield return new WaitForSecondsRealtime(1);

            estaSugando = true;

            /*if (vidaDoBoss.life <= 350)
            {
                estaSugando = true;

            }*/
            yield return new WaitForSecondsRealtime(8);
            podePular = true;
        }
    }

    IEnumerator puloEsquerda()
    {
        podePular = false;
        if (podePular == false)
        {
            animaBoss.SetBool("bJump", true);

            rigidBodyBoss.AddForce(Vector3.up * jumpSpeedUp, ForceMode.VelocityChange);
            yield return new WaitForSecondsRealtime(0.3f);
            rigidBodyBoss.AddForce(Vector3.left * jumpSpeedLeft, ForceMode.VelocityChange);
            yield return new WaitForSecondsRealtime(0.6f);
            rigidBodyBoss.AddForce(Vector3.down * jumpSpeedDown, ForceMode.VelocityChange);
            yield return new WaitForSecondsRealtime(0.6f);
            animaBoss.SetBool("bJump", false);
            //yield return new WaitForSecondsRealtime(1);

            estaSugando = true;

            /*if (vidaDoBoss.life <= 350)
            {
                estaSugando = true;
            }*/
            yield return new WaitForSecondsRealtime(9);
            podePular = true;
        }
    }

    //Cooldown
    /*IEnumerator cooldownPulo()
    {
        podePular = false;
        yield return new WaitForSecondsRealtime(3);
        podePular = true;
    }
    */
    
    IEnumerator cooldownCorte()
    {
        podeCortar = false;
        animaBoss.SetBool("bPull", false);
        yield return new WaitForSecondsRealtime(0.5f);
        animaBoss.SetInteger("Attack", 0);
        yield return new WaitForSecondsRealtime(3);

        if ((posicaoDoJogador.transform.position.x < posicaoDoBoss.transform.position.x))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        podeCortar = true;
    }

    void sorteiaAtaque()
    {
        chanceDeAtaque = Random.Range(1, 11);
        Debug.Log("Num: " + chanceDeAtaque);
    }

    public void corteRapido()
    {
        //Dash p/ ataque em direção ao player
        if (posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x)
        {
            animaBoss.SetInteger("Attack", 1);
            rigidBodyBoss.AddForce(Vector3.right * speedDashCorte, ForceMode.VelocityChange);
            estaSugando = false;
        }
        else
        {
            animaBoss.SetInteger("Attack", 1);
            rigidBodyBoss.AddForce(Vector3.left * speedDashCorte, ForceMode.VelocityChange);
            estaSugando = false;
        }
    }

    public void corteDuplo()
    {
        vidaPlayerScript.life -= danoDoCorteDuplo;
        //kbScript.active = true;
        fbPlayerScript.damage = true;

        //Dash p/ ataque em direção ao player
        if (posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x)
        {
            animaBoss.SetInteger("Attack", 3);
            rigidBodyBoss.AddForce(Vector3.right * speedDashCorte, ForceMode.VelocityChange);
        }
        else
        {
            animaBoss.SetInteger("Attack", 3);
            rigidBodyBoss.AddForce(Vector3.left * speedDashCorte, ForceMode.VelocityChange);
        }

    }

    public void cortePesado()
    {
        //Dash p/ ataque em direção ao player
        if (posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x)
        {
            animaBoss.SetInteger("Attack", 2);
            rigidBodyBoss.AddForce(Vector3.right * speedDashCorte, ForceMode.VelocityChange);
            estaSugando = false;
        }
        else
        {
            animaBoss.SetInteger("Attack", 2);
            rigidBodyBoss.AddForce(Vector3.left * speedDashCorte, ForceMode.VelocityChange);
            estaSugando = false;
        }
    }

    private void sugadaDirecao()
    {
        animaBoss.SetBool("bPull", true);
        if (posicaoDoJogador.transform.position.x < posicaoDoBoss.transform.position.x) //&& Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) > 2)
        {
            rigidBodyPlayer.AddForce(Vector3.left * sugada, ForceMode.Acceleration);
            scriptMovimentacao.speed = 1;
            
            Debug.Log("sugandoCorrotinaEsquerda");
        }
        if (posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x) //&& Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) > 2)
        {
            rigidBodyPlayer.AddForce(Vector3.left * sugada, ForceMode.Acceleration);
            scriptMovimentacao.speed = 1;
         
            Debug.Log("sugandoCorrotinaDireita");
        }
        animaBoss.SetBool("bPull", false);
        
    }

    IEnumerator animaHalfLife()
    {
        yield return new WaitForSecondsRealtime(0.75f);
        animaBoss.SetInteger("ContLife", contAnimLife);
        middleFightScream.SetActive(true);
    }

    IEnumerator ativaMovimentos()
    {
        pausaBoss = false;
        yield return new WaitForSecondsRealtime(2.5f);
        liberaAtaques = true;
        Debug.Log("Ataques liberados!");
    }
}
