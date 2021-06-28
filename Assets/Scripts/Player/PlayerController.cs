using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    [SerializeField] private float m_JumpForce = 8f;
    public Slider slider;
    public GameObject JumpingEff;
    public float runSpeed = 40f;
    public float abilityTime = 10f;
    private AudioSource footstep;
    private Animator animatior;
    private Vector3 m_Velocity = Vector3.zero;
    private Rigidbody2D _rigidbody;
    private PlayerHealth hp;
    private float horizontalMove, horizontalInput;
    private bool doubleJump;
    public bool m_FacingRight = true;
    private bool jumped = false, isFalling = false, isRunning = false, forceJump = false;
    public bool grounded = false, allowDoubleJump = false;


    private void Start()
    {
        hp = GameObject.Find("player/Health").GetComponent<PlayerHealth>();
        _rigidbody = GetComponent<Rigidbody2D>();
        footstep = GetComponent<AudioSource>();
        animatior = GetComponent<Animator>();
        slider.minValue = 0f;
        slider.maxValue = abilityTime;
    }

    // Update is called once per frame
    private void Update()
    {
        movement();
        input();



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
        allowMultipleJump();
        move(horizontalMove * Time.fixedDeltaTime, horizontalInput);
    }
    private void checkStopMoving()
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
    public void footsteep()
    {
        footstep.Play();
    }
    public void checkForceJump()
    {
        forceJump = true;
    }
    private void allowMultipleJump()
    {
        if (allowDoubleJump == true)
        {
            slider.gameObject.SetActive(true);
            abilityTime -= Time.deltaTime;
            slider.value = abilityTime;
            if (abilityTime < 0)
            {
                slider.gameObject.SetActive(false);
                allowDoubleJump = false;
                abilityTime = 10f;
            }
        }
    }
    private void move(float move, float input)
    {
        Vector3 targetVelocity = new Vector2(move * 10f, _rigidbody.velocity.y);
        _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        if (move > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (move < 0 && m_FacingRight)
        {
            Flip();
        }
    }
    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)&&grounded)
        {
            doubleJump = true;
            _rigidbody.velocity = Vector2.up * m_JumpForce;
            jumped = true;
            animatior.SetBool("isJumping", true);
            animatior.SetBool("isFalling", false);
            soundManager.playSound("jump");
        }
        if (doubleJump && allowDoubleJump)
        {
            doubleJump = false;
            _rigidbody.velocity = Vector2.up * m_JumpForce;
            Destroy(Instantiate(JumpingEff, transform.position, transform.rotation), 0.5f);
            animatior.SetBool("isJumping", true);
            animatior.SetBool("isFalling", false);
            soundManager.playSound("jump");
        }
        if (forceJump == true)
        {
            _rigidbody.velocity = Vector2.up * m_JumpForce;
            jumped = true;
            animatior.SetBool("isJumping", true);
            animatior.SetBool("isFalling", false);
            soundManager.playSound("jump");
            forceJump = false;
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
        m_FacingRight = !m_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Spike") || (other.gameObject.tag == "Enemy" || (other.gameObject.tag == "killingPlat")))
        {
            hp.lostHealth(1);
        }
    }


}
