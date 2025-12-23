using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class introScenes : MonoBehaviour
{
    public GameObject firstScene, secScene, thirdScene, fourthScene, fifthScene;
    private int cont = 0;
    private bool cooldown = false;

    public Fade fadeScript;

    public float fill = 0;
    public Image load;

    void Start()
    {
        firstScene.SetActive(true);
        secScene.SetActive(true);
        thirdScene.SetActive(true);
        fourthScene.SetActive(true);
        fifthScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        load.fillAmount = fill;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(cont);
            if(cont == 0)
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
                StartCoroutine(endScene());
                StartCoroutine(loading());
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
        fifthScene.SetActive(true);
        yield return new WaitForSecondsRealtime(1.6f);
        fadeScript.Transition("Tutorial");
        Cursor.lockState = CursorLockMode.Locked;
    }
    IEnumerator loading()
    {
        fill += 0.035f;
        yield return new WaitForSecondsRealtime(0.1f);
        StartCoroutine(loading());
    }
}
