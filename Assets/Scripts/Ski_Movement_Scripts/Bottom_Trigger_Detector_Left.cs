using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom_Trigger_Detector_Left : MonoBehaviour
{
    public GameObject currentBody; 
    public GameObject previousBody; 
    public GameObject pushDownL;
    public GameObject pushBackL;
    public bool pushedL = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ski_ignore") || other.CompareTag("right_ignore") || other.CompareTag("top_ignore"))
            return;

        if (other.gameObject != currentBody) // updates if it's a new body
        {
            previousBody = currentBody;
            currentBody = other.gameObject;

            Debug.Log("New body entered: " + currentBody.name);
        }

        if (previousBody == pushDownL && currentBody == pushBackL)
        {
            pushedL = true;
            Debug.Log("Pushed Left!");
            previousBody = null;
            currentBody = null;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ski_ignore") || other.CompareTag("right_ignore") || other.CompareTag("top_ignore"))
            return;

        if (other.gameObject == currentBody)
        {
            Debug.Log("Body exited: " + currentBody.name); 
        }
    }
}
