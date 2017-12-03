using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwapButton : MonoBehaviour {

    public Canvas nextCanvas;
    public Canvas currentCanvas;
    public AudioClip button;

    public void Activate()
    {
        if (nextCanvas == null)
        {
            GetComponent<AudioSource>().PlayOneShot(button);
            StartCoroutine(ExecuteQuit());
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(button);
            StartCoroutine(ExecuteReset());
        }
    }

    IEnumerator ExecuteReset()
    {
        yield return new WaitForSeconds(0.3f);

        nextCanvas.gameObject.SetActive(true);

        currentCanvas.gameObject.SetActive(false);
    }

    IEnumerator ExecuteQuit()
    {
        yield return new WaitForSeconds(0.3f);

        Application.Quit();
    }
}
