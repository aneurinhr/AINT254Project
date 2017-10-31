using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

    public string nextScene;

	public void Activate()
    {
        if (nextScene == "Quit")
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
    }

}
