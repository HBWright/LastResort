using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiMovement : MonoBehaviour
{
    public GameObject skis;

    public Top_Trigger_Detector topTriggerLeft;
    public Bottom_Trigger_Detector bottomTriggerLeft;
    public Top_Trigger_Detector topTriggerRight;
    public Bottom_Trigger_Detector bottomTriggerRight;
    public GameObject turnLeft;
    public GameObject turnRight;

    public float turnRotation = 10f;
    public float moveSpeed = 5f;        // base forward speed
    private float currentSpeed;         // current moving speed
    void Update()
    {
        /////////////// Turning Implementation ///////////////
        if (topTriggerLeft.currentBody != null && topTriggerLeft.currentBody == topTriggerRight.currentBody) // Makes sure at least the left trigger isn't null, that way it doesn't start turning for both bodies being null
        {
            GameObject sharedBody = topTriggerLeft.currentBody; // Same body so just reads once

            if (sharedBody == turnRight)
            {
                skis.transform.Rotate(Vector3.up, turnRotation * Time.deltaTime);
            }
            else if (sharedBody == turnLeft)
            {
                skis.transform.Rotate(Vector3.up, -turnRotation * Time.deltaTime);
            }
        }


        /////////////// Pushing Implementation ///////////////
        if (bottomTriggerLeft.pushedL && bottomTriggerRight.pushedR)
        {
            currentSpeed += 1f;            // Increase speed by 1
            bottomTriggerLeft.pushedL = false; // Reset flags
            bottomTriggerRight.pushedR = false;
            print("oh shit it pushed!!!");
        }

        // Move skis forward in the direction it is facing THIS WAS A NIGHTMARE TO SOLVE BTW!!!!!!!
        skis.transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime, Space.Self); // constant movement

    }
}
