using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameSession;
    AudioSource musicAudioSource;
    


    bool muted = false;
    bool isPaused = false;

    void Start()
    {
        musicAudioSource = FindObjectOfType<GameMusicLoader>().GetComponent<AudioSource>();

    }

    public bool GetIfPaused()
    {
        return isPaused;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
    }



    public void LoadGame()
    {
        SceneManager.LoadScene(2);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }
    }


    public void MuteMusics()
    {
        musicAudioSource.mute = !musicAudioSource.mute;

    }
}
