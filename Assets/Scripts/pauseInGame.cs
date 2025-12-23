using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseInGame : MonoBehaviour
{

    private bool paused = false;

    public GameObject telaPause, hud, MenuOpcoes, dashIcon,weaponIcon;

    public Fade fadeScript;

    public AudioSource runSound;

    Movimentacao movScript;
    Combos combosScript;
    dashMove dashScript;
    PlayerJump jumpScript;

    void Start()
    {
        telaPause.SetActive(false);

        MenuOpcoes.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;

        movScript = FindObjectOfType<Movimentacao>();
        combosScript = FindObjectOfType<Combos>();
        dashScript = FindObjectOfType<dashMove>();
        jumpScript = FindObjectOfType<PlayerJump>();
    }

    void Update()
    {
        //Pausando/Despausando com Esc
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                telaPause.SetActive(false);
                hud.SetActive(true);
                dashIcon.SetActive(true);
                weaponIcon.SetActive(true);
                paused = false;

                movScript.enabled = true;
                combosScript.enabled = true;
                jumpScript.enabled = true;
                dashScript.enabled = true;
            }
        }

        //Ativando Menu de pause
        if (paused)
        {
            telaPause.SetActive(true);
            hud.SetActive(false);
            dashIcon.SetActive(false);
            weaponIcon.SetActive(false);
            Cursor.lockState = CursorLockMode.None;

            runSound.Stop();
        }
    }

    //Despausando com o botão no menu
    public void OnClickButtonBackToGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        telaPause.SetActive(false);
        hud.SetActive(true);
        dashIcon.SetActive(true);
        weaponIcon.SetActive(true);
        paused = false;

        movScript.enabled = true;
        combosScript.enabled = true;
        jumpScript.enabled = true;
        dashScript.enabled = true;
    }

    public void OnClickButtonBackToMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
        telaPause.SetActive(false);
        paused = false;
        fadeScript.Transition("Menu");
    }

    public void OnClickButtonSave()
    {
        gameManager.gm.Save();
    }

    public void OnClickButtonOptions()
    {
        MenuOpcoes.SetActive(true);
    }

    public void OnClickButtonFechar()
    {
        MenuOpcoes.SetActive(false);
    }


}
