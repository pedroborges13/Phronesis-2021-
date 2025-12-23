using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButtonMendigo : MonoBehaviour
{
    RespostaMendigo respostaData;

    public void ProximaFala()
    {
        FindObjectOfType<MendigoController>().ProximaFalaMendigo(respostaData.proximaFalaMendigo);
    }

    public void Setup (RespostaMendigo respostaMendigo)
    {
        respostaData = respostaMendigo;
    }
}
