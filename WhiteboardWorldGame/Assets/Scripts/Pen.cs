using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : MonoBehaviour {

    [SerializeField]
    private Camera m_camera;

    private Vector3 m_pos;

    void Update()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _hit;

        if (Physics.Raycast(_ray, out _hit))
        {
            m_pos = _hit.point + new Vector3(0,3,0);
            gameObject.transform.position = m_pos;
        }

    }//End Update

}
