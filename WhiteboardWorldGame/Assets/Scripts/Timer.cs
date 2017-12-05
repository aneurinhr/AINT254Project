using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float timer;
    public bool finished = false;
    public float startTimer;
    public GameObject Finish;

    private void Start()
    {
        timer = startTimer;
    }

    // Update is called once per frame
    void Update () {

        if (finished == false) {
            timer = timer - Time.deltaTime;

            if (timer < 0.0f)
            {
                Finish.GetComponent<Finish>().GameOver();
            }

            UpdateUITimer();
        }

    }

    private void UpdateUITimer()
    {
        gameObject.GetComponent<Image>().fillAmount = (1/startTimer) * timer;
    }

}
