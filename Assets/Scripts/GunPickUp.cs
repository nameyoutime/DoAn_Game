using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    private weapon weapon;
    private void Awake()
    {
        weapon = GameObject.Find("player/assault_rifle").GetComponent<weapon>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            weapon.pickUp();
            Camera.main.GetComponent<AudioSource>().Stop();
            GameObject.Find("Main Camera/pickUp_BG").GetComponent<AudioSource>().Play();
            Destroy(gameObject);

        }
    }
}
