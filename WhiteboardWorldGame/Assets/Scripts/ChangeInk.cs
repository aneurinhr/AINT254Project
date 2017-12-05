using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeInk : MonoBehaviour {

    public DecalPool blackPool;
    public DecalPool redPool;
    public DecalPool bluePool;

    public GameObject blackUI;
    public GameObject redUI;
    public GameObject blueUI;

    public Material blackInk;
    public Material redInk;
    public Material blueInk;

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("1"))
        {
            GetComponent<ParticleLauncher>().decalPool = bluePool;
            GetComponent<ParticleSystemRenderer>().material = blueInk;

            blackUI.GetComponent<Image>().color = new Color(135, 135, 135);
            redUI.GetComponent<Image>().color = new Color(135, 135, 135);
            blueUI.GetComponent<Image>().color = Color.green;

            Debug.Log("Blue");
        }
        else if (Input.GetButtonDown("2"))
        {
            GetComponent<ParticleLauncher>().decalPool = blackPool;
            GetComponent<ParticleSystemRenderer>().material = blackInk;

            blackUI.GetComponent<Image>().color = Color.green;
            redUI.GetComponent<Image>().color = new Color(135, 135, 135);
            blueUI.GetComponent<Image>().color = new Color(135, 135, 135);

            Debug.Log("Black");
        }
        else if (Input.GetButtonDown("3"))
        {
            GetComponent<ParticleLauncher>().decalPool = redPool;
            GetComponent<ParticleSystemRenderer>().material = redInk;

            blackUI.GetComponent<Image>().color = new Color(135, 135, 135);
            redUI.GetComponent<Image>().color = Color.green;
            blueUI.GetComponent<Image>().color = new Color(135, 135, 135);

            Debug.Log("Red");
        }

	}
}
