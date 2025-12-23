using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowPlayer : MonoBehaviour
{

    public GameObject player, holder;
    public float horizontal, vertical;

    void Start()
    {
        
    }

    void Update()
    {
        holder.transform.SetPositionAndRotation(new Vector3(player.transform.position.x + horizontal, player.transform.position.y + vertical, player.transform.position.z), Quaternion.Euler(0.0f, 0.0f, 0.0f));

        /*
        if(horizontal > 5)
        {
            horizontal = 3;
        }

        if (horizontal < -5)
        {
            horizontal = -5;
        }*/
    }
}
