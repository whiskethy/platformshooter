using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damageOnTouch;
    public float moveSpeed;
    public Rigidbody2D rb2d;
    public float downCheckDistance;
    public float wallCheckDistance;
    public bool touchingWall;
    public bool forwardIsGround;
    public LayerMask whatIsGround;
    public RaycastHit2D forwardCheck;
    public RaycastHit2D wallCheck;
    public LevelManager levelManager;
    public List<Weapon.WeaponMode> canBeHurtBy;
    public GameObject deathParticleEffect;

    public bool facingRight = true;  // For determining which way the player is currently facing.

    public virtual void Start()
    {
    }

    public virtual void Update()
    {

    }

    public virtual void Move()
    {

    }
    public virtual void takeDamage(Weapon.WeaponMode inMode, int inDamage) //what happens is overriden by the enemy's specific script.
    {
        
    }
    
    public virtual void Die() //what happens is overriden by the enemy's specific script.
    {
        
    }
    
    public virtual void DoChecks()
    {
        if(facingRight)
        {
            wallCheck = Physics2D.Raycast(transform.position, Vector2.right, wallCheckDistance, whatIsGround);
            forwardCheck = Physics2D.Raycast(transform.position + new Vector3(.5f,0,0), Vector2.down, downCheckDistance, whatIsGround);
        }
        else
        {
            wallCheck = Physics2D.Raycast(this.transform.position, Vector2.left, wallCheckDistance, whatIsGround);
            forwardCheck = Physics2D.Raycast(transform.position + new Vector3(-.5f,0,0), Vector2.down, downCheckDistance, whatIsGround);
        }

        if(wallCheck.collider != null){ touchingWall = true;}else{touchingWall = false;}
        if(forwardCheck.collider != null){ forwardIsGround = true;}else{forwardIsGround = false;}

    }

    public virtual void DamagePlayer()
    {
        
    }

    public void Flip()
    {
        // Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            DamagePlayer();
        }
    }
}
