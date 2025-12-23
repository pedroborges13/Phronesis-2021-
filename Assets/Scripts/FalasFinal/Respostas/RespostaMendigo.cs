using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RespostaMendigo
{
    [TextArea(1, 10)]
    public string respostaMendigo;

    public FalaMendigo proximaFalaMendigo;
}
