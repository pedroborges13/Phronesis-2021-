using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButtonComandante : MonoBehaviour
{
    RespostaComandante respostaData;

    public void ProximaFala()
    {
        FindObjectOfType<ComandanteController>().ProximaFalaComandante(respostaData.proximaFalaComandante);
    }

    public void Setup (RespostaComandante respostaComandante)
    {
        respostaData = respostaComandante;
    }
}
