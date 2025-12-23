using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    private GameObject player;
    public NavMeshAgent agent;
    public float distance;
    
    
    void Start()
    {
        // Inimigo encontra o player pela tag
        player = GameObject.FindWithTag("Player");
        
    }

    
    void Update()
    {
        // ======================================= MOVIMENTAÇÃO DOS INIMIGOS =========================================

        // Segue o jogador a partir de uma determinada distância
        if (Vector3.Distance(transform.position, player.transform.position) <= distance)
         {
            agent.destination = player.transform.position;
            agent.isStopped = false;

            GetComponent<Animator>().SetBool("bRun", true);
            GetComponent<Animator>().SetBool("bIdle", false);
        }

        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Attacking")) // DEIXA O INIMIGO PARADO ENQUANTO ATACA
        {
            agent.isStopped = true;
        }

        if (Vector3.Distance(transform.position, player.transform.position) > distance)
         {
            GetComponent<Animator>().SetBool("bRun", false);
            GetComponent<Animator>().SetBool("bIdle", true);
         }

        // =============================================================================================================
    }
}
