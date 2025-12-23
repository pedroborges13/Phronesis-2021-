using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditosMenu : MonoBehaviour
{
    public GameObject creditos;

    void Update()
    {
        if(Input.anyKey)
        {
            creditos.SetActive(false);
        }
    }

    public void ativarCredito()
    {
        creditos.SetActive(true);
    }
}
