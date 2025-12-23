using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    [SerializeField] public float knockbackStrength;

    private Animator anim;
    public bool active = false;

    //Teste p/ o Boss
    public Rigidbody rigidBodyBossT;
    public float jumpSpeedUpT;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

            if (active)
            {
                Vector3 direction = collision.transform.position - transform.position;
                direction.y = 0;

                rb.AddForce(direction.normalized * knockbackStrength, ForceMode.Impulse);
                //Jogar um pouquinho para cima
                rigidBodyBossT.AddForce(Vector3.up * jumpSpeedUpT, ForceMode.VelocityChange);
            }
        }
    }
}
