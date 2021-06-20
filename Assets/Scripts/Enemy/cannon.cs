using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{

    [SerializeField] private EnemyBullet bullet;
    public float bulletSpeed = 1f;
    public int bulletDamge = 1;
    public float bulletDestroyTime = 1f;
    public bool spawnRight;
    public float ShootSpeed = 1f;


    private Animator animator;
    void Start()
    {
        StartCoroutine(Attack());
        animator = gameObject.GetComponent<Animator>();
    }
    IEnumerator Attack()
    {

        yield return new WaitForSeconds(ShootSpeed);

        if (spawnRight)
        {
            bullet.Shoot(1, bulletSpeed, bulletDestroyTime,bulletDamge);
        }
        else
        {
            bullet.Shoot(-1, bulletSpeed, bulletDestroyTime,bulletDamge);
        }

        Instantiate(bullet, transform.position, transform.rotation);
        animator.SetTrigger("shoot");
        StartCoroutine(Attack());
    }
}
