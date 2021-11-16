using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private LevelLoader level;

    private GameObject pauseScreen;

    private GameObject pauseButton;
    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.FindObjectOfType<LevelLoader>();
        if (SceneManager.GetActiveScene().name == "Level")
        {
            pauseScreen = GameObject.FindGameObjectWithTag("Pause Screen");
            pauseScreen.SetActive(false);
            pauseButton = GameObject.FindGameObjectWithTag("Pause Button");
        }
    }

    public void PlayGame()
    {
        level.LoadGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMain()
    {
        Time.timeScale = 1;
        level.LoadMain();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        pauseButton.SetActive(true);
    }
}
