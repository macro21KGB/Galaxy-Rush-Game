using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLivesDisplay : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] string playerName;

    Text playerLives;
    // Start is called before the first frame update
    void Start()
    {
        playerLives = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            playerLives.text = (playerName + ": " + (player.GetComponent<Player>().getHealth())/100).ToString() + " lives";
        }
        else
        {
            playerLives.text = playerName + " DEAD";
        }


    }
}
