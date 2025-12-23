//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RespostaVelho
{
    [TextArea(1, 10)]
    public string respostaaa;

    public FalaVelho proximaFalaVelho;

    /*public static implicit operator RespostaVelho(RespostaKid v)
    {
        throw new NotImplementedException();
    }*/
}
