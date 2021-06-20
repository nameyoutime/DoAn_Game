using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToPlayer : MonoBehaviour
{
    public float rollspeed = 180f;
    Transform player;

    void Update()
    {
        if (player == null)
        {
            GameObject go = GameObject.Find("player");
            if (go != null)
                player = go.transform;
        }

        if (player == null)
            return;

        Vector2 Direction = player.position - transform.position;
        float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg - 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rollspeed * Time.deltaTime);

    }
}
