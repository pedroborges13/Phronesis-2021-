using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingObjects : MonoBehaviour
{
    public GameObject brokenObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Vector3 oldPos = transform.position;
            Instantiate(brokenObject, oldPos, Quaternion.identity);
            Destroy(gameObject);
            
        }
    }

    void OnCollision(Collision collider)
    {
        if (collider.gameObject.tag == "Weapon")
        {
            Vector3 oldPos = transform.position;
            Instantiate(brokenObject, oldPos, Quaternion.identity);
            Destroy(gameObject);
            
        }
    }
}
