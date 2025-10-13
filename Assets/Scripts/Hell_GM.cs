using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hell_GM : MonoBehaviour
{
    [Header("Sound Effects")]
    public AudioSource DevilLaugh;
    public AudioSource DevilMonologue;
    public AudioSource DevilLose;
    public AudioSource Countdown;

    [Header("Player Things")]
    public GameObject MovementCubes;
    public GameObject ski;

    void Start()
    {
        StartCoroutine(RaceStart());
    }
    
    private IEnumerator RaceStart()
    {
        yield return new WaitForSeconds(5f);
        // DevilLaugh.Play();
        // yield return new WaitWhile(() => DevilLaugh.isPlaying);
        yield return new WaitForSeconds(1f);
        // DevilMonologue.Play();
        // yield return new WaitWhile(() => DevilMonologue.isPlaying);
        // Countdown.Play();
        yield return new WaitForSeconds(2f);
        // DevilLaugh.Play();
        // Start Devil's animation here
        // yield return new WaitWhile(() => Countdown.isPlaying);
        MovementCubes.SetActive(true);
    }

}
