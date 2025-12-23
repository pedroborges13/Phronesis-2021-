using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feedbackPlayer : MonoBehaviour
{
    private Color iniPri, iniSec, iniTer, iniQua, iniQui, iniSex, iniSet;
    Material matPri, matSec, matTer, matQua, matQui, matSex, matSet;
    public GameObject objSec, objTer, objQua, objQui, objSex, objSet;

    public float tempoDeEspera = 0.5f;

    public bool damage;

    void Start()
    {
        matPri = GetComponent<MeshRenderer>().material;
        matSec = objSec.GetComponent<SkinnedMeshRenderer>().material;
        matTer = objTer.GetComponent<SkinnedMeshRenderer>().material;
        matQua = objQua.GetComponent<SkinnedMeshRenderer>().material;
        matQui = objQui.GetComponent<SkinnedMeshRenderer>().material;
        matSex = objSex.GetComponent<SkinnedMeshRenderer>().material;
        matSet = objSet.GetComponent<SkinnedMeshRenderer>().material;

        iniPri = matPri.color;
        iniSec = matSec.color;
        iniTer = matTer.color;
        iniQua = matQua.color;
        iniQui = matQui.color;
        iniSex = matSex.color;
        iniSet = matSet.color;
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
        matQua.color = Color.red;
        matQui.color = Color.red;
        matSex.color = Color.red;
        matSet.color = Color.red;

        yield return new WaitForSeconds(tempoDeEspera);

        matPri.color = iniPri;
        matSec.color = iniSec;
        matTer.color = iniTer;
        matQua.color = iniQua;
        matQui.color = iniQui;
        matSex.color = iniSex;
        matSet.color = iniSet;
    }
}
