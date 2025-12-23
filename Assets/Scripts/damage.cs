using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    vidaPlayer vidaPlayerScript;
    feedbackPlayer fbPlayerScript;
    KnockBack kbScript;
    public float damage1;
    public float damage2;
    public bool canDmg = false;
    //public float waitAttack;
    public GameObject player;

    private int aleatorio;
    //private float speedEnemy;
    // Start is called before the first frame update
    void Start()
    {
        vidaPlayerScript = FindObjectOfType<vidaPlayer>(); // CHAMANDO O SCRIPT "vidaPlayer"
        fbPlayerScript = FindObjectOfType<feedbackPlayer>();
        kbScript = GetComponent<KnockBack>();

        //speedEnemy = GetComponent<NavMeshAgent>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        aleatorio = Random.Range(0, 2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(aleatorio == 0)
        {
            if (collision.gameObject.tag == "Player" && canDmg)
            {
                Dano1();
                Debug.Log("Recebeu dano1");
                kbScript.active = true;             
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player" && canDmg) // LIMITA UM DANO CAUSADO POR ANIMAÇÃO DE ATAQUE
            {
                Dano2();
                Debug.Log("Recebeu dano2");
                kbScript.active = true;            
            }
        }
       
    }

    /*public void liberarDano() // LIBERA INIMIGO PARA CAUSAR DANO NOVAMENTE, NO FIM DA ANIMAÇÃO
    {
        canDmg = true;
        kbScript.active = true;
    }

    public void bloquearDano() // LIMITA INIMIGO PARA CAUSAR DANO SOMENTE DURANTE O ATAQUE
    {
        canDmg = false;
        kbScript.active = false;
    } */
    public void Dano1()
    {
        vidaPlayerScript.life -= damage1;
        CameraShake.instance.ShakeLeve();

        kbScript.active = true;
        fbPlayerScript.damage = true;
    }

    public void Dano2()
    {
        vidaPlayerScript.life -= damage2;
        CameraShake.instance.ShakeForte();

        kbScript.active = true;
        fbPlayerScript.damage = true;
    }
}
