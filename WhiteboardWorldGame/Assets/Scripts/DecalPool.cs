using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalPool : MonoBehaviour {

    [SerializeField]
    private GameObject m_inkDecal;

    public GameObject[] decalArray;
    public int decalPool = 100;

    private int currentDecal = 0;

	// Use this for initialization
	void Start () {
        GameObject temp;
        decalArray = new GameObject[decalPool];

        for (int i = 0; i < decalPool; i++)
        {
            temp = Instantiate(m_inkDecal);
            decalArray[i] = temp;
            decalArray[i].SetActive(false);
        }
	}

    public void PlaceDecal(ParticleCollisionEvent _collisionEvent)
    {

        if (currentDecal < decalPool)
        {
            decalArray[currentDecal].SetActive(true);
            Vector3 tempPosition = _collisionEvent.intersection;
            tempPosition.y = 0.01f;
            decalArray[currentDecal].transform.position = tempPosition;
        }

        currentDecal++;

    }

}
