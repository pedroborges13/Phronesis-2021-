using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feedbackBoss : MonoBehaviour
{
    public Color corInicial;
    Material matPri, matSec, matTer;
    public GameObject objSec, objTer;
    public ParticleSystem effect;

    public float tempoDeEspera = 0.5f;

    public bool damage;

    void Start()
    {
        matPri = GetComponent<MeshRenderer>().material;
        matSec = objSec.GetComponent<SkinnedMeshRenderer>().material;
        matTer = objTer.GetComponent<SkinnedMeshRenderer>().material;
        corInicial = matTer.color;
        matPri.color = corInicial;
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
        matTer.color = Color.red;
        CreatEffect();
        yield return new WaitForSeconds(tempoDeEspera);
        matPri.color = corInicial;
        matSec.color = corInicial;
        matTer.color = corInicial;
    }

    void CreatEffect()
    {
        effect.Play();
    }
}
