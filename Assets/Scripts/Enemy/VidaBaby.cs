using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VidaBaby : MonoBehaviour
{
    public float life = 100f;
    private int dead = 0;

    public AudioSource audioSourceMonster;

    private GameObject player;
    private NavMeshAgent navEnemy;
    public float expValue;
    public bool inimigoMorto = false;

    EnemyBaby enemyScript;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyScript = GetComponent<EnemyBaby>();
        navEnemy = GetComponent<NavMeshAgent>();

    }

    void FixedUpdate()
    {
        if (life <= 0f)
        {
            dead++;
            GetComponent<Animator>().SetInteger("Death", dead);

            StartCoroutine(enemyDeath(2.0f));
            inimigoMorto = true;

        }
        if (inimigoMorto == true)
        {
            inimigoMorto = false;
        }
    }

    IEnumerator enemyDeath(float tempo)
    {
        GetComponent<Animator>().SetInteger("Death", dead);
        //audioSourceMonster.Play();
        //enemyScript.enabled = false;
        //navEnemy.enabled = false;
        yield return new WaitForSeconds(tempo);
        audioSourceMonster.Play();
        Destroy(gameObject);
    }
}