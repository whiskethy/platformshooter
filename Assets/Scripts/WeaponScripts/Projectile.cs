using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damageOnImpact;
    public float lifeTime;
    public float impactCheckDistance;
    public LayerMask whatIsSolid;
    public Rigidbody2D rb;
    public Weapon weapon;
    public Weapon.WeaponMode mode;

    public virtual void Start() {

    }
    // Update is called once per frame
    public virtual void Update()
    {

    }

    public virtual void DestroyProjectile()
    {
        
    }
}
