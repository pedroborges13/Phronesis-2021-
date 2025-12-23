using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicializadorDialogo : MonoBehaviour
{
    [SerializeField]
    private GerenciadorDialogo gerenciador;
    [SerializeField]
    private Dialogos dialogo;

    public void Inicializa()
    {
        if (gerenciador == null)       
            return;

        gerenciador.Inicializa(dialogo);
        
    }
}
