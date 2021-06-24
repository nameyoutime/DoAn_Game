using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPatrol : MonoBehaviour
{

    public float moveSpeed;
    public float rayLength;
    private bool moveLeft;
    public Transform contactChecker;
    [SerializeField] private LayerMask IgnoreExeptMask;
    // Start is called before the first frame update
    void Start()
    {
        moveLeft = true;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
    private void FixedUpdate()
    {

        RaycastHit2D contactCheck = Physics2D.Raycast(contactChecker.position, Vector2.left,
        rayLength, IgnoreExeptMask);
        Debug.DrawRay(contactChecker.position, Vector2.left * rayLength, Color.red);
        if (contactCheck == true)
        {
            if (moveLeft == true)
            {
                transform.eulerAngles = new Vector2(0, -180);
                moveLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 0);
                moveLeft = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "PlayerBullet")
        {
            Debug.Log("hit");
        }
    }
}
