using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    private bool m_FacingRight;
    private PlayerController player;
    private Vector2 direction;
    public GameObject eff;
    private void Awake()
    {
        player = GameObject.Find("player").GetComponent<PlayerController>();
    }
    private void Start()
    {
        Invoke("destroyBullet", lifeTime);
    }
    public void shoot(bool FacingRight)
    {
        m_FacingRight = FacingRight;


    }
    private void Update()
    {
        player = GameObject.Find("player").GetComponent<PlayerController>();
        switch (player.m_FacingRight)
        {
            case true:
                direction = Vector2.right;
                break;

            default:
                direction = Vector2.left;
                break;
        }
        transform.Translate(direction * speed * Time.deltaTime);
    }
    void destroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(Instantiate(eff, transform.position, this.transform.rotation), 0.5f);
        }
    }

}
