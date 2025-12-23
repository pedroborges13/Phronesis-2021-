using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class damageBoss : MonoBehaviour
{
    public Animator bossAnimator;

    //Danos


    //Declarar scripts
    Boss bossScript;
    vidaPlayer vidaPlayerScript;
    feedbackPlayer fbPlayerScript;
    KnockBack kbScript;


    private void Start()
    {
        //Invocar Scripts
        bossScript = FindObjectOfType<Boss>();
        vidaPlayerScript = FindObjectOfType<vidaPlayer>();
        fbPlayerScript = FindObjectOfType<feedbackPlayer>();
        kbScript = GetComponent<KnockBack>();
    }
    private void OnTriggerEnter (Collider collider)
    {
        if (bossAnimator.GetCurrentAnimatorStateInfo(0).IsName("BossSimpleSlash"))
        {
            StartCoroutine(liberaKnockBack());
            if (collider.gameObject.tag == "Player")
            {
                Debug.Log("Chamou método1");
                bossScript.corteRapido();
                vidaPlayerScript.life -= bossScript.danoDoCorteLeve;
                cameraShakeBoss.instance.ShakeLeve();
            }
        }

        if (bossAnimator.GetCurrentAnimatorStateInfo(0).IsName("BossSlowSlash"))
        {
            StartCoroutine(liberaKnockBack());
            if (collider.gameObject.tag == "Player")
            {
                Debug.Log("Chamou método2");
                bossScript.cortePesado();
                vidaPlayerScript.life -= bossScript.danoDoCortePesado;
                cameraShakeBoss.instance.ShakeForte();
            }
        }
    }
    IEnumerator liberaKnockBack()
    {
        kbScript.active = true;
        yield return new WaitForSecondsRealtime(0.3f);
        kbScript.active = false;
    }
}
