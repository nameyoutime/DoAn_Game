using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    public float runSpeed = 40f;
    [SerializeField] private float m_JumpForce = 8f;
    public Animator animatior;

    private AudioSource footstep;
    private Vector3 m_Velocity = Vector3.zero;
    private Rigidbody2D _rigidbody;
    private PlayerHealth hp;
    private float horizontalMove, horizontalInput;
    public bool m_FacingRight = true;
    private bool jumped = false, isFalling = false, isRunning = false, grounded = false, forceJump = false;


    private void Start()
    {
        hp = GameObject.Find("player/Health").GetComponent<PlayerHealth>();
        _rigidbody = GetComponent<Rigidbody2D>();
        footstep = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        input();
        movement();

    }

    private void input()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animatior.SetFloat("isRunning", Mathf.Abs(horizontalMove));
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void movement()
    {
        jump();
        checkStopMoving();
        move(horizontalMove * Time.fixedDeltaTime, horizontalInput);
    }
    void checkStopMoving()
    {
        if (_rigidbody.velocity.x == 0 || horizontalInput == 0)
        {
            isRunning = false;
        }
        else
        {
            isRunning = true;
        }
    }

    public void checkGrounded()
    {
        grounded = true;
    }

    public void footsteep()
    {
        footstep.Play();
    }

    private void move(float move, float input)
    {

        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move * 10f, _rigidbody.velocity.y);
        // And then smoothing it out and applying it to the character
        _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }

        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }


    }
    public void checkForceJump()
    {
        forceJump = true;
    }
    private void jump()
    {
        if (forceJump == true)
        {
            _rigidbody.AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
            jumped = true;
            animatior.SetBool("isJumping", true);
            animatior.SetBool("isFalling", false);
            soundManager.playSound("jump");
            forceJump = false;
        }
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0f, m_JumpForce), ForceMode2D.Impulse);
            jumped = true;
            animatior.SetBool("isJumping", true);
            animatior.SetBool("isFalling", false);
            soundManager.playSound("jump");

        }
        if (_rigidbody.velocity.y < -0.1)
        {
            isFalling = true;
            animatior.SetBool("isFalling", true);
            animatior.SetBool("isJumping", false);
        }
        else if (grounded == true)
        {
            jumped = false;
            isFalling = false;
            animatior.SetBool("isFalling", false);
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Spike") || (other.gameObject.tag == "Enemy"))
        {
            hp.lostHealth(1);

            //theGM.GameOver();

        }
    }


}
