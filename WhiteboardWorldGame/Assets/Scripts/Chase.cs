using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour {

    public Transform goal;
    public float seeDistance = 20;
    public GameObject[] greenMagnets;

    private int currentSearch = 0;
    private bool m_seen = false;
    private bool stop = false;

    private void Update()
    {
        if (stop == false)
        {
            if (currentSearch < 0)
            {
                m_seen = false;
            }

            if ((greenMagnets.Length > 0) && (m_seen == false))
            {

                for (int i = 0; i < greenMagnets.Length; i++)
                {
                    DetectGreenMagnets(greenMagnets[i]);
                }

            }
            else if (m_seen == true)
            {
                goal = greenMagnets[currentSearch].transform;
                GetComponent<NavMeshAgent>().destination = goal.position;

                if(greenMagnets[currentSearch].active == false)
                {
                    m_seen = false;
                }

            }
        }
    }

    private void DetectGreenMagnets(GameObject _magnet)
    {
        Vector3 _rayDirection = _magnet.transform.position - transform.position;
        RaycastHit hit;

        Debug.DrawRay(transform.position, _rayDirection, Color.red);

        Ray sightRay = new Ray(transform.position, _rayDirection);

        if (Physics.Raycast(sightRay, out hit, seeDistance))
        {
            if (hit.collider.CompareTag("Friendly"))
            {
                goal = hit.collider.gameObject.transform;
                m_seen = true;
                GetComponent<NavMeshAgent>().destination = goal.position;

                for (int i = 0; i < greenMagnets.Length; i++)
                {
                    if (greenMagnets[i] == hit.collider.gameObject)
                    {
                        currentSearch = i;
                    }
                }
            }
            else
            {
                m_seen = false;
            }
        }
    }

    public void Stop(Transform _decal)
    {
        stop = true;
        GetComponent<NavMeshAgent>().destination = _decal.position;
    }

}
