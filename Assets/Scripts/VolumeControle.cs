using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControle : MonoBehaviour
{
    public float volumeMaster=1, volumeEfeito=1, volumeMusica=1;
  
    void Start()
    {
        if(ValorCenas.volumeGeral != 1)
        {
            volumeMaster = ValorCenas.volumeGeral;
        }
        if (ValorCenas.volumeEfeito != 1)
        {
            volumeEfeito = ValorCenas.volumeEfeito;
        }
        if (ValorCenas.volumeMusica != 1)
        {
            volumeMusica = ValorCenas.volumeMusica;
        }

        
    }

    void Update()
    {
        ValorCenas.volumeGeral = volumeMaster;
        ValorCenas.volumeEfeito = volumeEfeito;
        ValorCenas.volumeMusica = volumeMusica;
    }

    public void VolumeMaster (float volume)
    {
        volumeMaster = volume;
        AudioListener.volume = volumeMaster;
    }

    public void VolumeEfeito (float volume)
    {
        volumeEfeito = volume;
        GameObject[] Fxs = GameObject.FindGameObjectsWithTag("FX");
        for(int i=0; i<Fxs.Length; i++)
        {
            Fxs[i].GetComponent<AudioSource>().volume = volumeEfeito;
        }

        GameObject[] Fxs1 = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < Fxs1.Length; i++)
        {
            Fxs1[i].GetComponent<AudioSource>().volume = volumeEfeito;
        }
    }

    public void VolumeMusica (float volume)
    { 
        volumeMusica = volume;
        GameObject[] Musicas = GameObject.FindGameObjectsWithTag("Musica");
        for (int i=0; i<Musicas.Length; i++)
        {
            Musicas[i].GetComponent<AudioSource>().volume = volumeMusica;
        }

        
    }
}
