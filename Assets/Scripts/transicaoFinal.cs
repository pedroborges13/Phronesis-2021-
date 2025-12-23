using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class transicaoFinal : MonoBehaviour
{
    public Fade fadeScript;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "PosBoss")
        {
            GetComponent<Animator>().SetBool("bPossBoss", true);

            if (GetComponent<Animator>().GetInteger("countStand") == 0)
            {
                StartCoroutine(waitStand());
            }

            GetComponent<Animator>().SetBool("bStretch", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("bPossBoss", false);
        }
        fadeScript = FindObjectOfType<Fade>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "transicao")
        {
            Debug.Log("Entrou no collider");
            fadeScript.Transition("CenaFinal");
        }
    }
    //CHAMAR TRANSIÇÃO
    IEnumerator waitStand()
    {
        yield return new WaitForSeconds(1.0f);
        GetComponent<Animator>().SetInteger("countStand", 1);
    }
}
