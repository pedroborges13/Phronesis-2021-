using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidDialogo : MonoBehaviour
{
    public FalaNPC[] falas = new FalaNPC[2];

    private bool dialogoConcluido = false;

    Movimentacao movScript;

    Combos combosScript;

    KidController dialogoKidController;

    void Start()
    {
        dialogoKidController = FindObjectOfType<KidController>();
        movScript = FindObjectOfType<Movimentacao>();
        combosScript = FindObjectOfType<Combos>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {          
            if (dialogoConcluido == false)
            {
                dialogoKidController.ProximaFala(falas[0]);
            }
            else
            {
                dialogoKidController.ProximaFala(falas[1]);
            }
            dialogoConcluido = true;

        }

    }
}
