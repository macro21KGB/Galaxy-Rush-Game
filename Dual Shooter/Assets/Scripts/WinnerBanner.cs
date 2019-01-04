using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerBanner : MonoBehaviour
{
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;

    Text WinnerText;
    // Start is called before the first frame update
    void Start()
    {
        WinnerText = GetComponent<Text>();
        WinnerText.text = " ";
    }

    // Update is called once per frame
    void Update()
    {

        if(Player1.GetComponent<Text>().text == "Player1 DEAD")
        {
            WinnerText.text = "Player2 Win";
            
        }
        if (Player2.GetComponent<Text>().text == "Player2 DEAD")
        {
            WinnerText.text = "Player1 Win";
        }
        if (Player1.GetComponent<Text>().text == "Player1 DEAD" && Player2.GetComponent<Text>().text == "Player2 DEAD")
        {
            WinnerText.text = "Player Parity";
        }
    }
}
