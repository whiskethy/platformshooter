using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleBullet : Projectile
{
    public override void Start() {
        weapon = FindObjectOfType<Weapon>();
        mode = Weapon.WeaponMode.red;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Invoke("DestroyProjectile", lifeTime);    
    }
    // Update is called once per frame
    public override void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, impactCheckDistance, whatIsSolid);
        if(hitInfo.collider != null)
        {   
            if(hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.gameObject.GetComponent<Enemy>().takeDamage(mode, damageOnImpact);
            }
            DestroyProjectile();
        }
    }

    public override void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
}
