using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puloTutorial : MonoBehaviour
{
    public Image tutorialBackgroundd;

    public Text textoPular;

    public GameObject _tutorialBackgroundd;
    public GameObject _textPular;
    public GameObject botaoEspaco;

    dashMove dashScript;
    PlayerJump jumpScript;
    Combos attackScript;

    public AudioSource runSound;

    private bool pausedd = false;

    void Start()
    {
        tutorialBackgroundd.enabled = false;
        textoPular.enabled = false;

        _textPular.SetActive(true);

        dashScript = FindObjectOfType<dashMove>();
        jumpScript = FindObjectOfType<PlayerJump>();
        attackScript = FindObjectOfType<Combos>();
    }

    void Update()
    {
        if (pausedd == true)
        {
            jumpScript.enabled = false;
            dashScript.enabled = false;
            attackScript.enabled = false;

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Saiu do Tutorial");
                Time.timeScale = 1;
                pausedd = false;

                tutorialBackgroundd.enabled = false;
                textoPular.enabled = false;
                botaoEspaco.SetActive(false);

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
            if (pausedd == false)
            {
                Time.timeScale = 0;
                textoPular.enabled = true;
                tutorialBackgroundd.enabled = true;
                botaoEspaco.SetActive(true);
                //runSound.Stop();
                pausedd = true;
                Debug.Log("pausou");
            }
        }
    }
}
