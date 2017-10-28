using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendMovement : MonoBehaviour
{

    [SerializeField]
    private GameObject m_decalPool;

    public int friendID = 0;// This is so with multiple "Friends" a trail of them are created, intead of a bunch of top of each other
    public Transform goal;
    public int currentDecal = 0;
    public float speed = 5.0f;
    public bool finished = false;

    private int m_DecalTarget = 0;
    private bool m_NewTarget = true;

    private void Start()
    {
        m_DecalTarget = m_DecalTarget - friendID;
    }

    void Update () {

        if (finished == false) {

            if (currentDecal == 1)//should only play once
            {
                m_DecalTarget = currentDecal;
            }

            if (currentDecal < m_DecalTarget)
            {
                m_DecalTarget = currentDecal;
            }

            if ((m_NewTarget == true) && (m_DecalTarget > 0))
            {
                m_NewTarget = false;
            }

            float _step = speed * Time.deltaTime;

            if ((m_DecalTarget < (currentDecal - friendID)) && (m_DecalTarget > 0))
            {
                transform.position = Vector3.MoveTowards(transform.position, m_decalPool.GetComponent<DecalPool>().decalArray[m_DecalTarget].transform.position, _step);

                if ((transform.position == m_decalPool.GetComponent<DecalPool>().decalArray[m_DecalTarget].transform.position))
                {
                    m_NewTarget = true;
                    m_DecalTarget = m_DecalTarget + 1;
                }
            }
        }

    }//End Update
}