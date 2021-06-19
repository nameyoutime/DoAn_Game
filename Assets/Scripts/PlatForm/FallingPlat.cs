using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlat : MonoBehaviour
{
    Rigidbody2D rb;
    public float waitingTime = 2f;
        private Rigidbody2D theRB2D;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            Invoke("Drop", waitingTime);
            Destroy(gameObject, 2f);
        }
    }
    private void Drop()
    {
        rb.isKinematic = false;
    }
}
