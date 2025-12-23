using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    vidaPlayer vidaPlayerScript;
    public GameObject TelaGameOver;
    public Fade fadeScript;

    void Start()
    {
        vidaPlayerScript = FindObjectOfType<vidaPlayer>();
    }


    void Update()
    {

    }

    public void openTelaGameOver()
    {
        Time.timeScale = 0;
        TelaGameOver.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void goMainMenu()
    {
        Time.timeScale = 1;
        fadeScript.Transition("Menu");
        StartCoroutine(waitForFade(1.0f));
    }

    public void Restart()
    {
        vidaPlayerScript.Reviver();
        fadeScript.Transition(SceneManager.GetActiveScene().name);
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(waitForFade(1.0f));

        vidaPlayerScript.death = 0;
    }

    IEnumerator waitForFade(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        TelaGameOver.SetActive(false);
    }
}
