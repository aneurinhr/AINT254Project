using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

    [SerializeField]
    private Vector3[] m_cameraLocations; //This for the 4 camera rotations

    [SerializeField]
    private float m_cooldownTime = 1;

    private int m_currentCamera = 0;
    private bool m_cooldown = false;

	// Use this for initialization
	void Start () {

        gameObject.transform.position = m_cameraLocations[m_currentCamera]; //Sets initial camera position

    }//End Start
	
	void Update () {

        if ((Input.GetAxis("Horizontal") > 0) && (m_cooldown == false)) //Right
        {
            m_currentCamera = m_currentCamera + 1;

            if (m_currentCamera > 3)
            {
                m_currentCamera = 0;
            }

            gameObject.transform.Rotate(0, -90, 0, Space.World);
            gameObject.transform.position = m_cameraLocations[m_currentCamera];

            m_cooldown = true;
            Invoke("Cooldown", m_cooldownTime);
        }
        else if ((Input.GetAxis("Horizontal") < 0) && (m_cooldown == false)) //Left
        {
            m_currentCamera = m_currentCamera - 1;

            if (m_currentCamera < 0)
            {
                m_currentCamera = 3;
            }

            gameObject.transform.Rotate(0, 90, 0, Space.World);
            gameObject.transform.position = m_cameraLocations[m_currentCamera];

            m_cooldown = true;
            Invoke("Cooldown", m_cooldownTime);
        }

    }//End Update

    private void Cooldown()
    {
        m_cooldown = false;
    }

}
