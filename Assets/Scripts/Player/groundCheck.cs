using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    private GameObject parent;
    private PlayerController parentScript;
    void Start()
    {
        parentScript = this.transform.parent.GetComponent<PlayerController>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            
            parentScript.checkGrounded();
        }
    }
}
