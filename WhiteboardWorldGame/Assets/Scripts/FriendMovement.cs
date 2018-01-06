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
    public int Spacing = 1;

    private int m_DecalTarget = 0;
    private bool m_NewTarget = true;

    //Reseter Stuff
    private Vector3 start;
    private int startId;

    private void Start()
    {
        //Reseter stuff
        start = transform.localPosition;
        startId = friendID;

        m_DecalTarget = m_DecalTarget - (friendID * Spacing);
    }

    public void Reseter()
    {
        transform.localPosition = start;
        friendID = startId;

        m_DecalTarget = 0 - (friendID * Spacing);
    }

    public void FriendFinished()
    {
        friendID = friendID - 1;
    }

    public void FriendDie(int deadId)
    {
        if (friendID != 0)
        {
            if (deadId > friendID)
            {
                friendID = friendID + 1;
            }
            else if (deadId < friendID)
            {
                friendID = friendID - 1;
            }
        }
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

            if ((m_DecalTarget < (currentDecal - (friendID * Spacing))) && (m_DecalTarget > 0))
            {
                Vector3 _moveTo = m_decalPool.GetComponent<DecalPool>().decalArray[m_DecalTarget].transform.position;

                transform.position = Vector3.MoveTowards(transform.position, _moveTo, _step);

                if ((transform.position == m_decalPool.GetComponent<DecalPool>().decalArray[m_DecalTarget].transform.position))
                {
                    m_NewTarget = true;
                    m_DecalTarget = m_DecalTarget + 1;
                }
            }
        }

    }//End Update
}