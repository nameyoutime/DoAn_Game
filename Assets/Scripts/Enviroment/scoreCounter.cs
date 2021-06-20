using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreCounter : MonoBehaviour
{
    public static scoreCounter Instance;
    private gameMaster GM;
    public Text txtScore,finalTxtScore;
    void Awake()
    {
        GM = GameObject.Find("GameMaster").GetComponent<gameMaster>();
        txtScore.text = "Score: " + GM.Score;
        finalTxtScore.text = "Score: " + GM.Score;
        if (Instance == null)
            Instance = this;

    }
    public void PlusScore(int amount)
    {

        GM.Score = GM.Score + amount;
        txtScore.text = "Score: " + GM.Score;
        finalTxtScore.text = "Score: " + GM.Score;
    }
}
