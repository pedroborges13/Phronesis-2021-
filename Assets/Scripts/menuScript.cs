using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuScript : MonoBehaviour
{
    public Fade fadeScript;
    public gameManager gameManagerScript;
    public GameObject MenuOpcoes;
    vidaPlayer vidaPlayerScript;
    //public GameObject logo;
    //public GameObject capa;
    //public Text mensagem;
    //gameManagerScript = FindObjectOfType<gameManager>();

    private void Start()
    {
        MenuOpcoes.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        vidaPlayerScript = FindObjectOfType<vidaPlayer>();
        
        //vidaPlayerScript.death = 0;
    }
    //Clique no botao para alterar cena para jogo
    public void OnClickButtonPlay()
    {
        fadeScript.Transition("Introducao");
    }

    //Clique no botao para alterar cena para tela de opcoes
    public void OnClickButtonOptions()
    {
        MenuOpcoes.SetActive(true);
    }

    public void OnClickButtonFechar()
    {
        MenuOpcoes.SetActive(false);
    }

    public void OnClickButtonLoad()
    {
        gameManagerScript.Load();
    }
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            //capa.SetActive(false);
            //logo.color = new Color(capa.color.r, capa.color.g, capa.color.b, 0.1f);
        }
    }
}
