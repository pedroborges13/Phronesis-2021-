using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MendigoDialogo : MonoBehaviour
{
    public FalaMendigo[] falasMendigo = new FalaMendigo[2];

    private bool dialogoConcluidoMendigo = false;

    Movimentacao movScript;

    Combos combosScript;

    MendigoController dialogoMendigoController;

    void Start()
    {
        dialogoMendigoController = FindObjectOfType<MendigoController>();
        movScript = FindObjectOfType<Movimentacao>();
        combosScript = FindObjectOfType<Combos>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (dialogoConcluidoMendigo == false)
            {
                dialogoMendigoController.ProximaFalaMendigo(falasMendigo[0]);
            }
            else
            {
                dialogoMendigoController.ProximaFalaMendigo(falasMendigo[1]);
            }
            dialogoConcluidoMendigo = true;
        }
    }
}
