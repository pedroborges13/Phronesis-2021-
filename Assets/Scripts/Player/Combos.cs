using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combos : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;

    public GameObject soundAt1, soundAt3;

    public CapsuleCollider colliderArma;

    public CapsuleCollider colliderArma2;

    public int clicks;
    public bool canClick;
    private bool firstAttack, secondAttack, thirdAttack;

    Movimentacao movScript;
    WeaponSwitching weaponIdScript;
    dashMove dashScript;
    PlayerJump jumpScript;

    //public int contador;
    public bool podeBater = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        clicks = 0;
        canClick = true;

        movScript = FindObjectOfType<Movimentacao>();
        weaponIdScript = FindObjectOfType<WeaponSwitching>();
        dashScript = FindObjectOfType<dashMove>();
        jumpScript = FindObjectOfType<PlayerJump>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetInteger("IdArma", weaponIdScript.selectedWeapon);
        AttackState();

        if (clicks > 3)
        {
            clicks = 3;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("standUp") || animator.GetCurrentAnimatorStateInfo(0).IsName("Strech"))
        {
            movScript.enabled = false;
            jumpScript.enabled = false;
            dashScript.enabled = false;
        }
        else
        {
            movScript.enabled = true;
            jumpScript.enabled = true;
            dashScript.enabled = true;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump") || animator.GetCurrentAnimatorStateInfo(0).IsName("standUp") || animator.GetCurrentAnimatorStateInfo(0).IsName("Strech") || Time.timeScale == 0)
        {
            canClick = false;
        }
        else
        {
            canClick = true;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attacking"))
        {
            movScript.enabled = false;
            jumpScript.enabled = false;
            GetComponent<AudioSource>().Stop();
        }
        else
        {
            movScript.enabled = true;
            jumpScript.enabled = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //Ao atacar vem um bloqueio de 0.35 sec, após esse tempo é permitido um outro click para o segundo ataque, e o mesmo serve para o terceiro.
            if (podeBater == true)
            {
                Combo();
                //A coroutine é o que chama o bloqueio através da bool "podeBater".
                StartCoroutine(controleCombo());
            }
        }
    }

    void Combo()
    {
        if (canClick)
        {
            clicks++;
        }
        if (clicks == 1)
        {
            animator.SetInteger("Attack", 1);

            soundAt1.GetComponent<AudioSource>().PlayDelayed(0.15f);
        }
    }

    void ComboManager()
    {
        canClick = false;

        if(firstAttack && clicks == 1)
        {
            clicks = 0;
            animator.SetInteger("Attack", 0);
            canClick = true;
        }
        else if (firstAttack && clicks >= 2)
        {
            animator.SetInteger("Attack", 2);
            canClick = true;

            soundAt1.GetComponent<AudioSource>().Play();
        }
        else if (secondAttack && clicks == 2)
        {
            clicks = 0;
            animator.SetInteger("Attack", 0);
            canClick = true;
        }
        else if (secondAttack && clicks >= 3)
        {
            animator.SetInteger("Attack", 3);
            canClick = true;

            soundAt1.GetComponent<AudioSource>().PlayDelayed(0.5f);
        }
        else if (thirdAttack)
        {
            clicks = 0;
            animator.SetInteger("Attack", 0);
            canClick = true;
        }
        else
        {
            clicks = 0;
            canClick = true;
        }
    }

    public void ativarCol()
    {
        colliderArma.enabled = true;
        colliderArma2.enabled = true;
    }

    public void desativarCol()
    {
        colliderArma.enabled = false;
        colliderArma2.enabled = false;
    }

    public void AttackState() // Verifica em qual ataque está, independente da arma
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("AttackAxe_1") || animator.GetCurrentAnimatorStateInfo(0).IsName("AttackPipe_1"))
        {
            firstAttack = true;
        }
        else
        {
            firstAttack = false;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("AttackAxe_2") || animator.GetCurrentAnimatorStateInfo(0).IsName("AttackPipe_2"))
        {
            secondAttack = true;
        }
        else
        {
            secondAttack = false;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("AttackAxe_3") || animator.GetCurrentAnimatorStateInfo(0).IsName("AttackPipe_3"))
        {
            thirdAttack = true;
        }
        else
        {
            thirdAttack = false;
        }
    }

    IEnumerator controleCombo()
    {
        //É chamada ao clicar com o botão de ataque.
        podeBater = false;
        yield return new WaitForSecondsRealtime(0.35f);
        podeBater = true;
    }
}
