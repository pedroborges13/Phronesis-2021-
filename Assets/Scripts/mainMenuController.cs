using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuController : MonoBehaviour
{
    public Animator capa;
    public Animator logo;
    public GameObject text;
    public GameObject capa_;
    public GameObject logo_;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine(StartMenu());
        }
    }
   

    IEnumerator StartMenu()
    {
        capa.SetTrigger("Start");
        logo.SetTrigger("Start");
        text.SetActive(false);

        yield return new WaitForSeconds(1f);
        capa_.SetActive(false);
        logo_.SetActive(false);        
    }
}
