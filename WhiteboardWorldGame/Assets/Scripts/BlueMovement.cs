using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlueMovement : MonoBehaviour {

    public Transform[] travelLocations;

    private int m_counter = 0;
    private bool foward = true;
    private bool stop = false;

    private Vector3 start;
    private float normSpeed;

    private void Start()
    {
        start = transform.localPosition;
        normSpeed = GetComponent<NavMeshAgent>().speed;
    }

    public void Reseter()
    {
        m_counter = 0;
        foward = true;
        stop = false;
        GetComponent<NavMeshAgent>().speed = normSpeed;
        transform.localPosition = start;
        GetComponent<NavMeshAgent>().destination = transform.localPosition;
    }

    void Update () {

        if (stop == false)
        {

            GetComponent<NavMeshAgent>().destination = travelLocations[m_counter].position;

            if ((transform.position.x == travelLocations[m_counter].position.x) && (transform.position.z == travelLocations[m_counter].position.z) && (foward == true))
            {
                if (m_counter == travelLocations.Length - 1)
                {
                    foward = false;
                    m_counter--;
                }
                else
                {
                    m_counter++;
                }

            }
            else if ((transform.position.x == travelLocations[m_counter].position.x) && (transform.position.z == travelLocations[m_counter].position.z) && (foward == false))
            {
                if (m_counter == 0)
                {
                    foward = true;
                    m_counter++;
                }
                else
                {
                    m_counter--;
                }

            }

        }
    }

    public void Stop(Transform _decal)
    {
        stop = true;
        GetComponent<NavMeshAgent>().destination = _decal.position;
    }

}
