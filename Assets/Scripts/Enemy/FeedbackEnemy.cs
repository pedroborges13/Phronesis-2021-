using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackEnemy : MonoBehaviour
{
    public Color corInicial;
    Material matPri, matSec;
    public GameObject objSec;
    public ParticleSystem effect;

    public float tempoDeEspera = 0.5f;

    public bool damage;

    void Start()
    {
        matPri = GetComponent<MeshRenderer>().material;
        matSec = objSec.GetComponent<SkinnedMeshRenderer>().material;
        corInicial = matPri.color;
        matSec.color = corInicial;
    }

    void Update()
    {
        if (damage)
        {
            StartCoroutine("MudarCor");
            damage = false;
        }
    }

    public IEnumerator MudarCor()
    {
        matPri.color = Color.red;
        matSec.color = Color.red;
        CreatEffect();
        yield return new WaitForSeconds(tempoDeEspera);
        matPri.color = corInicial;
        matSec.color = corInicial;
    }

    void CreatEffect()
    {
        effect.Play();
    }
}
