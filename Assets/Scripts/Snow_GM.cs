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
    public ParticleSystem avalancheParticle;
    private bool avalancheStarted = false;

    [Header("Sound Effects")]
    public AudioSource Fanfare;
    public AudioSource Countdown;
    public AudioSource avalanche;
    public AudioSource alarm;
    public AudioSource song;

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

        song.Play();
        skiier1.GetComponent<UnityEngine.Splines.SplineAnimate>().Play();
        skiier2.GetComponent<UnityEngine.Splines.SplineAnimate>().Play();

        MovementCubes.SetActive(true);
    }

    private IEnumerator AvalancheCutscene()
    {
        alarm.Play();
        yield return new WaitForSeconds(1f);
        song.Stop();
        avalancheParticle.Play();
        avalanche.Play();
        Vector3 pos = ski.transform.position;
        pos.y += 1f;
        ski.transform.position = pos;
        ski.SetActive(false);
        yield return new WaitForSeconds(3f);
        WhiteFadeOut.SetActive(true);
        BlackScreen.SetActive(true);
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("HELL_MAIN");
    }
}
