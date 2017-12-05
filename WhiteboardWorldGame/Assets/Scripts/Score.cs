using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public float timeLeft = 0;
    public float friendsLeft = 0;
    public bool CalcScore = true;
	
	// Update is called once per frame
	void Update () {
		
        if (CalcScore == false)
        {
            float score = timeLeft * friendsLeft;
            gameObject.GetComponent<Text>().text = "Score: " + (int)score;
            CalcScore = true;
        }

	}
}
