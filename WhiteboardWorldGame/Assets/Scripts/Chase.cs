using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour {

    public Transform goal;
    public float seeDistance = 20;

    private List<GameObject> m_greenMagnets = new List<GameObject>();
    private int currentSearch = 0;
    private bool m_seen = false;

    private void Start()
    {
        m_greenMagnets.Add(gameObject);
    }

    private void Update()
    {
        if (currentSearch < 1)
        {
            m_seen = false;
        }

        if ((m_greenMagnets.Count > 1) && (m_seen == false))
        {

            for (int i = 1; i < m_greenMagnets.Count; i++)
            {
                DetectGreenMagnets(m_greenMagnets[i]);
            }

        }
        else if (m_seen == true)
        {
            goal = m_greenMagnets[currentSearch].transform;
            GetComponent<NavMeshAgent>().destination = goal.position;
        }
    }

    private void DetectGreenMagnets(GameObject _magnet)
    {
        Vector3 _rayDirection = _magnet.transform.position - transform.position;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, _rayDirection, out hit, seeDistance))
        {
            if (hit.collider.CompareTag("Friendly"))
            {
                goal = hit.collider.gameObject.transform;
                m_seen = true;
                GetComponent<NavMeshAgent>().destination = goal.position;
                currentSearch = m_greenMagnets.IndexOf(hit.collider.gameObject);
            }
            else
            {
                m_seen = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Friendly")
        {
            m_greenMagnets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Friendly")
        {

            if (m_greenMagnets.IndexOf(other.gameObject) == currentSearch)
            {
                currentSearch = -1;
            }

            m_greenMagnets.Remove(other.gameObject);
        }
    }
}
