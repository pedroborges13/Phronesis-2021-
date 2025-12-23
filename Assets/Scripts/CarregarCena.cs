using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarregarCena : MonoBehaviour
{
    public gameManager gameManagerScript;
    public Fade fadeScript;
    public string cenaCar;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("gameManager") != null)
        {
            //cenaCar = gameManagerScript.cena;
            SceneManager.LoadScene(gameManagerScript.cena);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
