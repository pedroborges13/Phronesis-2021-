using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ataqueTutorial : MonoBehaviour
{
    public Image tutorialBackgrounddd;

    public Text textoAtacar;

    public GameObject _tutorialBackgrounddd;
    public GameObject _textAtacar;
    public GameObject mouseEsq;
    public GameObject botaoShift;

    dashMove dashScript;
    PlayerJump jumpScript;
    Combos attackScript;

    public AudioSource runSound;

    private bool pauseddd = false;

    void Start()
    {
        tutorialBackgrounddd.enabled = false;
        textoAtacar.enabled = false;
      
        _textAtacar.SetActive(true);

        dashScript = FindObjectOfType<dashMove>();
        jumpScript = FindObjectOfType<PlayerJump>();
        attackScript = FindObjectOfType<Combos>();
    }

    void Update()
    {
        if (pauseddd == true)
        {
            jumpScript.enabled = false;
            dashScript.enabled = false;
            attackScript.enabled = false;

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Saiu do Tutorial");
                Time.timeScale = 1;
                pauseddd = false;

                tutorialBackgrounddd.enabled = false;
                textoAtacar.enabled = false;
                mouseEsq.SetActive(false);
                botaoShift.SetActive(false);

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
            if (pauseddd == false)
            {
                Time.timeScale = 0;
                textoAtacar.enabled = true;
                tutorialBackgrounddd.enabled = true;
                mouseEsq.SetActive(true);
                botaoShift.SetActive(true);
                //runSound.Stop();
                pauseddd = true;
                Debug.Log("pausou");
            }
        }
    }
}