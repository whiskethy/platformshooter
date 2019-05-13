using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatThing : Enemy
{
     public override void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        levelManager = FindObjectOfType<LevelManager>();

    }

    public override void Update()
    {
        DoChecks();
        if(touchingWall)
        {
            Flip();
        }

        Move();
    }
    public override void DoChecks()
    {
        if(facingRight)
        {
            wallCheck = Physics2D.Raycast(transform.position, Vector2.right, wallCheckDistance, whatIsGround);
            //forwardCheck = Physics2D.Raycast(transform.position + new Vector3(.5f,0,0), Vector2.down, downCheckDistance, whatIsGround);
        }
        else
        {
            wallCheck = Physics2D.Raycast(this.transform.position, Vector2.left, wallCheckDistance, whatIsGround);
            //forwardCheck = Physics2D.Raycast(transform.position + new Vector3(-.5f,0,0), Vector2.down, downCheckDistance, whatIsGround);
        }

        if(wallCheck.collider != null){ touchingWall = true;}else{touchingWall = false;}
        //if(forwardCheck.collider != null){ forwardIsGround = true;}else{forwardIsGround = false;}

    }
    public override void Move()
    {
        if(facingRight == true)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0f);
        }
        else{rb2d.velocity = new Vector2(-moveSpeed, 0f);}
    }
    public override void takeDamage(Weapon.WeaponMode inMode, int inDamage) 
    {
        if(canBeHurtBy.Contains(inMode))
        {
            //Debug.Log("Get hit");
            health -= inDamage;
            if(health <= 0)
            {
                Die();
            }
        }
    }

    public override void Die()
    {
        
        Instantiate(deathParticleEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        levelManager.KillEnemy();
    }

    public override void DamagePlayer()
    {
        FindObjectOfType<GameManager>().GetComponent<HealthManager>().DamagePlayer(damageOnTouch);
    }
}
