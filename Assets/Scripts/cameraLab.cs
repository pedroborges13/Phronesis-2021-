using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class cameraLab : MonoBehaviour
{
    cameraFollowPlayer camScript;
    public GameObject nextCol;
    private bool change = false;
    public int cont;

    void Start()
    {
        camScript = FindObjectOfType<cameraFollowPlayer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (change && cont == 0 && camScript.horizontal < 3)
        {
            camScript.horizontal++;
        }

        if (change && cont == 1 && camScript.horizontal > -5)
        {
            camScript.horizontal--;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            StartCoroutine(changeDirection());
            nextCol.SetActive(true);
        }
    }

    IEnumerator changeDirection()
    {
        change = true;
        yield return new WaitForSecondsRealtime(0.4f);
        change = false;
        Destroy(this);
    }
}
