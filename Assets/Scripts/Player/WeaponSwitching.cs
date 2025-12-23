using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    public Animator animPlayer;
    private bool canSwitch = true;
    public bool swap = true;
    public Image signal;
    public float coolDown = 1f;
    public bool isCoolDown = false;

    // Start is called before the first frame update
    void Start()
    {
        SelectedWeapon();
        signal.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CDSWAPICON();

        if(Time.timeScale == 0){
            canSwitch = false;
        }
        else
        {
            canSwitch = true;
        }

        int previousSelectedWeapon = selectedWeapon;
        if (canSwitch)
        {
            if (swap && canSwitch)
            {
                if (Input.GetAxis("Mouse ScrollWheel") > 0f && !animPlayer.GetCurrentAnimatorStateInfo(0).IsTag("Attacking"))
                {
                    if (selectedWeapon >= transform.childCount - 1)
                    {
                        selectedWeapon = 0;

                    }
                    else
                    {
                        selectedWeapon++;
                        StartCoroutine(SwitchCD());
                        //CDSWAPICON();
                    }
                }

                if (Input.GetAxis("Mouse ScrollWheel") < 0f && !animPlayer.GetCurrentAnimatorStateInfo(0).IsTag("Attacking"))
                {
                    if (selectedWeapon <= 0)
                    {
                        selectedWeapon = transform.childCount - 1;

                    }
                    else
                    {
                        selectedWeapon--;
                        StartCoroutine(SwitchCD());
                        //CDSWAPICON();
                    }
                        
                }

                if (previousSelectedWeapon != selectedWeapon)
                {
                    SelectedWeapon();
                }
            }
        }
    }

    void SelectedWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    void CDSWAPICON()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0f && isCoolDown == false || Input.GetAxis("Mouse ScrollWheel") > 0f && isCoolDown == false)
        {
            isCoolDown = true;
            signal.fillAmount = 1;
        }
        if (isCoolDown)
        {
            signal.fillAmount -= 1 / coolDown * Time.deltaTime;
            if (signal.fillAmount <= 0)
            {
                signal.fillAmount = 0;
                isCoolDown = false;
            }
        }
    }
    IEnumerator SwitchCD()
    {
        swap = false;
        yield return new WaitForSeconds(coolDown);
        swap = true;
        
    }
}
