using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoXYEnemyBullet : MonoBehaviour
{
    public float timer = 2f;
    public float speed = 10f;
    public int damge = 1;

    public void setTimerNSpeed(float vtimer, float vspeed,int dmg)
    {
        timer = vtimer;
        speed = vspeed;
        damge = dmg;
    }
    void Update()
    {
        timer -= Time.deltaTime; if (timer <= 0)
            Destroy(gameObject);
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, speed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth.Instance.lostHealth(damge);
        }
    }
}
