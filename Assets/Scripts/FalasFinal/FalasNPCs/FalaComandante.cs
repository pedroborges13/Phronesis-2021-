using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FalaComandante : ScriptableObject
{
    [TextArea(1, 10)]
    public string falaComandante;
    public RespostaComandante[] respostasComandante;
}
