using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] public GameObject bullet;
    public int detectDistant = 3;
    public float BuleltDestroyTime = 2f;
    public float BulletSpeed = 10f;
    public int BulletDMG = 1;
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
        GameObject go = GameObject.Find("player");
        if (Vector3.Distance(transform.position, go.transform.position) < detectDistant)
        {
            bullet.gameObject.GetComponent<NoXYEnemyBullet>().setTimerNSpeed(BuleltDestroyTime, BulletSpeed, BulletDMG);
            Instantiate(bullet, transform.position, transform.rotation);
            animator.SetTrigger("shoot");
        }

        StartCoroutine(Attack());

    }
}
