using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalScenes : MonoBehaviour
{
    public GameObject firstScene, secScene, thirdScene, fourthScene, fifthScene, sixthScene;
    private int cont = 0;
    private bool cooldown = false;

    public Fade fadeScript;

    void Start()
    {
        firstScene.SetActive(true);
        secScene.SetActive(true);
        thirdScene.SetActive(true);
        fourthScene.SetActive(true);
        fifthScene.SetActive(true);
        sixthScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(cont);
            if (cont == 0)
            {
                StartCoroutine(fadeSprite(firstScene));
                StartCoroutine(setCooldown());
                cont++;
            }
            if (cont == 1 && !cooldown)
            {
                StartCoroutine(fadeSprite(secScene));
                StartCoroutine(setCooldown());
                cont++;
            }
            if (cont == 2 && !cooldown)
            {
                StartCoroutine(fadeSprite(thirdScene));
                StartCoroutine(setCooldown());
                cont++;
            }
            if (cont == 3 && !cooldown)
            {
                StartCoroutine(fadeSprite(fourthScene));
                StartCoroutine(setCooldown());
                cont++;
            }
            if (cont == 4 && !cooldown)
            {
                StartCoroutine(fadeSprite(fifthScene));
                StartCoroutine(endScene());
                cont++;
            }
        }
    }

    IEnumerator fadeSprite(GameObject scene)
    {

        Color alphaScene = scene.GetComponent<SpriteRenderer>().color;
        alphaScene.a -= 0.2f;
        scene.GetComponent<SpriteRenderer>().color = alphaScene;
        yield return new WaitForSecondsRealtime(0.1f);
        if (alphaScene.a > 0)
        {
            StartCoroutine(fadeSprite(scene));
        }
    }

    IEnumerator setCooldown()
    {
        cooldown = true;
        yield return new WaitForSecondsRealtime(1.2f);
        cooldown = false;
    }

    IEnumerator endScene()
    {
        sixthScene.SetActive(true);
        yield return new WaitForSecondsRealtime(0.8f);
        fadeScript.Transition("Menu");
    }
}
