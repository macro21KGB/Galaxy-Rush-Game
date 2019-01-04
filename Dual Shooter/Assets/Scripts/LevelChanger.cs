using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private int levelPriv;

    public void FadeToLevel(int indexLevel)
    {
        
        levelPriv = indexLevel;
        animator.SetTrigger("FadeOut");
    }


    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelPriv);
    }
}
