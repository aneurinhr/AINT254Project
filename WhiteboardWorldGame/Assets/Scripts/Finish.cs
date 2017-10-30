using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

    [SerializeField]
    private int m_numFriend = 0;
    [SerializeField]
    private GameObject m_player;
    [SerializeField]
    private GameObject m_Win;
    [SerializeField]
    private GameObject m_Lose;

    private int m_NumFin = 0;
    private bool m_possible = false;

    public int maxDecals = 100;
    public int currentDecal = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Friendly")
        {
            other.GetComponent<FriendMovement>().finished = true;
            other.transform.position = transform.position;
            m_NumFin++;
        }
        else if (other.gameObject.tag == "Ink")
        {
            m_possible = true;
        }

    }//End Trigger

    private void Update()
    {
        if (m_NumFin == m_numFriend)
        {
            m_player.SetActive(false);
            m_Win.SetActive(true);
        }
        else if ((currentDecal >= maxDecals) && (m_possible == false))
        {
            m_player.SetActive(false);
            m_Lose.SetActive(true);
        }
    }

}
