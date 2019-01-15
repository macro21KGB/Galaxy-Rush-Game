using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    public float TimeBtwPowerUp = 15f;
    Level level;
    public GameObject PowerUp;

    void Start()
    {
        level = FindObjectOfType<Level>();

        if(PowerUp != null)
        {
            PowerUp.SetActive(false);
        }
    }

    void Update()
    {
        TimeBtwPowerUp -= Time.deltaTime;

        if(TimeBtwPowerUp <= 0 && PowerUp != null) {

            PowerUp.SetActive(true);
        }

        //Restart Game----
       if(Input.GetKeyDown(KeyCode.R) && !level.GetIfPaused())
        {
            SceneManager.LoadScene("Game");
        }
    }

}
