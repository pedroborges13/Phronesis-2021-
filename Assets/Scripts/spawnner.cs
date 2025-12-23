using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnner : MonoBehaviour
{
    public GameObject projectile;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject spear = Instantiate(projectile, transform)as GameObject;
            Rigidbody rb = spear.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 20;
        }
    }

   
}
