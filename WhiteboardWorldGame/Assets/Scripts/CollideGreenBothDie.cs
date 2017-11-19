using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideGreenBothDie : MonoBehaviour {

    [SerializeField]
    private GameObject m_Finish;

    public string tag = "Friendly";

    private int m_lifes = 1;

    void OnCollisionEnter(Collision col)
    {
        if ((col.gameObject.tag == tag) && (m_lifes > 0))
        {
            col.gameObject.SetActive(false);

            m_Finish.GetComponent<Finish>().m_numFriend = m_Finish.GetComponent<Finish>().m_numFriend - 1;

            gameObject.SetActive(false);
            m_lifes--;
        }
    }

}
