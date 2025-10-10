using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top_Trigger_Detector : MonoBehaviour
{
    public GameObject currentBody;   // currently "active" body
    public GameObject previousBody;  // last body before current

    private List<GameObject> overlappingBodies = new List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if (IsIgnored(other)) return;

        if (!overlappingBodies.Contains(other.gameObject))
            overlappingBodies.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        if (IsIgnored(other)) return;

        overlappingBodies.Remove(other.gameObject);

        if (other.gameObject == currentBody)
            currentBody = null; // will be reassigned in Update
    }

    void Update()
    {
        // Recheck which body should be current every frame
        if (overlappingBodies.Count > 0)
        {
            GameObject newBody = overlappingBodies[overlappingBodies.Count - 1]; // pick most recent
            if (newBody != currentBody)
            {
                previousBody = currentBody;
                currentBody = newBody;
            }
        }
        else
        {
            currentBody = null;
        }
    }

    private bool IsIgnored(Collider other)
    {
        return other.CompareTag("ski_ignore") ||
               other.CompareTag("right_ignore") ||
               other.CompareTag("left_ignore");
    }
}