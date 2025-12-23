using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TextoDialogo
{
    [SerializeField]
    [TextArea(1,10)]
    private string frase;

    [SerializeField]
    private string botaoContinuar;

    public string GetFrase()
    {
        return frase;
    }

    public string GetBotaoContinuar()
    {
        return botaoContinuar;
    }
}
