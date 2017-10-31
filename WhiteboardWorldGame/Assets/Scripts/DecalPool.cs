using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecalPool : MonoBehaviour
{

    [SerializeField]
    private GameObject m_inkDecal;
    [SerializeField]
    private GameObject m_NextDecal;

    public GameObject finish;
    public Slider inkUI;
    public GameObject[] decalArray;
    public int decalPool = 100;

    private int currentDecal = 0;

    // Use this for initialization
    void Start()
    {
        finish.GetComponent<Finish>().currentDecal = currentDecal;
        finish.GetComponent<Finish>().maxDecals = decalPool;

        GameObject temp;
        decalArray = new GameObject[decalPool];

        for (int i = 0; i < decalPool; i++)
        {
            temp = Instantiate(m_inkDecal);
            decalArray[i] = temp;
            decalArray[i].SetActive(false);
        }

        inkUI.maxValue = decalPool;
        inkUI.value = inkUI.maxValue;

    }

    public void PlaceDecal(ParticleCollisionEvent _collisionEvent)
    {

        if (currentDecal == 0)
        {
            if (_collisionEvent.colliderComponent.tag == "Start")
            {
                DecalPosition(_collisionEvent);
            }
        }
        else
        {
            if (_collisionEvent.colliderComponent.tag == "NextDecal")
            {
                DecalPosition(_collisionEvent);
            }
        }

    }

    private void DecalPosition(ParticleCollisionEvent _collisionEvent)
    {

        if (currentDecal < decalPool)
        {
            decalArray[currentDecal].SetActive(true);

            Vector3 tempPosition = _collisionEvent.intersection;
            tempPosition.y = 0.01f;

            decalArray[currentDecal].transform.position = tempPosition;
            m_NextDecal.transform.position = tempPosition;

            currentDecal++;

            UpdateCurrentDecals();
            inkUI.value = decalPool - currentDecal;

            if (inkUI.value == 0)
            {
                inkUI.gameObject.SetActive(false);
            }
        }

    }

    private void UpdateCurrentDecals()
    {
        GameObject[] _friends = GameObject.FindGameObjectsWithTag("Friendly");

        for (int i = 0; i < _friends.Length; i++)
        {
            _friends[i].GetComponent<FriendMovement>().currentDecal = currentDecal;
        }

        finish.GetComponent<Finish>().currentDecal = currentDecal;
    }
}
