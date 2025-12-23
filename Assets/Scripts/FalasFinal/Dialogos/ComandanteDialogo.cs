using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComandanteDialogo : MonoBehaviour
{
    public FalaComandante[] falasComandante = new FalaComandante[2];

    private bool dialogoConcluidoComandante = false;

    Movimentacao movScript;

    Combos combosScript;

    ComandanteController dialogoComandanteController;

    void Start()
    {
        dialogoComandanteController = FindObjectOfType<ComandanteController>();
        movScript = FindObjectOfType<Movimentacao>();
        combosScript = FindObjectOfType<Combos>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {          
            if (dialogoConcluidoComandante == false)
            {
                dialogoComandanteController.ProximaFalaComandante(falasComandante[0]);
            }
            else
            {
                dialogoComandanteController.ProximaFalaComandante(falasComandante[1]);
            }
            dialogoConcluidoComandante = true;
        }
    }
}
