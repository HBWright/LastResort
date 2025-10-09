using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top_Trigger_Detector : MonoBehaviour
{
    public GameObject currentBody; // Leave both these empty in inspector - H
    public GameObject previousBody; // important for the pushing mechanic


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != currentBody) // updates if it's a new body
        {
            previousBody = currentBody; // stores the last non-null body
            currentBody = other.gameObject;
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
