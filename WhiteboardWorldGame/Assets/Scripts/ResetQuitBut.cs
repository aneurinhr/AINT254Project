using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetQuitBut : MonoBehaviour {

    public string sceneName = "";
    public AudioClip button;

    public void ResetScene()
    {
        GetComponent<AudioSource>().PlayOneShot(button);
        StartCoroutine(ExecuteReset());
    }

    public void Quit()
    {
        GetComponent<AudioSource>().PlayOneShot(button);
        StartCoroutine(ExecuteQuit());
    }

    IEnumerator ExecuteReset()
    {
        yield return new WaitForSecondsRealtime(0.3f);

        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator ExecuteQuit()
    {
        yield return new WaitForSecondsRealtime(0.3f);

        Application.Quit();
    }

}
