using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    
    Level level;
    public GameObject PowerUp;
    public AudioClip HomingOnline;

    public Animator animator;
    private float TimeBtwPowerUp;

    void Start()
    {
        TimeBtwPowerUp = Random.Range(8f, 15f);
        level = FindObjectOfType<Level>();
        StartCoroutine(PlaySound());
        
        if(PowerUp != null)
        {
            PowerUp.SetActive(false);
        }
    }

    IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(TimeBtwPowerUp);
        AudioSource.PlayClipAtPoint(HomingOnline, Camera.main.transform.position);
    }

    void Update()
    {
        TimeBtwPowerUp -= Time.deltaTime;

        if(TimeBtwPowerUp <= 0 && PowerUp != null) {
            PowerUp.SetActive(true);
            animator.SetTrigger("isOnline");
        }

        //Restart Game----
       if(Input.GetKeyDown(KeyCode.R) && !level.GetIfPaused())
        {
            SceneManager.LoadScene("Game");
        }
    }

}
