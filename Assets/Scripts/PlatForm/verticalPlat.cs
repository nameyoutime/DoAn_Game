using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verticalPlat : MonoBehaviour
{
    private PlatformEffector2D effector2D;
    private float waitTime = 0.5f;
    private void Start()
    {
        effector2D = GetComponent<PlatformEffector2D>();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitTime = 0.5f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (waitTime <= 0)
            {
                effector2D.rotationalOffset = 180f;
                waitTime = 0.5f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            effector2D.rotationalOffset = 0f;
        }
    }
}
