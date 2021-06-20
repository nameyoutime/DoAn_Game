using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    public static ExitLevel Instance;
    private Animator anim;
    private BoxCollider2D box;
    private gameMaster GM;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        GM = GameObject.Find("GameMaster").GetComponent<gameMaster>();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        StartCoroutine(DoorOpen());
    }

    IEnumerator DoorOpen()
    {
        //condition to open the door
        if (GM.Score >= 0)
        {
            box.isTrigger = true;
            anim.SetBool("open", true);
        }
        yield return new WaitForSeconds(0.5f);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Camera.main.GetComponent<AudioSource>().volume = 0;
            PauseMenu.Instance.VictoryPanel();
            soundManager.playSound("course_clear");
            // Destroy(Instantiate(exit, collision.transform.position, Quaternion.identity), 1f);
        }
    }
}
