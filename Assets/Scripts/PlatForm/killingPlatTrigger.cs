using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killingPlatTrigger : MonoBehaviour
{
    public killingPlat triggerKillPlat;
    void Start()
    {
        triggerKillPlat = this.transform.parent.GetComponent<killingPlat>();
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
                triggerKillPlat.Drop();
        }
    }
}
