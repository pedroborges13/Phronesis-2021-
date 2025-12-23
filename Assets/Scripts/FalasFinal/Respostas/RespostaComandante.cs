using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RespostaComandante
{
    [TextArea(1, 10)]
    public string respostaComandante;

    public FalaComandante proximaFalaComandante;
}
