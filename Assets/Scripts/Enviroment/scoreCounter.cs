using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreCounter : MonoBehaviour
{
    public static scoreCounter Instance;
    private int Score = 0;
    public Text txtScore;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void PlusScore(int amount)
    {
        Score = Score + amount;
        txtScore.text = "Score: " + Score;
    }
    void Start()
    {

        // Score = 1000000;
        // Debug.Log(Score);
        txtScore.text = "Score: " + Score;
    }

    void Update()
    {

    }
}
