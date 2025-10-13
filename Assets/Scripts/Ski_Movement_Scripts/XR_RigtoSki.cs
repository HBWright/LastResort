using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XR_RigtoSki : MonoBehaviour
{
    public Transform ski;
    public Transform xrRig;
    public Vector3 offsetVector = new Vector3(0f, 1.7f, 0f);
    void LateUpdate()
    {
        if (ski != null && ski.gameObject.activeInHierarchy)
        {
            // Follow ski
            xrRig.position = ski.position + offsetVector;
            xrRig.rotation = Quaternion.Slerp(xrRig.rotation, ski.rotation, Time.deltaTime * 5f);
        }
        // else: ski is inactive → XR Rig stays in place
    }
}
