using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom_Trigger_Detector : MonoBehaviour
{
    public GameObject currentBody; // Leave both these empty in inspector - H
    public GameObject previousBody; // important for the pushing mechanic
    public GameObject pushDownL;
    public GameObject pushBackL;
    public GameObject pushDownR;
    public GameObject pushBackR;

    public bool pushedL = false;
    public bool pushedR = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != currentBody) // updates if it's a new body
        {
            previousBody = currentBody; // stores the last non-null body
            currentBody = other.gameObject;
        }

        if (previousBody == pushDownL && currentBody == pushBackL)
        {
            pushedL = true;
            previousBody = null;
            currentBody = null;
        }

        else if (previousBody == pushDownR && currentBody == pushBackR)
        {
            pushedR = true;
            previousBody = null;
            currentBody = null;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentBody)
        {
            currentBody = null;
        }
    }
}
