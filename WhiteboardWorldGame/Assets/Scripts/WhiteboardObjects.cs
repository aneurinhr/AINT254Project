using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteboardObjects : MonoBehaviour {

    public bool penOverWhiteboard;

    private void Start()
    {
        penOverWhiteboard = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            penOverWhiteboard = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            penOverWhiteboard = false;
        }
    }
}
