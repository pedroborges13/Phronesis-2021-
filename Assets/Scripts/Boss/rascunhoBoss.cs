using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RascunhoBoss : MonoBehaviour
{

    vidaPlayer vidaPlayerScript;
    feedbackPlayer fbPlayerScript;
    KnockBack kbScript;
    vidaBoss vidaDoBoss;
    Movimentacao scriptMovimentacao;
    dashMove scriptDash;

    //private Transform posicaoDoJogador;
    public float velocidadeBoss;
    public float campoPercepcao;

    public float danoCorteRapido;
    public float danoCortePuxao;

    private Transform posicaoDoJogador;
    private Transform posicaoDoBoss;
    //public GameObject player;
    //private posicaoJogador;

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

    //Permissões
    private bool podePular = true;
    private bool podeCortar = true;
    public bool estaSugando = false;

    //Dano
    public float danoDoCorte;
    public float danoDoCortePesado;
    public float danoDaInvestida;
    private int chanceDeAtaque;

    void Start()
    {
        //Pegar posição do Player e Boss
        posicaoDoJogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        posicaoDoBoss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Transform>();

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
        if (Input.GetKey(KeyCode.L))
        {
            if (posicaoDoJogador.transform.position.x < posicaoDoBoss.transform.position.x) //&& Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) > 2)
            {
                rigidBodyPlayer.AddForce(Vector3.right * sugada, ForceMode.Acceleration);
                scriptMovimentacao.speed = 1;
                Debug.Log("sugandoCorrotinaEsquerda");
                scriptDash.enabled = false;
            }
            else //(posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x)//&& Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) > 2)
            {
                rigidBodyPlayer.AddForce(Vector3.left * sugada, ForceMode.Acceleration);
                scriptMovimentacao.speed = 1;
                Debug.Log("sugandoCorrotinaDireita");
                scriptDash.enabled = false;
            }
        }
        if (estaSugando == true)
        {
            if (posicaoDoJogador.transform.position.x < posicaoDoBoss.transform.position.x) //&& Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) > 2)
            {
                rigidBodyPlayer.AddForce(Vector3.right * sugada, ForceMode.Acceleration);
                scriptMovimentacao.speed = 1;
                Debug.Log("sugandoCorrotinaEsquerda");
                scriptDash.enabled = false;
            }
            else //(posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x)//&& Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) > 2)
            {
                rigidBodyPlayer.AddForce(Vector3.left * sugada, ForceMode.Acceleration);
                scriptMovimentacao.speed = 1;
                Debug.Log("sugandoCorrotinaDireita");
                scriptDash.enabled = false;
            }
        }
        else
        {
            scriptDash.enabled = true;
            scriptMovimentacao.speed = 5;
        }
        //transform.Translate(Vector2.right * velocidadeBoss * )
        if (vidaDoBoss.life >= 85)
        {
            Debug.Log("Vida acima de 50");
            //Pular para a direita
            if (podePular == true && Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) > 10 && posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x) //FUNCIONA
            {
                sorteiaAtaque();
                if (chanceDeAtaque <= 7)
                {
                    StartCoroutine(puloDireita());
                    chanceDeAtaque = 0;
                }

                ///StartCoroutine(cooldownPulo());
                //sugadaEsquerda();
            }

            //Pular para a esquerda
            if (podePular == true && Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) > 10 && posicaoDoJogador.transform.position.x < posicaoDoBoss.transform.position.x) //FUNCIONA
            {
                sorteiaAtaque();
                if (chanceDeAtaque <= 7)
                {
                    StartCoroutine(puloEsquerda());
                    chanceDeAtaque = 0;
                }

                //StartCoroutine(cooldownPulo());
                //sugadaEsquerda();
            }

            //Cortar
            if (podeCortar == true && Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) < 3)
            {
                StartCoroutine(cooldownCorte());
                corteRapido();
                Debug.Log("cortou!");
            }

            if (Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) < 10 && posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x) //FUNCIONA
            {
                Debug.Log("Ativa Sugada");
                //StartCoroutine(puloEsquerda());
                //StartCoroutine(cooldownPulo());
                //StartCoroutine(ativaSugada());
            }
            /*if (podePular == true)
            {
                StartCoroutine(puloEsquerda());
                StartCoroutine(cooldownPulo());
            }*/
            //Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) < 10 && posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x) //FUNCIONA
            /* {
             Debug.Log("Ativa Sugada");
             StartCoroutine(puloEsquerda());
             //StartCoroutine(cooldownPulo());
             StartCoroutine(ativaSugada());
         }*/
        }
        else
        {
            Debug.Log("Vida abaixo de 50, cuidado!");
            if (podePular == true && Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) > 6 && posicaoDoJogador.transform.position.x < posicaoDoBoss.transform.position.x) //FUNCIONA
            {
                Debug.Log("Pula p/ Esquerda");
                StartCoroutine(puloEsquerda());
                StartCoroutine(cooldownPulo());
                //StartCoroutine(ativaSugada());
                //SCRIPT PROIBIDO COM WHILE
                /*if (Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) < 10 && posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x) //FUNCIONA
                {
                    Debug.Log("Ativa Sugada");
                    StartCoroutine(ativaSugada());
                }*/
            }
        }
    }

    //Controlar direção dos pulos
    IEnumerator puloDireita()
    {
        podePular = false;
        if (podePular == false)
        {
            //yield return new WaitForSecondsRealtime(1);
            rigidBodyBoss.AddForce(Vector3.up * jumpSpeedUp, ForceMode.VelocityChange);
            yield return new WaitForSecondsRealtime(0.3f);
            rigidBodyBoss.AddForce(Vector3.right * jumpSpeedRight, ForceMode.VelocityChange);
            yield return new WaitForSecondsRealtime(0.5f);
            rigidBodyBoss.AddForce(Vector3.down * jumpSpeedDown, ForceMode.VelocityChange);
            yield return new WaitForSecondsRealtime(2);
            rigidBodyPlayer.AddForce(Vector3.left * sugada, ForceMode.Acceleration);
            yield return new WaitForSecondsRealtime(2);
            podePular = true;
        }
    }

    IEnumerator puloEsquerda()
    {
        podePular = false;
        if (podePular == false)
        {
            yield return new WaitForSecondsRealtime(1);
            rigidBodyBoss.AddForce(Vector3.up * jumpSpeedUp, ForceMode.VelocityChange);
            yield return new WaitForSecondsRealtime(0.3f);
            rigidBodyBoss.AddForce(Vector3.left * jumpSpeedLeft, ForceMode.VelocityChange);
            yield return new WaitForSecondsRealtime(0.5f);
            rigidBodyBoss.AddForce(Vector3.down * jumpSpeedDown, ForceMode.VelocityChange);
            yield return new WaitForSecondsRealtime(2);
            //sugadaDirecao();
            estaSugando = true;
            yield return new WaitForSecondsRealtime(2);
            podePular = true;
        }
    }

    //Cooldown
    IEnumerator cooldownPulo()
    {
        podePular = false;
        yield return new WaitForSecondsRealtime(8);
        podePular = true;
    }

    IEnumerator cooldownCorte()
    {
        podeCortar = false;
        yield return new WaitForSecondsRealtime(2);
        podeCortar = true;
    }

    void sorteiaAtaque()
    {
        chanceDeAtaque = Random.Range(1, 11);
        Debug.Log("Num: " + chanceDeAtaque);
    }

    /*IEnumerator ativaSugada()
    {
        yield return new WaitForSecondsRealtime(0.5f);

        if (posicaoDoJogador.transform.position.x < posicaoDoBoss.transform.position.x && Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) > 2)
        {
            sugadaEsquerda();
            scriptMovimentacao.speed = 1;
            Debug.Log("sugandoCorrotinaEsquerda");
        }
        if (posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x && Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) > 2)
        {
            sugadaDireita();
            scriptMovimentacao.speed = 1;
            Debug.Log("sugandoCorrotinaDireita");

        }
    }
    */
    private void corteRapido()
    {
        vidaPlayerScript.life -= danoDoCorte;
        kbScript.active = true;
        fbPlayerScript.damage = true;

        //Dash p/ ataque em direção ao player
        if (posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x)
        {
            //GetComponent<Animator>().SetInteger("CorteBoss", 1);
            rigidBodyBoss.AddForce(Vector3.right * speedDashCorte, ForceMode.VelocityChange);
        }
        else
        {
            //GetComponent<Animator>().SetInteger("CorteBoss", 1);
            rigidBodyBoss.AddForce(Vector3.left * speedDashCorte, ForceMode.VelocityChange);
        }
    }

    private void cortePesado()
    {

    }



    private void sugadaDirecao()
    {
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
    }
    /* private void sugadaEsquerda()
     {
         Debug.Log("Sugada esquerda");
         rigidBodyPlayer.AddForce(Vector3.left * sugada, ForceMode.Acceleration);
     }

     private void sugadaDireita()
     {
         Debug.Log("Sugada direita");
         rigidBodyPlayer.AddForce(Vector3.left * sugada, ForceMode.Acceleration);
     }
     */
    /* private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            corteRapido();
        }
    }
    */
    /*Tela (transform) - Jogador 
    if (Vector2.Distance(transform.position, posicaoDoJogador.position) > 5)
    {
        Debug.Log("Tela - Jogador > 5");
    }
    if (Vector2.Distance(transform.position, posicaoDoJogador.position) < 5)
    {
        Debug.Log("Tela - Jogador < 5");
    }

    //Jogador - Tela (transform)
    if (Vector2.Distance(posicaoDoJogador.position, transform.position) > 5)
    {
        Debug.Log("Jogador-Tela > 5");
    }
    if (Vector2.Distance(posicaoDoJogador.position, transform.position) < 5)
    {
        Debug.Log("Jogador-Tela < 5");
    }

    //Boss - Jogador
    if (Vector2.Distance(posicaoDoBoss.position, posicaoDoJogador.position) < 5)
    {
        Debug.Log("Boss - Jogador if 4");
    }
    */
}
