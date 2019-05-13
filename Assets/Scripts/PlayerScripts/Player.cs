using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private GameManager gameManager;
    private AudioManager audioManager;
    private SpriteRenderer sprite;
    private Animator anim;    
    private Vector3 m_Velocity = Vector3.zero;

    [Header("Movement")]
    [Range(1, 15)] [SerializeField]public float moveSpeed = 7f;
    [Range(1, 5)] [SerializeField]public float sprintSpeedMod = 1.5f;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
    private float moveInput;
    public bool facingRight = true;  // For determining which way the player is currently fac

    [Header("Checkers")]
    public RaycastHit2D downCheck;
    public bool touchingRightWall;
    public bool touchingLeftWall;
    public float groundCheckDistance = 0.45f;
    public LayerMask whatIsGround;
    public bool isGrounded;

    [Header("Jump")]
    [Range(1, 20)] [SerializeField] private float jumpForce = 12f;	
    [Range(0, 1.5f)] public float jumpTime;

    private float jumpTimeCounter;
    [Header("WallJump")]
    public float wallCheckDistance = 0.4f;
    public RaycastHit2D rightWallCheck;
    public RaycastHit2D leftWallCheck;
    [Range(1, 20)] [SerializeField] private float wallJumpForce = 12f;	
    [Range(1, 20)] [SerializeField] private float wallUpJumpForce = 12f;	

    [Header("Dash")]
    public float dashSpeed;
    public float dashTime;
    public float dashLength;
    public bool isDashing;
    public bool canDash;
    public GameObject dashEffect;
    [Header("Shooting")]
    public Vector3 RStickDirection;
    public Transform firePoint;
    public float aimAngle;
	public Vector3 aimDirection;
    private Weapon weapon;
    public AimDirections dir;

	void Start()
	{
        rb2d = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        weapon = GetComponent<Weapon>();
        dashTime = dashLength;

        dir = new AimDirections();
	}
	
	void Update()
	{
        CheckTouches();
        
        moveInput = Input.GetAxisRaw("Horizontal");
        if(Input.GetAxis("Sprint") != 0) 
        {
            moveInput *= sprintSpeedMod;
        }
        CheckFlip(moveInput);
        
        
        Move(moveInput);

        if(isGrounded == true)
        {
            canDash = true;
            anim.SetBool("isJumping", false);
        }
        if(isGrounded == true && Input.GetButtonDown("Jump"))
        {
            jumpTimeCounter = jumpTime;
            rb2d.velocity = Vector2.up * jumpForce;
        } 

        else if(touchingRightWall == true && Input.GetButtonDown("Jump"))
        {
                Vector3 temp = new Vector2(-wallJumpForce, wallUpJumpForce);   
                rb2d.velocity = temp;     
        }
        else if(touchingLeftWall == true && Input.GetButtonDown("Jump"))
        {
                Vector3 temp = new Vector2(wallJumpForce, wallUpJumpForce);   
                rb2d.velocity = temp;     
        }

        if (Input.GetButton("Jump"))
        {
            if(jumpTimeCounter > 0){
                //rb2d.velocity = Vector2.up * jumpForce;
                anim.SetBool("isJumping", true);
                rb2d.AddForce(new Vector2(0f, jumpForce));
                jumpTimeCounter -=Time.deltaTime;
                
            }
        } 



        if(isDashing && dashTime > 0) //continue dashing
        {
            dashTime -= Time.deltaTime;
        }
        else if(isDashing && dashTime < 0) //reset
        {
            isDashing = false;
            dashTime = dashLength;
            rb2d.constraints = RigidbodyConstraints2D.None;
            rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb2d.velocity = (Vector2.right / dashSpeed);
        }
        //get input from thumbsticks
        RStickDirection = new Vector3(Input.GetAxis("RStickHorizontal") * 100, -Input.GetAxis("RStickVertical") * 100, 0f);
		UpdateInput();
	}
	
	private void UpdateInput () {
		if(Input.GetButtonDown("Dash"))
            {
                Dash(facingRight);   
            }
        
        if(Input.GetAxis("Shoot") != 0) 
        {
            SetFirePointPositionAndRotation(RStickDirection);
            weapon.Shoot();
        }
	}

  

    private void CheckTouches()
    {
        downCheck = Physics2D.Raycast(this.transform.position, Vector2.down, groundCheckDistance, whatIsGround);
        if(downCheck.collider != null){ isGrounded = true;}else{isGrounded = false;}

        rightWallCheck = Physics2D.Raycast(this.transform.position, Vector2.right, wallCheckDistance, whatIsGround);
        if(rightWallCheck.collider != null){ touchingRightWall = true;}else{touchingRightWall = false;}

        leftWallCheck = Physics2D.Raycast(this.transform.position, Vector2.left, wallCheckDistance, whatIsGround);
        if(leftWallCheck.collider != null){ touchingLeftWall = true;}else{touchingLeftWall = false;}
        
    }
    private void Move(float horizMovement) {
        if(horizMovement != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else{
            anim.SetBool("isRunning", false);
        }
        Vector3 targetVelocity = new Vector2(horizMovement * moveSpeed, rb2d.velocity.y);

        rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        
        
    }

    void Dash(bool isFacingRight)
    {
        if(!isDashing && canDash) //dash
        {
            dashTime -= Time.deltaTime;
            isDashing = true;
            canDash = false;
            if(isFacingRight)
            {
                rb2d.velocity = Vector2.right * dashSpeed;
            }
            else
            {
                rb2d.velocity = Vector2.right * -dashSpeed;
            }

            rb2d.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            Instantiate(dashEffect, transform.position, Quaternion.identity);
            gameManager.GetComponent<CameraShake>().Shake(0.1f, 0.2f);
        }
        
        
    }

    private void CheckFlip(float input)
    {
        if (input > 0 && !facingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (input < 0 && facingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    private void Flip()
	{
        /* if(facingRight)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
        */
        facingRight = !facingRight;
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
        
        //transform.Rotate(0f, 180f, 0f);
	}

    private void SetFirePointPositionAndRotation(Vector3 aimDir)
    {         
        //if not moving the joystick...
        if((aimDir.x == 0)&&(aimDir.y == 0))
        {
            if(facingRight)
            {
                aimAngle = dir.right.trueAim;
            }
            else
            {
                aimAngle = dir.left.trueAim;
            }
        }
        //if touching the joystick...
        else{
            //force it to only move in a circle around the player
            aimAngle = Mathf.Atan2(aimDir.y, aimDir.x);

            if (aimAngle < 0f)
            {
                aimAngle = Mathf.PI * 2 + aimAngle;
            }


            //this is clunky as shit... need to refactor
            if((aimAngle >= dir.right.botRange)||(aimAngle < dir.right.topRange))
            {
                aimAngle = dir.right.trueAim;
            }
            else if((aimAngle >= dir.upRight.botRange)&&(aimAngle < dir.upRight.topRange))
            {
                aimAngle = dir.upRight.trueAim;
            }
            else if((aimAngle >= dir.up.botRange)&&(aimAngle < dir.up.topRange))
            {
                aimAngle = dir.up.trueAim;
            }
            else if((aimAngle >= dir.upLeft.botRange)&&(aimAngle < dir.upLeft.topRange))
            {
                aimAngle = dir.upLeft.trueAim;
            }
            else if((aimAngle >= dir.left.botRange)&&(aimAngle < dir.left.topRange))
            {
                aimAngle = dir.left.trueAim;
            }
            else if((aimAngle >= dir.downLeft.botRange)&&(aimAngle < dir.downLeft.topRange))
            {
                aimAngle = dir.downLeft.trueAim;
            }
            else if((aimAngle >= dir.down.botRange)&&(aimAngle < dir.down.topRange))
            {
                aimAngle = dir.down.trueAim;
            }
            else if((aimAngle >= dir.downRight.botRange)&&(aimAngle < dir.downRight.topRange))
            {
                aimAngle = dir.downRight.trueAim;
            }
        }
        //figure out where it's aiming around the player
        firePoint.transform.rotation = Quaternion.Euler(0, 0, aimAngle * Mathf.Rad2Deg);

        //Now set firepoint rotation
        float x = transform.position.x + .5f * Mathf.Cos(aimAngle);
        float y = transform.position.y + .5f * Mathf.Sin(aimAngle);

        firePoint.transform.position = new Vector3(x, y, 0);
    }
    
}
