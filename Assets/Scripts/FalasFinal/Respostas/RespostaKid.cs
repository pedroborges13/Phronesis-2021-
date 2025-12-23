using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RespostaKid
{
    [TextArea(1, 10)]
    public string resposta;

    public FalaNPC proximaFala;
}
