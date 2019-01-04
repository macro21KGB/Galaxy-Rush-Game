using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    Level level;

    void Start()
    {
        level = FindObjectOfType<Level>();
    }

    void Update()
    {
        
        //Restart Game----
       if(Input.GetKeyDown(KeyCode.R) && !level.GetIfPaused())
        {
            SceneManager.LoadScene("Game");
        }
    }

}
