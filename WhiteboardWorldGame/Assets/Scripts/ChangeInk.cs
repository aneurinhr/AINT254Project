using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInk : MonoBehaviour {

    public DecalPool blackPool;
    public DecalPool redPool;
    public DecalPool bluePool;

    public Material blackInk;
    public Material redInk;
    public Material blueInk;

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("1"))
        {
            GetComponent<ParticleLauncher>().decalPool = bluePool;
            GetComponent<ParticleSystemRenderer>().material = blueInk;
            Debug.Log("Blue");
        }
        else if (Input.GetButtonDown("2"))
        {
            GetComponent<ParticleLauncher>().decalPool = blackPool;
            GetComponent<ParticleSystemRenderer>().material = blackInk;
            Debug.Log("Black");
        }
        else if (Input.GetButtonDown("3"))
        {
            GetComponent<ParticleLauncher>().decalPool = redPool;
            GetComponent<ParticleSystemRenderer>().material = redInk;
            Debug.Log("Red");
        }

	}
}
