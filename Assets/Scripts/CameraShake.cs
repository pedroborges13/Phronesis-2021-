using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    Animator anim;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ShakeLeve()
    {
        anim.Play("CameraDanoLeve");
    }

    public void ShakeForte()
    {
        anim.Play("CameraDanoAlto");
    }

}
