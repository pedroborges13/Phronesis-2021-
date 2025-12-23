using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FalaMendigo : ScriptableObject
{
    [TextArea(1, 10)]
    public string falaMendigo;
    public RespostaMendigo[] respostasMendigo;
}
