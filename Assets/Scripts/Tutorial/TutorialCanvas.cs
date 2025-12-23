using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCanvas : MonoBehaviour
{
    //public GameObject textoAndarTutorial;
    public Image tutorialBackground;

    public Text textoAndar;

    public GameObject _tutorialBackground;
    public GameObject _textoAndar;
    public GameObject _textoPular;
    public GameObject botaoA;
    public GameObject botaoD;

    dashMove dashScript;
    PlayerJump jumpScript;
    Combos attackScript;

    public AudioSource runSound;

    private bool paused = false;

    void Start()
    {
        tutorialBackground.enabled = false;
        textoAndar.enabled = false;

        _tutorialBackground.SetActive(true);
        _textoAndar.SetActive(true);
        // _textoPular.SetActive(true);

        dashScript = FindObjectOfType<dashMove>();
        jumpScript = FindObjectOfType<PlayerJump>();
        attackScript = FindObjectOfType<Combos>();
    }

    void Update()
    {
        if (paused == true)
        {

            jumpScript.enabled = false;
            dashScript.enabled = false;
            attackScript.enabled = false;

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Saiu do Tutorial");
                Time.timeScale = 1;
                //Cursor.lockState = CursorLockMode.Locked;
                paused = false;

                tutorialBackground.enabled = false;
                textoAndar.enabled = false;
                botaoA.SetActive(false);
                botaoD.SetActive(false);
                //_tutorialBackground.SetActive(false);
                // _textoAndar.SetActive(false);

                jumpScript.enabled = true;
                dashScript.enabled = true;
                attackScript.enabled = true;

                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Congela o tempo
            if (paused == false)
            {
                Time.timeScale = 0;
                textoAndar.enabled = true;
                tutorialBackground.enabled = true;
                botaoA.SetActive(true);
                botaoD.SetActive(true);
                //runSound.Stop();
                paused = true;
                Debug.Log("pausou");
            }
            /*else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                paused = false;
            }*/
            
        }
    }
}
