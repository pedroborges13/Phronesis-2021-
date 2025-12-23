using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerTrapsII : MonoBehaviour
{
   
    public GameObject trigger;
    public GameObject trap;
  /*public GameObject trapA;
    public GameObject trapB;
    public GameObject trapC;
    public GameObject trapD;
    public GameObject trapE;
    public GameObject trapF;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {

            //trapA.transform.position = new Vector3(trapA.transform.position.x, trapA.transform.position.y - 100 * Time.deltaTime, trapA.transform.position.z);
            trap.transform.position = new Vector3(trap.transform.position.x, trap.transform.position.y -100 * Time.deltaTime, trap.transform.position.z);
            this.gameObject.SetActive(false);

        }

       
    }
}
