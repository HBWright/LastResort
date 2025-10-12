using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiMovement : MonoBehaviour
{
    public GameObject skis;

    public Top_Trigger_Detector topTriggerLeft;
    public Bottom_Trigger_Detector_Left bottomTriggerLeft;
    public Top_Trigger_Detector topTriggerRight;
    public Bottom_Trigger_Detector_Right bottomTriggerRight;
    public GameObject turnLeft;
    public GameObject turnRight;
    public ParticleSystem snowTrail;


    [Header("Ski Speed Attributes")]
    public float turnRotationSpeed = 10f;
    public float maxSpeed = 9f;
    public float minSpeed = 4.1f;
    public float speedDecrease = .2f;
    public float decreaseRate = 1f;
    private float currentSpeed;         // current moving speed

    void Start()
    {
        StartCoroutine(SlowDown());
    }
    void Update()
    {
        /////////////// Turning Implementation ///////////////
        if (topTriggerLeft.currentBody != null && topTriggerLeft.currentBody == topTriggerRight.currentBody) // Makes sure at least the left trigger isn't null, that way it doesn't start turning for both bodies being null
        {
            GameObject sharedBody = topTriggerLeft.currentBody; // Same body so just reads once
            
            if (sharedBody == turnRight)
            {
                skis.transform.Rotate(Vector3.up, turnRotationSpeed * Time.deltaTime);
            }
            else if (sharedBody == turnLeft)
            {
                skis.transform.Rotate(Vector3.up, -turnRotationSpeed * Time.deltaTime);
            }
        }


        /////////////// Pushing Implementation ///////////////
        if (bottomTriggerLeft.pushedL && bottomTriggerRight.pushedR)
        {
            if (currentSpeed <= maxSpeed)
            {
                currentSpeed += 1f;            // Increase speed by 1
                print("oh shit it pushed!!!");
            }
            else
            {
                currentSpeed = 10f;
            }
            bottomTriggerLeft.pushedL = false; // Reset flags
            bottomTriggerRight.pushedR = false;
        }

        // Move skis forward in the direction it is facing THIS WAS A NIGHTMARE TO SOLVE BTW!!!!!!!
        skis.transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime, Space.Self); // constant movement

        var emission = snowTrail.emission;
        float normalizedSpeed = Mathf.InverseLerp(minSpeed, maxSpeed, currentSpeed); // 0 to 1
        emission.rateOverTime = Mathf.Lerp(0f, 10f, normalizedSpeed); // low to high particle rate
    }

    IEnumerator SlowDown()
    {
        while (true)
        {
            if (currentSpeed > minSpeed)
            {
                currentSpeed -= speedDecrease;
            }
            yield return new WaitForSeconds(decreaseRate);
        }
    }
}
