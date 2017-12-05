using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideGreenBothDie : MonoBehaviour {

    [SerializeField]
    private GameObject m_Finish;
    [SerializeField]
    private GameObject m_UI;

    public string tag = "Friendly";
    public AudioClip dieSound;

    private int m_lifes = 1;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == tag) && (m_lifes > 0))
        {
            other.gameObject.SetActive(false);

            m_Finish.GetComponent<Finish>().m_numFriend = m_Finish.GetComponent<Finish>().m_numFriend - 1;
            m_UI.GetComponent<FriendUI>().UpdateUI();
            gameObject.GetComponent<AudioSource>().PlayOneShot(dieSound);

            StartCoroutine(DeathWait());

            m_lifes--;
        }
    }

    IEnumerator DeathWait()
    {
        yield return new WaitForSeconds(0.15f);

        gameObject.SetActive(false);
    }

}
