using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyBaby : MonoBehaviour
{
    NavMeshAgent agent;
    Transform goal;
    public Transform posicaoBaby;

    public float distTiro;
    public GameObject vomito;
    public Transform shootPoint;
    bool isShooting;
    public GameObject enemyBaby;

    private Animator animaBaby;

    public Rigidbody rigidBodyVomito;
    public float velocidadeDisparo;
    
     

    GameObject clone;



    void Awake()
    {
        

        
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        goal = GameObject.FindGameObjectWithTag("Player").transform;
        animaBaby = enemyBaby.GetComponent<Animator>();   
    }


    void Update()
    {

        if(agent.isStopped == true)
        {
            animaBaby.SetBool("bRun", false);
            animaBaby.SetBool("bIdle", true);
        }
        else
        {
            animaBaby.SetBool("bRun", true);
            animaBaby.SetBool("bIdle", false);
        }

        // ======================================= MOVIMENTAÇÃO DO INIMIGO =========================================

        float distance = Vector3.Distance(transform.position, goal.position);
        if(distance <= distTiro)
        {
            agent.destination = goal.transform.position;
            
            if (!isShooting)
            {
                InvokeRepeating("ShootBullet", 1.5f, 2.5f);
                //StartCoroutine(shootBullet2());
                isShooting = true;
                //Destroy(vomito.gameObject, 6f);
            }
            
        }
        else
        {
            CancelInvoke("ShootBullet");
            isShooting = false;
        }
        
       
            
     }
        
        // =============================================================================================================
 

    void ShootBullet()
    {
        StartCoroutine(WaitMov());
        clone = Instantiate(vomito, shootPoint.position, shootPoint.rotation);
        if (goal.transform.position.x > posicaoBaby.transform.position.x)
        {
            clone.GetComponent<Rigidbody>().AddForce(new Vector3(velocidadeDisparo, 3, 0), ForceMode.VelocityChange);
        }
        else
        {
            clone.GetComponent<Rigidbody>().AddForce(new Vector3(-velocidadeDisparo, 3 ,0), ForceMode.VelocityChange);
        }
        //rigidBodyVomito.AddForce(Vector3.right * velocidadeDisparo, ForceMode.VelocityChange);
        //Destroy(vomito.gameObject, 6f);
    }

    IEnumerator WaitMov()
    {
        agent.isStopped = true;
        yield return new WaitForSecondsRealtime(0.65f);
        agent.isStopped = false;
    }


    /*IEnumerator shootBullet2()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Instantiate(vomito, shootPoint.position, shootPoint.rotation);
        yield return new WaitForSecondsRealtime(0.25f);
        //vomito.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(velocidadeDisparo, velocidadeDisparo, velocidadeDisparo));
        rigidBodyVomito.AddForce(Vector3.right * velocidadeDisparo, ForceMode.VelocityChange);
        Debug.Log("a");
    }
    */
}
