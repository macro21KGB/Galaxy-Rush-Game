
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    
    Level level;
    public GameObject PowerUp;

    private float TimeBtwPowerUp;

    void Start()
    {
        TimeBtwPowerUp = Random.Range(8f, 15f);
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
