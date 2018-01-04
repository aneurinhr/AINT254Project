using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeInk : MonoBehaviour {

    public DecalPool blackPool;
    public DecalPool redPool;
    public DecalPool bluePool;

    public GameObject blackUI;
    public GameObject redUI;
    public GameObject blueUI;

    public GameObject Pen;
    public GameObject particleLauncher;

    public Material blackInk;
    public Material redInk;
    public Material blueInk;

    public Material penBlack;
    public Material penRed;
    public Material penBlue;

    private string m_colour = "Black";
    private bool m_CanSelect = false;

    private void FixedUpdate()
    {
        if ((Input.GetButton("Fire1")) && (m_CanSelect == true))
        {
            ChangeInkType();
        }
    }

    private void Update()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _hit;

        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.collider.tag == "BlackPen")
            {
                m_colour = "Black";
                m_CanSelect = true;
            }
            else if (_hit.collider.tag == "BluePen")
            {
                m_colour = "Blue";
                m_CanSelect = true;
            }
            else if (_hit.collider.tag == "RedPen")
            {
                m_colour = "Red";
                m_CanSelect = true;
            }
            else
            {
                m_CanSelect = false;
            }
        }
        else
        {
            m_CanSelect = false;
        }
    }

    public void ChangeInkType()
    {
        if (m_colour == "Blue")
        {
            particleLauncher.GetComponent<ParticleLauncher>().decalPool = bluePool;
            particleLauncher.GetComponent<ParticleSystemRenderer>().material = blueInk;

            blackUI.GetComponent<Image>().color = new Color(135, 135, 135);
            redUI.GetComponent<Image>().color = new Color(135, 135, 135);
            blueUI.GetComponent<Image>().color = Color.green;

            Pen.GetComponent<Renderer>().material = penBlue;
        }
        else if (m_colour == "Black")
        {
            particleLauncher.GetComponent<ParticleLauncher>().decalPool = blackPool;
            particleLauncher.GetComponent<ParticleSystemRenderer>().material = blackInk;

            blackUI.GetComponent<Image>().color = Color.green;
            redUI.GetComponent<Image>().color = new Color(135, 135, 135);
            blueUI.GetComponent<Image>().color = new Color(135, 135, 135);

            Pen.GetComponent<Renderer>().material = penBlack;
        }
        else if (m_colour == "Red")
        {
            particleLauncher.GetComponent<ParticleLauncher>().decalPool = redPool;
            particleLauncher.GetComponent<ParticleSystemRenderer>().material = redInk;

            blackUI.GetComponent<Image>().color = new Color(135, 135, 135);
            redUI.GetComponent<Image>().color = Color.green;
            blueUI.GetComponent<Image>().color = new Color(135, 135, 135);

            Pen.GetComponent<Renderer>().material = penRed;
        }
    }
}
