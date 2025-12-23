using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class DamageBaby : MonoBehaviour
{
    vidaPlayer vidaPlayerScript;
    feedbackPlayer fbPlayerScript;
    //KnockBack kbScript;

    public float damage;
    private int aleatorio;
    public GameObject player;

   

    void Start()
    {
        vidaPlayerScript = FindObjectOfType<vidaPlayer>(); // CHAMANDO O SCRIPT "vidaPlayer"
        fbPlayerScript = FindObjectOfType<feedbackPlayer>();
        //kbScript = GetComponent<KnockBack>();

        
    }

    // ------------------------------------ ATAQUES INIMIGO -----------------------------------------
    public void Dano()
    {
        vidaPlayerScript.life -= damage;
        CameraShake.instance.ShakeLeve();

        //kbScript.active = true;
        fbPlayerScript.damage = true;
    }



    // -----------------------------------------------------------------------------------------------

    void OnCollisionEnter(Collision collider) // O DANO É CAUSADO AO INIMIGO COLIDIR COM O JOGADOR
    {
        if (collider.gameObject.tag == "Player")
        {
       
            Dano();
            Debug.Log("Recebeu dano");
            //kbScript.active = true;      
        }

        if (collider.gameObject.tag != "Baby")
        {
            Destroy(gameObject);
        }
    }

    
}
