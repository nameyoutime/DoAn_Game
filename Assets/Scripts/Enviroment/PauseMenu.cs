using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;
    public static bool GameIsPause = false;
    public GameObject pauseMenuUi, dealthMenuUi, victoryMenuUi, pauseButton;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                pause();
            }
            else
            {
                resume();
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            onReload();
        }
    }
    public void deathPanel()
    {
        pauseButton.SetActive(false);
        dealthMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
    public void VictoryPanel()
    {
        pauseButton.SetActive(false);
        victoryMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
    public void next()
    {

        victoryMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        //load next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void onReload()
    {
        dealthMenuUi.SetActive(false);
        Reset();
    }
    public void resume()
    {
        pauseButton.SetActive(true);

        Time.timeScale = 1f;
        GameIsPause = false;
        pauseMenuUi.SetActive(false);
    }
    public void pause()
    {
        pauseButton.SetActive(false);
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
    public void Reset()
    {
        GameIsPause = false;
        Time.timeScale = 1f;
        pauseMenuUi.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
