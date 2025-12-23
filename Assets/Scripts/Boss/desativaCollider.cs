using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desativaCollider : MonoBehaviour
{
    public CapsuleCollider colliderBracoDireito;
    public CapsuleCollider colliderBracoEsquerdo;

    public void ativarCol()
    {
        colliderBracoEsquerdo.enabled = true;
        colliderBracoDireito.enabled = true;
    }

    public void desativarCol()
    {
        colliderBracoEsquerdo.enabled = false;
        colliderBracoDireito.enabled = false;
    }
}
