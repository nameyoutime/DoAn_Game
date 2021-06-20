using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    public int spikeDamge = 1;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth.Instance.lostHealth(spikeDamge);
        }
    }
}
