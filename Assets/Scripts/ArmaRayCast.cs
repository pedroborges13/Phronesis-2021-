using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaRayCast : MonoBehaviour
{
    public float RayCastCima = 3;
    public float RayCastBaixo = -1;
    void Update()
    {
        RaycastDoPersonagem();
    }
    void RaycastDoPersonagem()
    {
        Debug.DrawRay(transform.position, transform.up * RayCastCima, Color.red);
        Debug.DrawRay(transform.position, -transform.up * RayCastBaixo, Color.cyan);
        RaycastHit plataforma;
        if (Physics.Raycast(transform.position, transform.up, out plataforma, 3, LayerMask.GetMask("plataforma")))
        {
            GetComponent<CapsuleCollider>().isTrigger = true;
        }
        if (Physics.Raycast(transform.position + transform.up * -1, -transform.up, out plataforma, 3, LayerMask.GetMask("plataforma")))
        {
            GetComponent<CapsuleCollider>().isTrigger = false;
        }
    }
}
