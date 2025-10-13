using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hell_GM : MonoBehaviour
{
    [Header("Sound Effects")]
    public AudioSource DevilLaugh;
    public AudioSource DevilLose;
    public AudioSource Countdown;
    public AudioSource portal;

    [Header("Player Things")]
    public GameObject MovementCubes;
    public GameObject ski;
    public GameObject devil;

    private bool raceEnded = false;

    void Start()
    {
        StartCoroutine(RaceStart());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!raceEnded && other.gameObject == ski)
        {
            raceEnded = true;
            StartCoroutine(RaceConclusion());
        }

        else if(!raceEnded && other.gameObject == devil)
        {
            raceEnded = true;
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator RaceConclusion()
    {
        DevilLose.Play();
        yield return new WaitForSeconds(5f);
        portal.Play();
        yield return new WaitForSeconds(12f);
        SceneManager.LoadScene("overworld_WIN");
    }
    
    private IEnumerator GameOver()
    {
        DevilLaugh.Play();
        yield return new WaitWhile(() => DevilLaugh.isPlaying);
    }
    private IEnumerator RaceStart()
    {
        yield return new WaitForSeconds(5f);
        DevilLaugh.Play();
        yield return new WaitWhile(() => DevilLaugh.isPlaying);
        yield return new WaitForSeconds(1f);
        
        Countdown.Play();
        yield return new WaitForSeconds(2f);
        DevilLaugh.Play();
        devil.GetComponent<UnityEngine.Splines.SplineAnimate>().Play();
        yield return new WaitWhile(() => Countdown.isPlaying);
        MovementCubes.SetActive(true);
    }

}
