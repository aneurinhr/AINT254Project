using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseter : MonoBehaviour {

    public GameObject[] friendMagnets;
    public GameObject[] blueMagnets;
    public GameObject[] redMagnets;

    public Timer Timer;
    public DecalPool[] InkPools;

    public Finish Finish;
    public FriendUI FriendUI;
    public PauseMenu pauseMenu;

    // Use this for initialization
    void Start () {
	}

    public void ResetAll()
    {
        pauseMenu.Reseter();
        Timer.Reseter();

        for (int i = 0; i < InkPools.Length; i++)
        {
            InkPools[i].ResetPool();
        }

        for (int i = 0; i < blueMagnets.Length; i++)
        {
            blueMagnets[i].SetActive(true);
            blueMagnets[i].GetComponent<CollideGreenBothDie>().lifes = 1;
            blueMagnets[i].GetComponent<BlueMovement>().Reseter();
        }

        for (int i = 0; i < friendMagnets.Length; i++)
        {
            friendMagnets[i].SetActive(true);
            friendMagnets[i].GetComponent<FriendMovement>().Reseter();
        }

        for (int i = 0; i < redMagnets.Length; i++)
        {
            redMagnets[i].SetActive(true);
            redMagnets[i].GetComponent<CollideGreenBothDie>().lifes = 1;
            redMagnets[i].GetComponent<Chase>().Reseter();
        }

        Finish.ResetFinish();
        FriendUI.ResetFriends();
    }

}
