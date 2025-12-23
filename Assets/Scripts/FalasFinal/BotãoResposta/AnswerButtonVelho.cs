using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButtonVelho : MonoBehaviour
{
    RespostaVelho respostaData;

    public void ProximaFala()
    {
        FindObjectOfType<VelhoController>().ProximaFalaVelho(respostaData.proximaFalaVelho);
    }

    public void Setup(RespostaVelho respostaa)
    {
        respostaData = respostaa;
    }
}
