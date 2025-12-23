using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyProje : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
