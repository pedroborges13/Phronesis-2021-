using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dashMove : MonoBehaviour
{
    public ParticleSystem effect;
    private Rigidbody rb;
    private int direction;
    public float dashSpeed;
    public float cooldown;
    public bool canDash = true;
    private Animator animator;
    //public timeManager TimeManager;
    public Image signalDash;
    public float coolDownIcon = 1f;
    public bool isCoolDownIcon = false;

    Combos combosScript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        signalDash.fillAmount = 0;

        this.animator = GetComponent<Animator>();
        combosScript = FindObjectOfType<Combos>();
    }

    // Update is called once per frame
    void Update()
    {
        CDDASHICON();
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.D) && canDash) // REALIZANDO DASH
        {
            this.animator.SetBool("bDash", true);
            transform.position += Vector3.right * dashSpeed;
            CreatEffect();
            //TimeManager.SlowMotion();
            

            StartCoroutine(esperarCD(cooldown));
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.A) && canDash) // REALIZANDO DASH INVERTIDO
        {
            this.animator.SetBool("bDash", true);
            transform.position += Vector3.left * dashSpeed;
            CreatEffect();
            //TimeManager.SlowMotion();
            

            StartCoroutine(esperarCD(cooldown));
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash) // REALIZANDO DASH
        {
            this.animator.SetBool("bDash", true);
            transform.position += transform.forward * dashSpeed;
            CreatEffect();
            //TimeManager.SlowMotion();
            


            StartCoroutine(esperarCD(cooldown));
        }
    }

    IEnumerator esperarCD(float tempo)
    {
        animator.SetInteger("Attack", 0);
        combosScript.canClick = true;
        combosScript.clicks = 0;
        combosScript.colliderArma.enabled = false;
        combosScript.colliderArma2.enabled = false;

        canDash = false;
        

        yield return new WaitForSeconds(tempo);
        canDash = true;
        
    }

    void CDDASHICON()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.D) && canDash || Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.A) && canDash || Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            isCoolDownIcon = true;
            signalDash.fillAmount = 1;
        }
        if (isCoolDownIcon)
        {
            signalDash.fillAmount -= 1 / coolDownIcon * Time.deltaTime;
            if (signalDash.fillAmount <= 0)
            {
                signalDash.fillAmount = 0;
                isCoolDownIcon = false;
            }
        }
    }

    void CreatEffect()
    {
        effect.Play();
    }
}
