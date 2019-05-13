using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTypePickup : MonoBehaviour
{
    public Weapon weapon;
    public Weapon.WeaponMode mode;
    // Start is called before the first frame update
    void Start()
    {
        weapon = FindObjectOfType<Weapon>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("Pickup Weapon " + mode.ToString());
            weapon.AddWeapon(mode);
            Destroy(this.gameObject);
        }
    }
}
