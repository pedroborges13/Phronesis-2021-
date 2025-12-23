using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Dialogos
{
    [SerializeField]
    private TextoDialogo[] frases;

    [SerializeField]
    private string nomeNpc;

    public TextoDialogo[] GetFrases()
    {
        return frases;
    }

    public string GetNomeNPC ()
    {
        return nomeNpc;
    }
}
