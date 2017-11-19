using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideGreenBothDie : MonoBehaviour {

    public string tag = "Friendly";
    private int m_lifes = 1;

    void OnCollisionEnter(Collision col)
    {
        if ((col.gameObject.tag == tag) && (m_lifes > 0))
        {
            col.gameObject.SetActive(false);
            gameObject.SetActive(false);
            m_lifes--;
        }
    }

}
