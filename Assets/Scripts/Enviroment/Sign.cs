using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    private bool trigger = false;
    [TextArea] public string text;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            trigger = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            trigger = false;

        }
    }
    private void Update()
    {
        if (trigger)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                popUp pop = GameObject.Find("Enviroment/pauseMenu").GetComponent<popUp>();
                pop.popup(text);
                
            }
        }

    }
}
