using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StopSameColour : MonoBehaviour {

    public string blockTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == blockTag)
        {
            if (blockTag == "BlueMagnet")
            {
                other.GetComponent<BlueMovement>().Stop(transform);
            }
            else if (blockTag == "RedMagnet")
            {
                other.GetComponent<Chase>().Stop(transform);
            }
        }
    }
}
