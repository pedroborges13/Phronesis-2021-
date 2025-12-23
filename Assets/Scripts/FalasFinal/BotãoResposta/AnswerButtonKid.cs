using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButtonKid : MonoBehaviour
{
    RespostaKid respostaData;

   public void ProximaFala()
    {
        FindObjectOfType<KidController>().ProximaFala(respostaData.proximaFala);
    }
    

    public void Setup (RespostaKid resposta)
    {
        respostaData = resposta;
    }
}
