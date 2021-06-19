using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUi;
    void Start()
    {

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
    }
    public void resume()
    {
        Time.timeScale = 1f;
        GameIsPause = true;
        pauseMenuUi.SetActive(false);
    }
    public void pause()
    {
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
