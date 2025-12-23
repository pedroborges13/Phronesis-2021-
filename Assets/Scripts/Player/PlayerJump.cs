using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpSpeed = 5;
    public Rigidbody rigidBody;
    private bool onGround = true;
    private const int MAX_JUMP = 2;
    private int currentJump = 0;
    private bool cooldown = false;

    private Animator animaPlayer;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animaPlayer = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (onGround || MAX_JUMP > currentJump) && !cooldown)
        {
            cooldown = true;
            StartCoroutine("PausaSpam");
            rigidBody.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
            onGround = false;
            currentJump++;

            animaPlayer.SetBool("bJump", true);
            animaPlayer.SetBool("bRun", false);
            animaPlayer.SetBool("bIdle", false);
            animaPlayer.SetBool("bDash", false);
        }

        if (!onGround && !animaPlayer.GetBool("bJump"))
        {
            animaPlayer.SetBool("bFall", true);
        }
        else
        {
            animaPlayer.SetBool("bFall", false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("plataformatag"))
        {
            onGround = true;
            currentJump = 0;
        }
    }
    public IEnumerator PausaSpam()
    {
        yield return new WaitForSeconds(0.22f);
        cooldown = false;
    }
}
