using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class destroyWall : MonoBehaviour
{

    private Material mat;
    private Color alpha;
    public GameObject wall;

    void Start()
    {
        mat = wall.GetComponent<MeshRenderer>().material;
        alpha = mat.color;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            StartCoroutine(destroyObj());
        }
    }

    IEnumerator destroyObj()
    {
        alpha.a -= 0.2f;
        mat.color = alpha;
        yield return new WaitForSecondsRealtime(0.05f);
        if(alpha.a > 0)
        {
            StartCoroutine(destroyObj());
        }
    }
}
