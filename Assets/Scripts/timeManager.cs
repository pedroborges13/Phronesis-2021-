using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeManager : MonoBehaviour
{
    public float slow = 0.05f;
    public float slowTime= 2f;

    private void Update()
    {
        //me.timeScale += (1f / slowTime) * Time.unscaledDeltaTime;
        //me.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void SlowMotion()
    {
        Time.timeScale = slow;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

}
