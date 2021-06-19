using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 1;
    private GameObject parent;

    void Start()
    {
        parent = transform.parent.gameObject;
    }
    public void lostHealth(int lost)
    {
        playerHealth = playerHealth - lost;
        if (playerHealth == 0)
        {
            Destroy(parent);
        }
    }
    public void test()
    {
        Debug.Log("test");
    }



}
