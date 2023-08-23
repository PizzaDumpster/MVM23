using System.Collections;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    [SerializeField] public int playerHealth;
    [SerializeField] int maxPlayerHealth = 3;
    [SerializeField] float movementSpeed = 1.0f, startMovementSpeed;
    [SerializeField] float jumpForce = 1.0f;
    [SerializeField] Transform groundCheck;
    [SerializeField] public bool isGrounded;
    [SerializeField] float timeOnGround;
    [SerializeField] float timeInAir;
    [SerializeField] public bool isInAir;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] bool canDoubleJump;
    [SerializeField] int jumpCounter;
    [SerializeField] public bool canDash;
    [SerializeField] int dashCounter;
    [SerializeField] float waitForNextDash;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashTime;
    [SerializeField] bool isDashing;
    [SerializeField] public bool unlockedDoubleJump = false;
    [SerializeField] public bool unlockedDash = false;
    [SerializeField] public bool wallClimbUnlocked = false;
    [SerializeField] bool isClimbing;
    [SerializeField] float climbMultiplyer;
    [SerializeField] float maxSpeed;
    [SerializeField] Vector2 direction;
    [SerializeField] float gravityScale;
    [SerializeField] bool canWallClimb;
    [SerializeField] bool isOnWall;
    [SerializeField] Transform wallCheck;
    [SerializeField] float cyoteTime = 0.5f;
    [SerializeField] bool canCyoteJump = true;
    [SerializeField] int avalableJumps = 1;
    [SerializeField] float jumpForceMultiplyer;
    [SerializeField] float startJumpForce;
    [SerializeField] float doubleJumpDampiner;
    [SerializeField] public bool playerInvincable;
    public bool isBlinking;
    [SerializeField] Vector2 movement;
    [SerializeField] Joystick joystick;
    [SerializeField] Canvas mobileCanvas;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        startMovementSpeed = movementSpeed;
        canDash = true;
        playerHealth = maxPlayerHealth;
        wallClimbUnlocked = false;
        unlockedDash = false;
        unlockedDoubleJump = false;
        startJumpForce = jumpForce;
        if (Application.isMobilePlatform)
        {
            mobileCanvas.enabled = true;
        }
        else
        {
            mobileCanvas.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (wallClimbUnlocked)
        {
            isOnWall = Physics2D.BoxCast(wallCheck.position, new Vector2(1f, 2f), 0f, Vector2.right, 0.1f, whatIsGround);
        }
        else
        {
            isOnWall = false;
        }

        isGrounded = Physics2D.BoxCast(groundCheck.position, new Vector2(1f, 1f), 0f, Vector2.down, 0.1f, whatIsGround);
        float moveDt = movementSpeed;

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }

        //if (Input.GetKey(KeyCode.W))
        //{
        //    direction.y = 1;
        //    if (isClimbing || isOnWall)
        //    {
        //        rb.gravityScale = 0;
        //        rb.velocity = new Vector2(rb.velocity.x, moveDt * direction.y * climbMultiplyer);

        //    }
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    direction.y = -1;
        //    if (isClimbing || isOnWall)
        //    {
        //        rb.gravityScale = 0;
        //        rb.velocity = new Vector2(rb.velocity.x, moveDt * direction.y * climbMultiplyer);
        //    }
        //}

        if (Application.isMobilePlatform)
        {
            if(joystick.Horizontal > 0.2f)
            {
                movement.x = 1;
            }else if(joystick.Horizontal < -0.2f)
            {
                movement.x = -1;
            }
            else
            {
                movement.x = 0; 
            }
            
        }
        else
        {
            movement.x = Input.GetAxis("Horizontal");
        }
        movement.y = Input.GetAxis("Vertical");
        if (!isDashing)
            rb.velocity = new Vector2(movement.x * movementSpeed, rb.velocity.y);
        if (movement.x > 0f)
        {
            direction.x = 1;
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);
            transform.localScale = new Vector3(1, 1, 1);

        }
        else if (movement.x < 0f)
        {
            direction.x = -1;
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
        }

        if (!unlockedDoubleJump)
        {
            canDoubleJump = false;
        }
        if (!isClimbing)
        {
            rb.gravityScale = gravityScale;
        }
        if ((Input.GetKeyDown(KeyCode.Space) && isGrounded && jumpCounter <= avalableJumps) || (Input.GetKeyDown(KeyCode.Space) && canDoubleJump && jumpCounter <= avalableJumps) || (Input.GetKeyDown(KeyCode.Space) && timeInAir < 0.5f && jumpCounter <= avalableJumps))
        {
            Jump();
        }
        if ((Input.GetButtonDown("Fire1") && isGrounded && jumpCounter <= avalableJumps) || (Input.GetButtonDown("Fire1") && canDoubleJump && jumpCounter <= avalableJumps) || (Input.GetButtonDown("Fire1") && timeInAir < 0.5f && jumpCounter <= avalableJumps))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(WaitForJumpClearance());

        }
        if (unlockedDash)
        {
            if ((Input.GetKeyDown(KeyCode.LeftShift) && canDash) || (Input.GetButtonDown("Fire2") && canDash))
            {
                StartCoroutine(Dash());
            }
        }
        if (!isGrounded)
        {
            timeInAir += Time.deltaTime;
            isInAir = true;

        }
        if (isGrounded)
        {
            jumpForce = startJumpForce;
            timeOnGround += Time.deltaTime;
            jumpCounter = 0;
            timeInAir = 0;
            isInAir = false;
        }
        if (unlockedDoubleJump)
        {
            if (jumpCounter <= 1)
            {
                canDoubleJump = true;
                avalableJumps = 1;
            }
        }
        if (!unlockedDoubleJump)
        {
            canDoubleJump = false;
            avalableJumps = 0;
        }


    }
    public void Jump()
    {
        switch (jumpCounter)
        {
            case 0:
                if (isGrounded)
                {
                    AudioManager.instance.Play("Jump");
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    break;
                }
                break;
            case 1:
                if (unlockedDoubleJump)
                {
                    AudioManager.instance.Play("Jump");
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    break;
                }
                break;
            default:
                // code block
                break;
        }
    }

    public void DashActivator()
    {
        if (unlockedDash)
            StartCoroutine(Dash());
    }

    public IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;
        dashCounter++;

        rb.velocity = new Vector2(direction.x * (dashSpeed + movementSpeed), rb.velocity.y);
        yield return new WaitForSeconds(dashTime);
        rb.velocity = Vector3.zero;
        isDashing = false;
        StartCoroutine(WaitForNextDash());
    }
    public IEnumerator WaitForNextDash()
    {
        yield return new WaitForSeconds(waitForNextDash);
        canDash = true;
        dashCounter = 0;
    }
    public IEnumerator WaitForJumpClearance()
    {
        if (jumpCounter == 0)
            yield return new WaitForSeconds(0.01f);
        else
            yield return null;
        jumpCounter++;
        timeOnGround = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(groundCheck.position, new Vector2(1f, 1f));
    }
}
