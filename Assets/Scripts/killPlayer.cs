using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour
{
    vidaPlayer lifePlayer;
    // Start is called before the first frame update
    void Start()
    {
        lifePlayer = FindObjectOfType<vidaPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lifePlayer.life -= 100;
        }
    }
}
