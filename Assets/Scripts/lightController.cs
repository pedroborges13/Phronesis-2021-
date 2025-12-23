using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightController : MonoBehaviour
{
    public bool flickering=false;
    public float time;
    public float minTime;
    public float maxTime;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (flickering == false)
        {
            StartCoroutine(LightFlickering());
        }
    }

    IEnumerator LightFlickering()
    {
        flickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        time = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(time);
        this.gameObject.GetComponent<Light>().enabled = true;
        time = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(time);
        flickering = false;
    }
}
