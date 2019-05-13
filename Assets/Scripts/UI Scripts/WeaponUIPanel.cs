using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUIPanel : MonoBehaviour
{
    public GameObject redBulletIcon;
    public GameObject blueBulletIcon;
    public GameObject greenBulletIcon;
    public GameObject purpleBulletIcon;

    public Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        redBulletIcon.SetActive(false);
        blueBulletIcon.SetActive(false);
        greenBulletIcon.SetActive(false);
        purpleBulletIcon.SetActive(false);
    }

    public void ActiviateIcon(Weapon.WeaponMode mode)
    {
        if(mode == Weapon.WeaponMode.red)
        {
            redBulletIcon.SetActive(true);
        }
        else if(mode == Weapon.WeaponMode.blue)
        {
            blueBulletIcon.SetActive(true);
        }
        if(mode == Weapon.WeaponMode.green)
        {
            greenBulletIcon.SetActive(true);
        }
        else if(mode == Weapon.WeaponMode.purple)
        {
            purpleBulletIcon.SetActive(true);
        }
    }

    public void SetActiveWeapon(Weapon.WeaponMode mode)
    {
        if(mode == Weapon.WeaponMode.red)
        {
            redBulletIcon.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1);
            blueBulletIcon.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
            greenBulletIcon.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
            purpleBulletIcon.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
        }
        else if(mode == Weapon.WeaponMode.blue)
        {
            redBulletIcon.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
            blueBulletIcon.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1);
            greenBulletIcon.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
            purpleBulletIcon.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
        }
        else if(mode == Weapon.WeaponMode.green)
        {
            redBulletIcon.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
            blueBulletIcon.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
            greenBulletIcon.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1);
            purpleBulletIcon.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
        }
        else if(mode == Weapon.WeaponMode.purple)
        {
            redBulletIcon.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
            blueBulletIcon.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
            greenBulletIcon.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
            purpleBulletIcon.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1);
        }

    }
}
