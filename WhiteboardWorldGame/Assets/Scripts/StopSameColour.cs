using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StopSameColour : MonoBehaviour {

    public string blockTag;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == blockTag)
        {
            other.GetComponent<NavMeshAgent>().isStopped = true;
        }
    }
}
