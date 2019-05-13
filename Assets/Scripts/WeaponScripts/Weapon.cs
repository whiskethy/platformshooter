using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponMode { @null, red, blue, green, purple }
    public WeaponMode currMode;
    public List<Weapon.WeaponMode> availableWeapons = new List<Weapon.WeaponMode>();
    public GameObject redBullet;
    public float redFireRate;
    public GameObject blueBullet;
    public float blueFireRate;
    public GameObject greenBullet;
    public float greenFireRate;
    public GameObject purpleBullet;
    public float purpleFireRate;
    private GameObject currBullet;
    public Transform firePoint;
    private float currTimeBtwShots;
    public float fireRate;
    private WeaponUIPanel weaponUIPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        weaponUIPanel = FindObjectOfType<WeaponUIPanel>();
        //SetWeaponMode(WeaponMode.rifle);
        AddWeapon(WeaponMode.@null);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("SwitchWeapon"))
        {
            SwitchWeaponMode();
        }
    }

    public void AddWeapon(WeaponMode mode)
    {
        availableWeapons.Add(mode);
        weaponUIPanel.ActiviateIcon(mode);
        SetWeaponMode(mode);
    }

    private void SwitchWeaponMode()
    {
        int temp = availableWeapons.IndexOf(currMode);
        
        if(availableWeapons.Count == 1)
        {
            SetWeaponMode(availableWeapons[0]);
        }
        else if(temp+1 < availableWeapons.Count) //if there is a weapon left on list
        {
            SetWeaponMode(availableWeapons[temp+1]);
        }
        else //go back to no weapon [change this later]
        {
            SetWeaponMode(availableWeapons[1]);
        }
        
    }

    private void SetWeaponMode(WeaponMode mode)
    {
        currMode = mode;
        if(currMode == WeaponMode.red)
        {
            currBullet = redBullet;
            fireRate = redFireRate;
        }
        else if(currMode == WeaponMode.blue)
        {
            currBullet = blueBullet;
            fireRate = blueFireRate;
        }
        else if(currMode == WeaponMode.green)
        {
            currBullet = greenBullet;
            fireRate = greenFireRate;
        }
        else if(currMode == WeaponMode.purple)
        {
            currBullet = purpleBullet;
            fireRate = purpleFireRate;
        }

        weaponUIPanel.SetActiveWeapon(mode);
        
    }
    
    public void Shoot()
    {
        if(currMode != WeaponMode.@null){
            if(currTimeBtwShots <= 0)
            {
                Instantiate(currBullet, firePoint.position, firePoint.rotation);
                currTimeBtwShots = fireRate;
            }
            else
            {
                currTimeBtwShots -= Time.deltaTime;
            }
        }
    }
}
