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

    public int lifes = 1;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == tag) && (lifes > 0))
        {
            int friendID = other.gameObject.GetComponent<FriendMovement>().friendID;
            other.gameObject.SetActive(false);

            m_Finish.GetComponent<Finish>().numFriend = m_Finish.GetComponent<Finish>().numFriend - 1;
            m_UI.GetComponent<FriendUI>().UpdateUI();
            gameObject.GetComponent<AudioSource>().PlayOneShot(dieSound);

            GameObject[] _friends = GameObject.FindGameObjectsWithTag("Friendly");
            int _NumFriend = _friends.Length;

            for (int i = 0; i < _NumFriend; i++)
            {
                _friends[i].GetComponent<FriendMovement>().FriendDie(friendID);
            }

            StartCoroutine(DeathWait());

            lifes--;
        }
    }

    IEnumerator DeathWait()
    {
        yield return new WaitForSeconds(0.15f);

        gameObject.SetActive(false);
    }

}
