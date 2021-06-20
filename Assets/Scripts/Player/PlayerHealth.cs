using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    public int playerHealth = 1;
    private GameObject parent;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
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
            PauseMenu.Instance.deathPanel();
        }
    }
    public void test()
    {
        Debug.Log("test");
    }



}
