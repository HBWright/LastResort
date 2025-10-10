using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom_Trigger_Detector_Right : MonoBehaviour
{
    public GameObject currentBody; 
    public GameObject previousBody; 
    public GameObject pushDownR;
    public GameObject pushBackR;
    public bool pushedR = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ski_ignore") || other.CompareTag("left_ignore") || other.CompareTag("top_ignore"))
            return;

        if (other.gameObject != currentBody) // updates if it's a new body
        {
            previousBody = currentBody;
            currentBody = other.gameObject;

            Debug.Log("New body entered: " + currentBody.name);
        }

        if (previousBody == pushDownR && currentBody == pushBackR)
        {
            pushedR = true;
            Debug.Log("Pushed Right!");
            previousBody = null;
            currentBody = null;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ski_ignore") || other.CompareTag("left_ignore") || other.CompareTag("top_ignore"))
            return;

        if (other.gameObject == currentBody)
        {
            Debug.Log("Body exited: " + currentBody.name);
        }
    }
}
