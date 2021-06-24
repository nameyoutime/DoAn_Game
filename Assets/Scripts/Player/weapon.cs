using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    private float offset;
    private player_bullet PB;

    public GameObject projectTile;
    public Transform shotPoint;
    private PlayerController parentScript;
    private static bool m_FacingRight;
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    private void Start()
    {
        parentScript = this.transform.parent.GetComponent<PlayerController>();
        PB = projectTile.GetComponent<player_bullet>();

    }

    public void pickUp()
    {

        gameObject.SetActive(true);
        soundManager.playSound("pickUp_Gun");
    }
    private void Update()
    {

        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        m_FacingRight = parentScript.m_FacingRight;
        switch (m_FacingRight)
        {
            case true:
                offset = 0;
                break;

            default:
                offset = -180;
                break;
        }
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        PB.shoot(m_FacingRight);
        if (Input.GetMouseButtonDown(0))
        {

            soundManager.playSound("shoot");
            Instantiate(projectTile, shotPoint.position, transform.rotation);
        }
    }
}
