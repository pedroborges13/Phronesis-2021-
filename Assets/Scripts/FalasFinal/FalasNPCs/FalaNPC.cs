using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FalaNPC : ScriptableObject
{
    [TextArea (1,10)]
    public string fala;
    public RespostaKid[] respostas;
}
