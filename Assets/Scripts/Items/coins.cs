using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour
{
    [SerializeField] private int score = 1;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            soundManager.playSound("gems");
            scoreCounter.Instance.PlusScore(score);
            // Timer.time += 20;
            // if (DoorScript.Instance != null)
            //     DoorScript.Instance.DecrementCollectables();

        }
    }
}
