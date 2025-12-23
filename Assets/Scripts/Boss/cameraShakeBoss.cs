using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShakeBoss : MonoBehaviour
{
    public static cameraShakeBoss instance;

    Animator anim;

    void Awake()
    {
        if (instance == null)
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
        anim.Play("CameraDanoLeveBoss");
    }

    public void ShakeForte()
    {
        anim.Play("CameraDanoAltoBoss");
    }

}
