using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatRayCast : MonoBehaviour
{
    public float ParaCima = 2.75f;
    public float ParaBaixo = 0.5f;
    void Update()
    {
        RaycastDoPersonagem();
    }
    void RaycastDoPersonagem()
    {
        //RayCast visual
        Debug.DrawRay(transform.position,transform.up * ParaCima, Color.green);
        Debug.DrawRay(transform.position, -transform.up * ParaBaixo, Color.blue);
        RaycastHit plataforma;
        if (Physics.Raycast(transform.position, transform.up, out plataforma, 2.75f , LayerMask.GetMask("plataforma")))
        {
                GetComponent<CapsuleCollider> ().isTrigger = true;             
        }
        if (Physics.Raycast(transform.position + transform.up * -0.5f, -transform.up, out plataforma, 3, LayerMask.GetMask("plataforma")))
        {
            GetComponent<CapsuleCollider>().isTrigger = false;
        }
    }
}

