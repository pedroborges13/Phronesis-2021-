using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PensamentoSozinho : MonoBehaviour
{
    public GameObject _textPensamento;

    dashMove dashScript;
    PlayerJump jumpScript;
    Combos attackScript;

    public AudioSource runSound;

    public GameObject painelDialogoSozinho;
    public GameObject iconePlayer;

    TransicaoParaODia transicaoParaODia;

    public bool pensamentoTrueFalse = true;

    public Text falaSozinho;
    void Start()
    {
        transicaoParaODia = FindObjectOfType<TransicaoParaODia>();

        _textPensamento.SetActive(true);

        dashScript = FindObjectOfType<dashMove>();
        jumpScript = FindObjectOfType<PlayerJump>();
        attackScript = FindObjectOfType<Combos>();
    }

    void OnTriggerStay (Collider other)
    {
        if (other.CompareTag("Player") && pensamentoTrueFalse == true)
        {
            StartCoroutine(aparecerPensamento());
        }
    }
    IEnumerator aparecerPensamento()
    {
        painelDialogoSozinho.SetActive(true);
        iconePlayer.SetActive(true);
        yield return new WaitForSecondsRealtime(4);
        painelDialogoSozinho.SetActive(false);
        iconePlayer.SetActive(false);
        pensamentoTrueFalse = false;
    }
}


