using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class GerenciadorDialogo : MonoBehaviour
{
    [SerializeField]
    private Text nomeNPC;
    [SerializeField]
    private Text texto;
    [SerializeField]
    private Text botaoContinuar;

    [SerializeField]
    private GameObject caixaDialogo;

    private int contador = 0;
    private Dialogos dialogoAtual;

    public void Inicializa(Dialogos dialogo)
    {
        contador = 0;
        dialogoAtual = dialogo;
        ProximaFrase();
        
    }

    private void ProximaFrase()
    {
        if (dialogoAtual == null)
            return;
        if (contador == dialogoAtual.GetFrases().Length)
        {
            caixaDialogo.gameObject.SetActive(false);
            dialogoAtual = null;
            contador = 0;
            return;
        }

        nomeNPC.text = dialogoAtual.GetNomeNPC();
        texto.text = dialogoAtual.GetFrases()[contador].GetFrase();
        botaoContinuar.text = dialogoAtual.GetFrases()[contador].GetBotaoContinuar();
        caixaDialogo.gameObject.SetActive(true);
        contador++;
    }
}
