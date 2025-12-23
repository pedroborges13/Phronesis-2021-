using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingDemo : MonoBehaviour
{
    
    public GameObject ending;
    public GameObject hud;
    public AudioSource runSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        Time.timeScale = 0;
        hud.SetActive(false);
        ending.SetActive(true);
        runSound.Stop();
        Cursor.lockState = CursorLockMode.None;
    }
}
