using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ParticleSplashManager : MonoBehaviour
{
    public Animator animator;
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        particle.Play();
        StartCoroutine(LoadParticle());
    }

    private IEnumerator LoadParticle()
    {
        yield return new WaitForSeconds(0.2f);
        particle.Pause();
        StartCoroutine(LoadMainMenu());
    }



    private IEnumerator LoadMainMenu()
    {

        yield return new WaitForSeconds(4);
        animator.SetTrigger("FadeOut");
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
}
