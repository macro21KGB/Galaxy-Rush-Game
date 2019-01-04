using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAmmoDisplay : MonoBehaviour
{

    [SerializeField] GameObject player;
     Text ammoCount;
    void Start()
    {
        ammoCount = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            ammoCount.text = "Ammo: " + player.GetComponent<Player>().getAmmoClip().ToString();
        }
        else
        {
            ammoCount.text = "Ammo: 0";
        }
        
    }
}
