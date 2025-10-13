using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Collections;

public class Snow_GM : MonoBehaviour
{
    [Header("Avalanche")]
    public GameObject avalancheTrigger;
    private bool avalancheStarted = false;

    [Header("Sound Effects")]
    public AudioSource RaceStartChime;
    public AudioSource Countdown;

    [Header("Player Things")]
    public GameObject MovementCubes;
    public GameObject ski;


    void Start()
    {
        StartCoroutine(RaceStart());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!avalancheStarted && other.gameObject == ski)
        {
            avalancheStarted = true;
            StartCoroutine(AvalancheCutscene());
        }
    }

    private IEnumerator RaceStart()
    {
        yield return new WaitForSeconds(5f);
        // RaceStartChime.Play();
        // yield return new WaitWhile(() => RaceStartChime.isPlaying);
        yield return new WaitForSeconds(1f);
        // Countdown.Play();
        // yield return new WaitWhile(() => Countdown.isPlaying);
        // Start animations for racers here
        MovementCubes.SetActive(true);
    }

    private IEnumerator AvalancheCutscene()
    {
        //start animation here
        //alarm here
        //rumbling sound effect here
        yield return new WaitForSeconds(5f);
        //fade to black shader here
        SceneManager.LoadScene("HELL");
    }
}
