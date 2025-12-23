using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnJuninho : MonoBehaviour
{
    public GameObject SpawnKid;
    public GameObject kidGame;

    

    TransicaoParaODia transicaoParaODia;

    void Start()
    {
        transicaoParaODia = FindObjectOfType<TransicaoParaODia>();
     
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnKid.gameObject.SetActive(true);
            kidGame.gameObject.SetActive(false);
            transicaoParaODia.ganchoTransicao += 1;
            Debug.Log("Cont = " + transicaoParaODia.ganchoTransicao);
            
        }
    }
}
