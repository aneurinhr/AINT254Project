using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInk : MonoBehaviour {

    public DecalPool blackPool;
    public DecalPool redPool;
    public DecalPool bluePool;

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("1"))
        {
            GetComponent<ParticleLauncher>().decalPool = bluePool;
            Debug.Log("Blue");
        }
        else if (Input.GetButtonDown("2"))
        {
            GetComponent<ParticleLauncher>().decalPool = blackPool;
            Debug.Log("Black");
        }
        else if (Input.GetButtonDown("3"))
        {
            GetComponent<ParticleLauncher>().decalPool = redPool;
            Debug.Log("Red");
        }

	}
}
