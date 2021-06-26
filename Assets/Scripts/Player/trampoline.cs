using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampoline : MonoBehaviour
{
    private Animator animatior;
    [SerializeField] private float force;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * force;
            animatior = other.gameObject.GetComponent<Animator>();
            animatior.SetBool("isJumping", true);
            animatior.SetBool("isFalling", false);
            soundManager.playSound("jump");
        }
    }

}
