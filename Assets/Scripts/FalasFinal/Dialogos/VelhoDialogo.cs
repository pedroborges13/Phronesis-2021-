using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelhoDialogo : MonoBehaviour
{
    public FalaVelho[] falona = new FalaVelho[2];

    private bool dialoguinhoConcluido = false;

    Movimentacao movScript;

    Combos combosScript;

    VelhoController dialogoVelhoController;

    void Start()
    {
        dialogoVelhoController = FindObjectOfType<VelhoController>();
        movScript = FindObjectOfType<Movimentacao>();
        combosScript = FindObjectOfType<Combos>();
    }

    void OnTriggerStay(Collider otheer)
    {
        if (otheer.CompareTag("Player"))
        {
            if (dialoguinhoConcluido == false)
            {
                dialogoVelhoController.ProximaFalaVelho(falona[0]);
            }
            else
            {
                dialogoVelhoController.ProximaFalaVelho(falona[1]);
            }
            dialoguinhoConcluido = true;
        }
    }
}
