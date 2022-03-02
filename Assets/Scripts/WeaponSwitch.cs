using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public int selectedWeapon = 0;

    void Start()
    {
        selectWeapon();
    }

    private void selectWeapon()
    {
        int i = 0;
        foreach (Transform item in transform)
        {
            if (i == selectedWeapon)
                item.gameObject.SetActive(true);
            else
                item.gameObject.SetActive(false);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelected = selectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount -1;
            else
                selectedWeapon--;
        }

        if (previousSelected != selectedWeapon)
            selectWeapon();
    }
}