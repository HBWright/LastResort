using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Collections;

public class Snow_GM : MonoBehaviour
{
    [Header("Avalanche")]
    public GameObject skiier1;
    public GameObject skiier2;

    [Header("Avalanche")]
    public GameObject avalancheTrigger;
    private bool avalancheStarted = false;

    [Header("Sound Effects")]
    public AudioSource Fanfare;
    public AudioSource Countdown;
    public AudioSource avalanche;
    public AudioSource alarm;

    [Header("Player Things")]
    public GameObject MovementCubes;
    public GameObject ski;
    public GameObject WhiteFadeOut;
    public GameObject BlackScreen;


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

        Fanfare.Play();
        yield return new WaitWhile(() => Fanfare.isPlaying);

        yield return new WaitForSeconds(1f);

        Countdown.Play();
        yield return new WaitWhile(() => Countdown.isPlaying);

        skiier1.GetComponent<UnityEngine.Splines.SplineAnimate>().Play();
        skiier2.GetComponent<UnityEngine.Splines.SplineAnimate>().Play();

        MovementCubes.SetActive(true);
    }

    private IEnumerator AvalancheCutscene()
    {
        avalancheTrigger.GetComponent<AvalancheSpawner>().enabled = true;
        alarm.Play();
        yield return new WaitForSeconds(1f);
        avalanche.Play();
        yield return new WaitForSeconds(5f);
        WhiteFadeOut.SetActive(true);
        BlackScreen.SetActive(true);
        SceneManager.LoadScene("HELL_MAIN");
    }
}
