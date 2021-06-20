using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class PlayerPos : MonoBehaviour
{
    private gameMaster GM;
    private void Start()
    {
        GM = GameObject.Find("GameMaster").GetComponent<gameMaster>();
        transform.position = GM.lastCheckPointPos;
    }




}
