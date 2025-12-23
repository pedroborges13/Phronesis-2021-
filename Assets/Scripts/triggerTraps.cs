using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerTraps : MonoBehaviour
{
   public GameObject trigger;
   public  GameObject trap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Colidiu");
            trap.transform.position = new Vector3(0, 10 * Time.deltaTime, 0); 
        }
        

    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            trap.transform.position = new Vector3(trap.transform.position.x, trap.transform.position.y + 50 * Time.deltaTime, trap.transform.position.z);
            this.gameObject.SetActive(false);
        }
    }
}
