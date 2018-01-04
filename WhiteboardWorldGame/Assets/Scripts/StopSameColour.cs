using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StopSameColour : MonoBehaviour {

    public string blockTag;
    public float slowSpeed = 0.5f;
    public float normSpeed = 3.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == blockTag)
        {
            other.GetComponent<NavMeshAgent>().speed = slowSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == blockTag)
        {
            other.GetComponent<NavMeshAgent>().speed = normSpeed;
        }
    }
}
