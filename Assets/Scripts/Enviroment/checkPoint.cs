using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    private gameMaster GM;
    private void Start()
    {
        GM = GameObject.Find("GameMaster").GetComponent<gameMaster>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Debug.Log(transform.position);
            GM.lastCheckPointPos = transform.position;
        }
    }
}
