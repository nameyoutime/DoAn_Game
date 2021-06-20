using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int direction;
    public float speed;
    public float destroyTime;
    public int damge;

    public void Shoot(int dir, float sp, float des, int dmg)
    {
        direction = dir;
        speed = sp;
        destroyTime = des;
        damge = dmg;

    }
    void Update()
    {
        Attack();
    }
    void Attack()
    {
        destroyTime -= Time.deltaTime; if (destroyTime <= 0)
            Destroy(gameObject);

        Vector2 temp = transform.position;
        temp.x += direction * 5 * Time.deltaTime * speed;
        transform.position = temp;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            PlayerHealth.Instance.lostHealth(damge);
        }
    }
}
