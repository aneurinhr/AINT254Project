using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    private bool m_Paused = false;

	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

	}

    public void Reseter()
    {
        m_Paused = false;
        Time.timeScale = 1.0f;

        int _child = transform.childCount;

        for (int i = 0; i < _child; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    void TogglePause()
    {

        if (m_Paused == false)
        {
            m_Paused = true;
            Time.timeScale = 0.0f;

            int _child = transform.childCount;

            for (int i = 0; i < _child; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }

        }
        else
        {
            m_Paused = false;
            Time.timeScale = 1.0f;

            int _child = transform.childCount;

            for (int i = 0; i < _child; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }

        }

    }

}
