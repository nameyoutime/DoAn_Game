using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killingPlat : MonoBehaviour
{

    public int spikeDmg = 1;
    private Rigidbody2D rb;

    private Rigidbody2D theRB2D;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Drop()
    {
        rb.isKinematic = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && rb.isKinematic == false)
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player" && rb.isKinematic == false)
        {
            PlayerHealth.Instance.lostHealth(spikeDmg);
            // Invoke("byeKillingPlat", waitingTime);
        }
    }
}
