using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{
    public int damageToDeal;
    private Rigidbody2D theRB2D;
    private PlayerController parentScript;
    public float bounceForce;
    // Start is called before the first frame update
    void Start()
    {
        theRB2D = transform.parent.GetComponent<Rigidbody2D>();
        parentScript = this.transform.parent.GetComponent<PlayerController>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "HurtBox")
        {
            // theRB2D.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
            parentScript.checkForceJump();
            other.gameObject.GetComponent<EnemyHp>().TakeDamage(damageToDeal);
            
        }
    }
}
